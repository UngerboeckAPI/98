using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Net.Http;
using System.Net.Http.Headers;
using Ungerboeck.Api.Models.Authorization;


namespace Ungerboeck.Api.Sdk
{

  internal class AuthUtil
  {

    private static string GenerateJWT(string userId, string key, string secret, DateTime expiration, string proxyUserId = null)
    {
      var secretGuid = new Guid(secret);
      var symmetricKey = secretGuid.ToByteArray();
      var tokenHandler = new JwtSecurityTokenHandler();

      var utcNow = DateTime.UtcNow;

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Issuer = userId,
        IssuedAt = utcNow,
        NotBefore = utcNow,
        Expires = expiration,
        SigningCredentials = new SigningCredentials(
          new SymmetricSecurityKey(symmetricKey),
          SecurityAlgorithms.HmacSha256Signature),
        Claims = new Dictionary<string, object>() { { "key", key } }
      };


      if (proxyUserId != null)
      {
        tokenDescriptor.Subject = new ClaimsIdentity(new[]
          {
            new Claim("sub", proxyUserId)
        });
      }

      var securityToken = tokenHandler.CreateToken(tokenDescriptor);
      var token = tokenHandler.WriteToken(securityToken);

      return token;
    }

    internal static void InitializeAPIClient(ApiClient client)
    {
      if (ShouldAutoRefresh(client))
      {
        client.AuthInfo.Jwt.Expiration = GetExpiration(client.AuthInfo.Jwt.AutoRefresh);
      }

      ValidateSettings(client);

      SetJWT(client);

      client.HttpClient.BaseAddress = new Uri(client.AuthInfo.Jwt.UngerboeckURI); // Base address of the Ungerboeck server
      client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    private static void ValidateSettings(ApiClient client)
    {
      if (string.IsNullOrWhiteSpace(client.AuthInfo.Jwt.APIUserID)) throw new Exception("The APIUserID authorization property is required.");
      if (string.IsNullOrWhiteSpace(client.AuthInfo.Jwt.Secret)) throw new Exception("The Secret authorization property is required");
      if (string.IsNullOrWhiteSpace(client.AuthInfo.Jwt.Key)) throw new Exception("The Key authorization property is required");
      if (string.IsNullOrWhiteSpace(client.AuthInfo.Jwt.UngerboeckURI)) throw new Exception("The UngerboeckURI authorization property is required");

      if (!Guid.TryParse(client.AuthInfo.Jwt.Secret, out _)) throw new Exception("Your Secret authorization is not a GUID.  Fill this in with the API User's Secret GUID.");
      if (!Guid.TryParse(client.AuthInfo.Jwt.Key, out _)) throw new Exception("Your Key authorization is not a GUID.  Fill this in with one of the API User's Key GUIDs.");

      if (client.AuthInfo.Jwt.Expiration <= DateTime.UtcNow) throw new Exception("Either Authorization.Jwt.Expiration must be set and be later than current UTC time or Authorization.Jwt.AutoRefresh must be set.");
    }

    private static void SetJWT(ApiClient client)
    {
      string jwt = GenerateJWT(client.AuthInfo.Jwt.APIUserID, client.AuthInfo.Jwt.Key, client.AuthInfo.Jwt.Secret, client.AuthInfo.Jwt.Expiration, client.AuthInfo.Jwt.ProxiedUserID);
      client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
      client.AuthInfo.Jwt.Jwt = jwt;
    }

    internal static void RefreshJWT(ApiClient client)
    {
      int minimumTimeBeforeRefreshInSeconds = GetMinimumTimeBeforeRefresh(client.AuthInfo.Jwt.AutoRefresh);


      if (client.AuthInfo.Jwt.Expiration <= DateTime.UtcNow.AddSeconds(minimumTimeBeforeRefreshInSeconds))
      {
        client.AuthInfo.Jwt.Expiration = GetExpiration(client.AuthInfo.Jwt.AutoRefresh);
        SetJWT(client);
      }

    }

    internal static bool ShouldAutoRefresh(ApiClient client)
    {
      return client.AuthInfo.Jwt != null && client.AuthInfo.Jwt.AutoRefresh != null &&
        (client.AuthInfo.Jwt.AutoRefresh.ExpirationInMinutes > 0 || client.AuthInfo.Jwt.AutoRefresh.MinimumTimeBeforeRefreshInSeconds > 0);
    }

    private static int GetMinimumTimeBeforeRefresh(AutoRefresh autoRefresh)
    {
      if (autoRefresh != null)
      {
        if (autoRefresh.MinimumTimeBeforeRefreshInSeconds > 0) return autoRefresh.MinimumTimeBeforeRefreshInSeconds;
      }

      return 30; //Default
    }

    private static DateTime GetExpiration(AutoRefresh autoRefresh)
    {
      int expirationInMinutes = 2; //Default

      if (autoRefresh != null)
      {
        if (autoRefresh.ExpirationInMinutes > 0) expirationInMinutes = autoRefresh.ExpirationInMinutes;
      }

      return DateTime.UtcNow.AddMinutes(expirationInMinutes);
    }
  }

}