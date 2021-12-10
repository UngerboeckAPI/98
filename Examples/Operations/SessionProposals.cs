using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Operations
{
  public class SessionProposals : Base
  {
    public SessionProposals(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public SessionProposalsModel Get(string orgCode, int sessionProposalId)
    {
      return apiClient.Endpoints.SessionProposals.Get( orgCode, sessionProposalId);
    }


    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<SessionProposalsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.SessionProposals.Search(orgCode, $"{nameof(SessionProposalsModel.Event)} eq {searchValue}");
    }

    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    /// <returns></returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<SessionProposalsModel> SearchForUserFields(string orgCode)
    {
      
      //For non-account user fields, the format is [User field Class]|[User field Type]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.

      //This is searching for Session Proposal user fields of Issue Class = B, Issue Type code = 08, organization code = 10, and User Text 02 (Text02).  It will return session proposal where the address is 'UPI test address'      
      return apiClient.Endpoints.SessionProposals.Search(orgCode, "B|KB|10|UserText02 eq 'SilverLight Garbage 2018'");
    }
    
    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="eventId">Event ID of the event the session proposal is associated with.</param>
    /// <param name="sessionProposalTitle">Title of the session proposal</param>
    /// <param name="statusId">Status of an session proposal</param>
    /// <param name="presentationTypeId">Sequence number of the presentation type associated with the session proposal</param>
    /// <param name="topicId">Id of the topic the session proposal is associated with</param>
    /// <param name="htmlText">Session proposal text with all of its HTML formatting codes</param>
    /// <param name="submitterId">Submitter account code</param>
    /// <param name="submissionForm">Session proposal web configuration ID</param>
    /// <returns></returns>
    public SessionProposalsModel Add(string orgCode, int eventId, string sessionProposalTitle, int statusId, int presentationTypeId, int topicId, string htmlText, string submitterId, int submissionForm)
    {
      SessionProposalsModel sessionProposal = new SessionProposalsModel()
      {
        OrganizationCode = orgCode,
        Event = eventId,
        SessionProposalTitle = sessionProposalTitle,
        Status = statusId,
        PresentationType = presentationTypeId,
        Topic = topicId,
        HTMLText = htmlText,
        Submitter = submitterId,
        SubmissionForm = submissionForm
      };

      return apiClient.Endpoints.SessionProposals.Add( sessionProposal);
    }


    /// <summary>
    /// Here's how to add a user field set with values to a new event
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="eventId"></param>
    /// <param name="sessionProposalTitle"></param>
    /// <param name="statusId">Status of an session proposal</param>
    /// <param name="presentationTypeId">Sequence number of the presentation type associated with the session proposal</param>
    /// <param name="topicId">Id of the topic the session proposal is associated with</param>
    /// <param name="htmlText">Session proposal text with all of its HTML formatting codes</param>
    /// <param name="submitterId">Submitter account code</param>
    /// <param name="submissionForm">Session proposal web configuration ID</param>
    /// <param name="issueType"></param>
    /// <param name="userText02Value">This is just an example of the user fields you can set</param>
    public SessionProposalsModel AddWithUserFields(string orgCode, int eventId, string sessionProposalTitle, int statusId, int presentationTypeId, int topicId, string htmlText, string submitterId, int submissionForm, string issueType, string userText02Value)
    {
      SessionProposalsModel sessionProposal = new SessionProposalsModel()
      {
        OrganizationCode = orgCode,
        Event = eventId,
        SessionProposalTitle = sessionProposalTitle,
        Status = statusId,
        PresentationType = presentationTypeId,
        Topic = topicId,
        HTMLText = htmlText,
        Submitter = submitterId,
        SubmissionForm = submissionForm
      };

      sessionProposal.SessionProposalUserFields = new UserFields
      {
        Type = issueType,
        UserText02 = userText02Value //Set the value in the user field property (here we are using UDF address field)
      };

      return apiClient.Endpoints.SessionProposals.Add( sessionProposal);
    }


    /// <summary>
    /// A basic edit example
    /// </summary> 
    public SessionProposalsModel Edit(string orgCode, int sessionProposalId, string newTitle, string newUserText)
    {
      SessionProposalsModel sessionProposal = apiClient.Endpoints.SessionProposals.Get( orgCode, sessionProposalId);

      sessionProposal.SessionProposalTitle = newTitle;

      //User Defined Fields can also be changed.  The set picked here is arbitrary, but we recommend selecting based on the IssueType property.
      if(sessionProposal.SessionProposalUserFields == null)
      {
        sessionProposal.SessionProposalUserFields = new UserFields();
      }
      sessionProposal.SessionProposalUserFields.UserText02 = newUserText; // set UDF address field

      return apiClient.Endpoints.SessionProposals.Update( sessionProposal);
    }

    public SessionProposalsModel EditAdvanced(string orgCode, int sessionProposalId)
    {

      SessionProposalsModel sessionProposal = apiClient.Endpoints.SessionProposals.Get( orgCode, sessionProposalId);

      sessionProposal.Status = 89; // change status to approved

      return apiClient.Endpoints.SessionProposals.Update( sessionProposal);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>    
    public void Delete(string orgCode, int sessionProposalId)
    {
      apiClient.Endpoints.SessionProposals.Delete( orgCode, sessionProposalId);  
    }

    /// <summary>
    /// This is an example of assign evaluators
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="sessionProposalId">Session proposal sequence number</param>
    /// /// <param name="evaluatorsAccountCode">Assigned evaluator account code. Multiple values can be comma delimited</param>
    public void AssignEvaluators(string orgCode, int sessionProposalId, string evaluatorsAccountCode)
    {
      SessionProposalsAssignEvaluatorsModel assignEvaluator = new SessionProposalsAssignEvaluatorsModel()
      {
        EvaluatorAccountCode = evaluatorsAccountCode
      };

      
      apiClient.Endpoints.SessionProposals.AssignEvaluators( orgCode, sessionProposalId, assignEvaluator);
    }

  }
}
