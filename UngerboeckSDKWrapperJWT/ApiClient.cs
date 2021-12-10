using System.Net.Http;

namespace Ungerboeck.Api.Sdk
{
  public class ApiClient
  {
    [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
    protected internal readonly HttpClient HttpClient;
    public readonly Ungerboeck.Api.Models.Authorization.AuthorizationInfo AuthInfo;
    public Ungerboeck.Api.Models.Options.Global GlobalOptions;
    public Ungerboeck.Api.Models.Errors.ApiErrors LastResponseError;

    [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
    private EndpointCollection endpointCollection;



    /// <summary>
    /// Use a Authorization.Jwt object to ready a new API Client, used to make calls to endpoints.  This is a process fully local to your client and does not make any HTTP calls.
    /// </summary>
    /// <param name="authorization"></param>
    /// <param name="configuration"></param>
    public ApiClient(Ungerboeck.Api.Models.Authorization.Jwt authorization, Ungerboeck.Api.Models.Options.Initialization configuration = null)
    {
      if (configuration == null) configuration = new Ungerboeck.Api.Models.Options.Initialization();
            
      var httpClientHandler = new HttpClientHandler { UseCookies = false};

      if (configuration.AllowSelfSignedCertificatesForTesting)
      {
        //DO NOT SET IN PRODUCTION!! GO AND CREATE A VALID CERTIFICATE!
        httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };              
      }
      HttpClient = new HttpClient(httpClientHandler);

      if (AuthInfo == null) AuthInfo = new Ungerboeck.Api.Models.Authorization.AuthorizationInfo();
      AuthInfo.Jwt = authorization;

      AuthUtil.InitializeAPIClient(this);

      GlobalOptions = new Ungerboeck.Api.Models.Options.Global();
    }



    public EndpointCollection Endpoints
    {
      get
      {
        if (endpointCollection == null)
        {
          endpointCollection = new EndpointCollection(this);
        }
        return endpointCollection;
      }
    }

  }
}
