using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Errors;
using static Ungerboeck.Api.Models.Options.ThrowErrorIntensity;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  internal static class Util
  {
    private static bool Unauthorized(HttpResponseMessage response)
    {
      //Most likely something wasn't included or was malformed in the header
      if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) return true;

      return false;
    }

    internal async static System.Threading.Tasks.Task<bool> ValidateResponse(ApiClient client, HttpResponseMessage response)
    {
      if (client.LastResponseError == null)
      {
        if (SuccessResponse(response))
        {
          return true;
        }
        else
        {
          var task = await ExtractApiError(response);
          client.LastResponseError = task; 
        }
      }

      if (ShouldThrowError(client)) throw new Exception(GetClientMessage(client));
      return false;
    }

    private static string GetClientMessage(ApiClient client)
    {
      string message = client?.LastResponseError?.ErrorList.FirstOrDefault()?.Message;
      if (message == null) return "Message returned as null";
      return message;
    }

    private static bool ShouldThrowError(ApiClient client)
    {
      bool throwError = false;
      var thrownErrorIntensity = client.GlobalOptions.ThrowErrorIntensity;
      var status = client.LastResponseError.Status;

      switch (thrownErrorIntensity)
      {
        case DoNotThrowErrors:
          break;
        case UnexpectedServerErrorsOnly:
          {
            if (status == (int)System.Net.HttpStatusCode.InternalServerError)
            {
              throwError = true;
            }

            break;
          }
        case UnexpectedClientOrServerErrors:
          {
            if (status != (int)System.Net.HttpStatusCode.NotFound)
            {
              throwError = true;
            }

            break;
          }
        default:
          throwError = true;
          break;
      }

      return throwError;
    }

    private async static System.Threading.Tasks.Task<ApiErrors> ExtractApiError(HttpResponseMessage response)
    {
      ApiErrors apiErrors;
      string responseErrorMessage = null;
      try
      {
        responseErrorMessage = GetResponseErrorMessage(response);

        if (response.Content == null)
        {
          //This is most likely a problem connecting to the API endpoint.
          apiErrors = GetErrorConnectingApiError(response, responseErrorMessage);
        }
        else
        {
          // Starting in .97, Additional exception message info is passed back from the API via the ApiError in the response content
          var apiErrorObjectTask = response.Content.ReadAsStringAsync();


          var apiErrorObject = await apiErrorObjectTask;          

          if (string.IsNullOrEmpty(apiErrorObject))
          {
            apiErrors = new ApiErrors((int)response.StatusCode,
              "CannotExtractApiErrorEmpty",
              "The API Error object was empty.  Response Error returned: " + responseErrorMessage,
              ErrorSources.Sdk);
          }
          else
          {
            apiErrorObject = System.Web.HttpUtility.UrlDecode(apiErrorObject);
            apiErrors = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiErrors>(apiErrorObject);

            if (apiErrors == null || apiErrors.Status == 0 || !apiErrors.ErrorList.Any())
            {
              //This is likely a problem connecting to the API Endpoint
              apiErrors = GetErrorConnectingApiError(response, responseErrorMessage);
            }

          }
        }
      }
      catch (Exception ex)
      {
        //Problem extracting the error.  Make a new API Error object with the info
        string extractionError;

        if (ex.Message == "Unexpected character encountered while parsing value: <. Path '', line 0, position 0.") //The error is in form of a webpage
        {
          extractionError = "The error is an HTTP communication error.  This is most likely a connection issue. " +
            $"Response Error returned: {responseErrorMessage}"; 
        }
        else
        {
          extractionError = $"Error while attempting to extract API Error: {ex.Message} stacktrace: {ex.StackTrace}  " +
              $"Response Error returned: {responseErrorMessage}";
        }

        apiErrors = new ApiErrors((int)response.StatusCode,
            "CannotExtractApiErrorUnknown",
            extractionError,
            ErrorSources.Sdk);

        System.Diagnostics.Trace.WriteLine(extractionError); //Set an extra diagnostic for visibility
      }

      return apiErrors;
    }

    private static ApiErrors GetErrorConnectingApiError(HttpResponseMessage response, string responseErrorMessage)
    {
      return new ApiErrors((int)response.StatusCode,
                        "ErrorConnectingToApi",
                        "There were problems communicating to the API.  Response Error returned: " + responseErrorMessage,
                        ErrorSources.Sdk);
    }

    private static string GetResponseErrorMessage(HttpResponseMessage response)
    {
      string responseErrorMessage;

      if (Unauthorized(response) && response.Headers.WwwAuthenticate.Count > 0)
      {
        responseErrorMessage = response.Headers.WwwAuthenticate.FirstOrDefault()?.ToString(); // Specific authentication errors come back as their own header
      }
      else
      {
        responseErrorMessage = response.ReasonPhrase; // Exception messages are passed back from the API via the response's reason phrase property                     
      }

      return responseErrorMessage;
    }

    private static bool SuccessResponse(HttpResponseMessage response)
    {
      //OK (200) is the general good response.  Successful deletes return NoContent
      return (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.NoContent);
    }

    internal static string GetSubjectName<T>()
    {
      Type modelType = typeof(T);
      if (modelType == null || modelType.Namespace == null || modelType.Namespace != "Ungerboeck.Api.Models.Subjects")
      {
        throw new Exception("T should be an object of the Ungerboeck.Api.Models.Model classes (ex: Ungerboeck.Api.Models.Subjects.EventsModel)");
      }

      return GetSubjectNameFromModelType(modelType);
    }

    private static string GetSubjectNameFromModelType(Type type)
    {
      //Almost always, the name of the Ungerboeck object is the same as the model

      if (type == typeof(AllAccountsModel))
        return "Accounts";
      else if (type == typeof(AccountsProductsAndServicesModel))
        return "AccountProductsAndServices";
      else if (type == typeof(PurchaseOrderDistributionsModel))
        return "PurchaseOrderDistribution";
      else if (type == typeof(PhysicalCountInventoryBatchHeadersModel))
        return "PhysicalCountInventoryBatchHeader";
      else
        return type.Name.Substring(0, type.Name.LastIndexOf("Model"));
    }

    internal static string BuildRESTfulURLFromParameters(object parameters)
    {
      //This forms a URL of "parameter1/parameter2/..."

      var parmArray = new List<object>();

      foreach (var property in parameters.GetType().GetProperties())
      {
        parmArray.Add(parameters.GetType().GetProperty(property.Name)?.GetValue(parameters));
      }

      return $"/{string.Join("/", parmArray)}";
    }

    internal static void SetOptions<T>(ref T options) where T : new()
    {
      if (options == null) options = new T();
    }

    internal static string BuildSelect(string URL, Ungerboeck.Api.Models.Options.Base options)
    {
      if (options?.Select == null || options.Select.Count == 0) return URL;

      if (URL.Contains("?") && !URL.EndsWith("?"))
      {
        URL += "$"; //Has a query string already (usually Search, possibly Countries with *** code)
      }
      else
      {
        if (!URL.EndsWith("?")) URL += "?";
      }

      URL += "select=" + string.Join(",", options.Select);
      return URL;
    }
  }
}
