using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Opportunities : Base
  {
    public Opportunities(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public OpportunitiesModel Get(string orgCode, string accountCode, int sequenceNumber)
    {
      return apiClient.Endpoints.Opportunities.Get(orgCode, accountCode, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<OpportunitiesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Opportunities.Search(orgCode, $"{nameof(OpportunitiesModel.Account)} eq '{searchValue}'");
    }


    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    /// <returns></returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<OpportunitiesModel> SearchForUserFields(string orgCode)
    {

      //For non-account user fields, the format is [User field Class]|[User field Type]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.

      //This is searching for Opportunity user fields of Issue Class = C (event sales), Issue Type code = 13, organization code = 10, and User Text 09 (TXT_09).  It will return opportunities where the value is 'N'      
      return apiClient.Endpoints.Opportunities.Search(orgCode, "C|13|10|UserText09 eq 'N'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="description"></param>
    /// <param name="accountCode"></param>
    /// <param name="issueClass">Set this to the designation of the opportunity.  You can use USISDKConstants.AccountDesignations to help you.  Example value is Ungerboeck.Api.Models.USISDKConstants.AccountDesignations.EventSales</param>
    /// <param name="issueType">Set the opportunity type using the type code.  Which User Defined Fields you use is dependent on this.</param>
    /// <param name="status">This should be set to a code value found in the opportunity statuses window.  Example value is "A"</param>    
    /// <param name="userNumber03Value">In this example, we will set User Number 03, but you can fill any user field on your Issue Type.</param>
    public OpportunitiesModel Add(string orgCode, string description, string accountCode, string issueClass, string issueType, string status, int userNumber03Value)
    {
      var myOpportunity = new OpportunitiesModel
      {
        Organization = orgCode,
        Description = description,
        Account = accountCode,
        Status = status,
        Class = issueClass,
        Type = issueType,
        UserNumber03 = userNumber03Value

        //Contact = "00111111"  'Set this to the account code of the opportunity contact if you wish for it to attach to that contact
        //Salesperson = "ALB" 'Enter in the account code of the salesperson if you wish to set this
      };

      return apiClient.Endpoints.Opportunities.Add(myOpportunity);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public OpportunitiesModel Edit(string orgCode, string accountCode, int sequenceNumber, string NewText)
    {
      var myOpportunity = apiClient.Endpoints.Opportunities.Get(orgCode, accountCode, sequenceNumber);

      myOpportunity.Description = NewText;

      return apiClient.Endpoints.Opportunities.Update(myOpportunity);
    }

    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, string accountCode, int sequenceNumber)
    {
      apiClient.Endpoints.Opportunities.Delete(orgCode, accountCode, sequenceNumber);
    }

    /// <summary>
    /// Basic edit - which updates the status to Canclled along with reason details
    /// </summary>
    /// <param name="orgCode">Organization of opportunity</param>
    /// <param name="accountCode">Account code of opportunity</param>
    /// <param name="sequenceNumber">Sequence of opportunity</param>
    /// <param name="CancelReason">Cancellation reason 1 : required reason to cancel the opportunity</param>
    /// <param name="CancelNote">Cancellation Note 1 : optional note 1 while cancelling opportunity</param>
    /// <param name="CancelReason2">Cancellation reason 2 : optional reason 2 to cancel the opportunity</param>
    /// <param name="CancelNote2">Cancellation Note 2: optional note 2 while cancelling opportunity</param>
    /// <param name="CancelReason3">Cancellation reason 3: optional reason 3 to cancel the opportunity</param>
    /// <param name="CancelNote3">Cancellation Note 3: optional note 3 while cancelling opportunity</param>
    /// <returns>single updated OpportunitiesModel</returns>
    public OpportunitiesModel EditCancelOpportunity(string orgCode, string accountCode, int sequenceNumber, string CancelReason, string CancelNote = "", string CancelReason2 = "", string CancelNote2 = "", string CancelReason3 = "", string CancelNote3 = "")
    {
      var myOpportunity = apiClient.Endpoints.Opportunities.Get(orgCode, accountCode, sequenceNumber);

      myOpportunity.Status = "X"; //Closed or Archieved - you can find this code on opportunity status window
      myOpportunity.CancellationReason1 = "R4"; //you can find this on cancellation reasons window

      if (!string.IsNullOrEmpty(CancelNote))
        myOpportunity.CancellationNote = CancelNote;

      if (!string.IsNullOrEmpty(CancelReason2))
      {
        myOpportunity.CancellationReason2 = CancelReason2;
        myOpportunity.CancellationNote2 = CancelNote2;
      }
      if (!string.IsNullOrEmpty(CancelReason3))
      {
        myOpportunity.CancellationReason3 = CancelReason3;
        myOpportunity.CancellationNote3 = CancelNote3;
      }
      return apiClient.Endpoints.Opportunities.Update(myOpportunity);
    }

  }
}
