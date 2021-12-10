using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Operations
{
  public class OrderRegistrants : Base
  {
    public OrderRegistrants(ApiClient apiClient) : base(apiClient)
    {
    }
    public OrderRegistrantsModel Get(string orgCode, int registrantSequenceNbr)
    {
      return apiClient.Endpoints.OrderRegistrants.Get( orgCode, registrantSequenceNbr);
    }

    /// <summary>
    /// Retrieve all order registrants per event. 
    /// </summary> 
    public Ungerboeck.Api.Models.Search.SearchResponse<OrderRegistrantsModel> GetByEvent(string orgCode, int eventID)
    {
      return apiClient.Endpoints.OrderRegistrants.Search(orgCode, $"Event eq {eventID}");
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<OrderRegistrantsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.OrderRegistrants.Search(orgCode, $"{nameof(OrderRegistrantsModel.Event)} eq {searchValue}");
    }

    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    /// <returns></returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<OrderRegistrantsModel> SearchForUserFields(string orgCode)
    {
      
      //For non-account user fields, the format is [User field Class]|[User field Type]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.

      //This is searching for Order user fields of Issue Class = R (registration), Issue Type code = 01, organization code = 10, and User Text 02 (TXT_02).  It will return registrants where the value is '2'      
      return apiClient.Endpoints.OrderRegistrants.Search(orgCode, "R|01|10|UserText02 eq '2'");
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public OrderRegistrantsModel Edit(string orgCode, int registrantSequenceNbr, string strNewUserFieldText)
    {
      var myOrderRegistrant = apiClient.Endpoints.OrderRegistrants.Get( orgCode, registrantSequenceNbr);

      myOrderRegistrant.RegistrantUserFields.UserText01 = strNewUserFieldText;

      return apiClient.Endpoints.OrderRegistrants.Update( myOrderRegistrant);
    }

    /// <summary>
    /// A edit example updating approval status
    /// </summary> 
    /// <param name="orgCode">Organization code</param>
    /// <param name="registrantSequenceNbr">Registration Order Sequence Number</param>
    /// <param name="approvalAction">Action for the Registration Approval. Either 'A' for Approved or 'R' for Rejected</param>
    /// <param name="approvalLevel">Integer value representing the Approval Level</param>
    /// <param name="approvalComment">string value for comments regarding the approval or rejection</param>
    public HttpResponseMessage EditUpdatingApprovalStatus(string orgCode, int registrantSequenceNbr, string approvalAction, int approvalLevel, string approvalComment)
    {
      var myOrderRegistrantApproval = new RegistrationApprovalsModel
      {
        OrganizationCode = orgCode,
        RegistrantSequenceNbr = registrantSequenceNbr,
        RegistrantApprovalAction = approvalAction,
        RegistrantApprovalLevel = approvalLevel,
        ApprovalComment = approvalComment
      };

      return apiClient.Endpoints.OrderRegistrants.SetRegistrantApproval( myOrderRegistrantApproval);      
    }

    /// <summary>
    /// This is an example of check-in registrant order
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="registrantSequenceNbr">Registration Order Sequence Number</param>
    /// /// <param name="eventId">Event ID</param>
    public void CheckIn(string orgCode, int registrantSequenceNbr, int eventId)
    {
      
      apiClient.Endpoints.OrderRegistrants.CheckIn( orgCode, registrantSequenceNbr, eventId);
    }

    /// <summary>
    /// This is an example of clear check-in registrant order
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="registrantSequenceNbr">Registration Order Sequence Number</param>
    /// /// <param name="eventId">Event ID</param>
    public void ClearCheckIn(string orgCode, int registrantSequenceNbr, int eventId)
    {
      
      apiClient.Endpoints.OrderRegistrants.ClearCheckIn( orgCode, registrantSequenceNbr, eventId);
    }
  }
}
