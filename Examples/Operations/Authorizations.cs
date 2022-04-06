using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models.Options;
using Ungerboeck.Api.Models.Authorization;
using System;

namespace Examples.Operations
{
  public class Authorizations: Base
  {
    public Authorizations(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic API client creation example with JWT authorization
    /// </summary>
    /// <param name="apiUserId">The API User ID.  You get this from the API User window, found in the Ungerboeck main menu.</param>
    /// <param name="secret">The API User secret GUIDs. You get this from the API User window, found in the Ungerboeck main menu.</param>
    /// <param name="key">One of the API User key GUIDs.  You get this from the key grid on the API User window, found in the Ungerboeck main menu.</param>
    /// <param name="ungerboeckUri">Your Ungerboeck site.  This includes the 'prod' or 'test', if applicable.</param>
    /// <param name="proxiedUserID">Optional.  If the API User allows proxied users, this would be the User ID of the user you wish the API User to pretend to be.</param>
    /// <param name="minutes">This is the number of minutes before your generated JWT expires.</param>
    /// <returns></returns>    
    public ApiClient MakeApiClient(string apiUserId, string secret, string key, string ungerboeckUri, string proxiedUserID = null, int minutes = 1)
    {
    
      GetApiClientParameters(apiUserId, secret, key, proxiedUserID, ungerboeckUri, false, minutes, out Jwt auth, out Initialization initOptions);

      return new ApiClient(auth, initOptions);
    }

    /// <summary>
    /// A basic API client creation example with JWT authorization.  This version will autorefresh the token before a new call is made if it is within the refresh threshold.
    /// </summary>
    /// <param name="apiUserId">The API User ID.  You get this from the API User window, found in the Ungerboeck main menu.</param>
    /// <param name="secret">The API User secret GUIDs. You get this from the API User window, found in the Ungerboeck main menu.</param>
    /// <param name="key">One of the API User key GUIDs.  You get this from the key grid on the API User window, found in the Ungerboeck main menu.</param>
    /// <param name="ungerboeckUri">Your Ungerboeck site.  This includes the 'prod' or 'test', if applicable.</param>
    /// <param name="proxiedUserID">Optional.  If the API User allows proxied users, this would be the User ID of the user you wish the API User to pretend to be.</param>
    /// <param name="minutes">This is the number of minutes before your generated JWT expires.</param>
    /// <returns></returns>    
    public ApiClient MakeApiClientWithAutoRefresh(string apiUserId, string secret, string key, string ungerboeckUri, string proxiedUserID = null, int minutes = 1, int minimumTimeBeforeRefreshInSeconds = 0)
    {
      GetApiClientParameters(apiUserId, secret, key, proxiedUserID, ungerboeckUri, true, minutes, out Jwt auth, out Initialization initOptions, minimumTimeBeforeRefreshInSeconds);

      return new ApiClient(auth, initOptions);
    }



    private static void GetApiClientParameters(string apiUserId, string secret, string key, string proxiedUserID, string ungerboeckUri, bool useAutoRefresh, int minutes, out Jwt auth, out Initialization initOptions, int minimumTimeBeforeRefreshInSeconds = 0)
    {
      if (useAutoRefresh)
      {
        var autoRefresh = new AutoRefresh() { ExpirationInMinutes = minutes};
        
        if (minimumTimeBeforeRefreshInSeconds != 0) autoRefresh.MinimumTimeBeforeRefreshInSeconds = minimumTimeBeforeRefreshInSeconds;

        auth = new Jwt()
        {
          APIUserID = apiUserId,          
          Key = key,
          Secret = secret,
          ProxiedUserID = proxiedUserID,
          UngerboeckURI = ungerboeckUri,
          AutoRefresh = autoRefresh
          //Note: not setting Expiration here
        };        
      }
      else
      {
        auth = new Jwt()
        {
          APIUserID = apiUserId,
          Key = key,
          Secret = secret,
          ProxiedUserID = proxiedUserID,          
          UngerboeckURI = ungerboeckUri,
          Expiration = DateTime.UtcNow.AddMinutes(minutes)
        };

      }

      initOptions = new Initialization
      {
        AllowSelfSignedCertificatesForTesting = true //only use this if testing on a Self Signed local test site

      };
    }


    /// <summary>
    /// Example showing setting NotBefore (NBF).  This is useful if you wish to delay the validity of the token, or if your local clock time is heavily skewed from the server.  This value should be UTC.
    /// </summary>
    /// <param name="notBefore">Default is utcNow.</param>
    /// <param name="apiUserId">The API User ID.  You get this from the API User window, found in the Ungerboeck main menu.</param>
    /// <param name="secret">The API User secret GUIDs. You get this from the API User window, found in the Ungerboeck main menu.</param>
    /// <param name="key">One of the API User key GUIDs.  You get this from the key grid on the API User window, found in the Ungerboeck main menu.</param>
    /// <param name="ungerboeckUri">Your Ungerboeck site.  This includes the 'prod' or 'test', if applicable.</param>
    /// <param name="proxiedUserID">Optional.  If the API User allows proxied users, this would be the User ID of the user you wish the API User to pretend to be.</param>
    /// <param name="minutes">This is the number of minutes before your generated JWT expires.</param>
    /// <returns></returns>    
    public ApiClient MakeApiClientWithNotBefore(DateTime notBefore, string apiUserId, string secret, string key, string ungerboeckUri, string proxiedUserID = null, int minutes = 1)
    {

      GetApiClientParameters(apiUserId, secret, key, proxiedUserID, ungerboeckUri, false, minutes, out Jwt auth, out Initialization initOptions);

      auth.NotBefore = notBefore; //This is optional but will apply if you set it.

      return new ApiClient(auth, initOptions);
    }

  }
}
