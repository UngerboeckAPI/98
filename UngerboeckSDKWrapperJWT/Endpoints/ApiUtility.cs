using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// This contains endpoints that are helpful for meta-API use.
  /// </summary>
  public class ApiUtility : Base<UngerboeckModel>
  {
    protected internal ApiUtility(ApiClient api) : base(api) { }

    /// <summary>
    /// This endpoint can be used to check authorization of a user (i.e., you wish to make a login/access page for users for your website that also have Ungerboeck users)
    /// </summary>
    /// <param name="userIdToCheck">The User Id in which you wish to verify</param>
    /// <param name="userPasswordToCheck">The password of the user you wish to verify</param>
    /// <param name="options"></param>
    /// <returns>An UngerboeckAuthenticationCheck which shows the results</returns>
    public UngerboeckAuthenticationCheck CheckUngerboeckUserAuthentication(string userIdToCheck, string userPasswordToCheck, Ungerboeck.Api.Models.Options.Subjects.ApiUtility options = null)
    {
      var task = CheckUngerboeckUserAuthenticationAsync(userIdToCheck, userPasswordToCheck, options);
      return CustomSync(task);
    }

    /// <summary>
    /// This endpoint can be used to check authorization of a user (i.e., you wish to make a login/access page for users for your website that also have Ungerboeck users)
    /// </summary>
    /// <param name="userIdToCheck">The User Id in which you wish to verify</param>
    /// <param name="userPasswordToCheck">The password of the user you wish to verify</param>
    /// <param name="options"></param>
    /// <returns>An UngerboeckAuthenticationCheck which shows the results</returns>
    public Task<UngerboeckAuthenticationCheck> CheckUngerboeckUserAuthenticationAsync(string userIdToCheck, string userPasswordToCheck, Ungerboeck.Api.Models.Options.Subjects.ApiUtility options = null)
    {
      if (options == null) options = new Models.Options.Subjects.ApiUtility();

      if (string.IsNullOrWhiteSpace(options.CheckAuthenticationUserId) || string.IsNullOrWhiteSpace(options.CheckAuthenticationUserPassword))
      {
        options.CheckAuthenticationUserId = userIdToCheck;
        options.CheckAuthenticationUserPassword = userPasswordToCheck;
      }

        return GetAsync<UngerboeckAuthenticationCheck>(Client, "sdk_initialize", options);
    }

    protected override Dictionary<string, string> GetSubjectHeaders(ref Dictionary<string, string> headers, Models.Options.Base baseOptions)
    {
      var options = GetOptions<Models.Options.Subjects.ApiUtility>(baseOptions);

      if (options.CheckAuthenticationUserId != null || options.CheckAuthenticationUserPassword != null)
          headers.Add("CheckAuthentication", Convert.ToBase64String(
                System.Text.Encoding.ASCII.GetBytes($"{options.CheckAuthenticationUserId}:{options.CheckAuthenticationUserPassword}")));

      return headers;
    }
  }
}
