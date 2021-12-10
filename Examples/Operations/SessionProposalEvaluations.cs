using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Operations
{
  public class SessionProposalEvaluations : Base
  {
    public SessionProposalEvaluations(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public SessionProposalEvaluationsModel Get(int sessionProposalEvaluationId)
    {
      return apiClient.Endpoints.SessionProposalEvaluations.Get( sessionProposalEvaluationId);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<SessionProposalEvaluationsModel> Search(int searchValue)
    {
      return apiClient.Endpoints.SessionProposalEvaluations.Search($"{nameof(SessionProposalEvaluationsModel.EventRoundEvaluatorID)} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="eventRoundEvaluatorID"></param>
    /// <param name="eventRoundSessionProposalID"></param>
    /// <param name="complete">True if all criteria for the session proposal has been responded to by the evaluator, otherwise False</param>
    /// <param name="note">Any extra note text entered by the evaluator pertaining to the evaluation of the session proposal.</param>
    /// <param name="skip">True if the evaluator does not want to evaluate the session proposal.</param>
    /// <returns></returns>
    public SessionProposalEvaluationsModel Add(int eventRoundEvaluatorID, int eventRoundSessionProposalID, bool complete, string note, bool skip)
    {
      SessionProposalEvaluationsModel evl = new SessionProposalEvaluationsModel()
      {
        EventRoundEvaluatorID = eventRoundEvaluatorID,
        EventRoundSessionProposalID = eventRoundSessionProposalID,
        Complete = complete,
        Note = note,
        Skip = skip
      };

      return apiClient.Endpoints.SessionProposalEvaluations.Add( evl);
    }

    public SessionProposalEvaluationsModel Edit(int sessionProposalEvaluationId, string evaluationNote)
    {
      SessionProposalEvaluationsModel evl = apiClient.Endpoints.SessionProposalEvaluations.Get( sessionProposalEvaluationId);

      evl.Note = evaluationNote;

      return apiClient.Endpoints.SessionProposalEvaluations.Update( evl);
    }

    /// <summary>
    /// Edit example
    /// </summary> 
    public SessionProposalEvaluationsModel EditAdvanced(int sessionProposalEvaluationId)
    {

      SessionProposalEvaluationsModel evl = apiClient.Endpoints.SessionProposalEvaluations.Get( sessionProposalEvaluationId);

      evl.Note = "Looks Good";
      evl.Complete = true; // True if all criteria for the session proposal has been responded to by the evaluator, otherwise False
      evl.Skip = false; // True if the evaluator does not want to evaluate the session proposal.

      return apiClient.Endpoints.SessionProposalEvaluations.Update( evl);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>    
    public void Delete(int sessionProposalEvaluationId)
    {
      apiClient.Endpoints.SessionProposalEvaluations.Delete( sessionProposalEvaluationId);  
    }
  }
}
