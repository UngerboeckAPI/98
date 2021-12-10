using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Communications : Base
  {
    public Communications(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public CommunicationsModel Get(string orgCode, string accountCode, int sequenceNumber)
    {
      return apiClient.Endpoints.Communications.Get( orgCode, accountCode, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<CommunicationsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Communications.Search(orgCode, $"{nameof(CommunicationsModel.AccountCode)} eq '{searchValue}'");
    }

    /// <summary>
    /// Example of how to add a communication entry
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="accountCode">This is the account code you need to attach the communication to.</param>
    /// <param name="type">This is the type foreign key that is pulled from the CC801_COMM_TYPES table</param>
    /// <param name="value">This is the actual communication entry value (e.g. the phone number or mobile number)</param>    
    public CommunicationsModel Add(string orgCode, string accountCode, string type, string value)
    {
      //Note that sequence number isn't set for POST operations.  Ungerboeck will assign the sequence number automatically
      var myProductService = new CommunicationsModel
      {
        OrganizationCode = orgCode,
        AccountCode = accountCode,
        Type = type,
        Value = value,
        Private = Ungerboeck.Api.Models.USISDKConstants.CommunicationSensitivity.Public //You can set the sensitivity
      };

      return apiClient.Endpoints.Communications.Add( myProductService);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>  
    public CommunicationsModel Edit(string orgCode, string accountCode, int sequenceNumber, string type, string value)
    {
      var myCommunication = apiClient.Endpoints.Communications.Get( orgCode, accountCode, sequenceNumber);

      myCommunication.Type = type; //This is the type foreign key that is pulled from the CC801_COMM_TYPES table
      myCommunication.Value = value; //This is the actual communication entry value (e.g. the phone number or mobile number)

      return apiClient.Endpoints.Communications.Update( myCommunication);
    }

    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, string accountCode, int sequenceNumber)
    {
      apiClient.Endpoints.Communications.Delete( orgCode, accountCode, sequenceNumber);
    }

  }
}
