using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class SessionProposalEvaluationCriteriaResponses : Base
  {
    public SessionProposalEvaluationCriteriaResponses(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public SessionProposalEvaluationCriteriaResponsesModel Get(int sessionProposalEvaluationCriteriaResponseId)
    {
      return apiClient.Endpoints.SessionProposalEvaluationCriteriaResponses.Get( sessionProposalEvaluationCriteriaResponseId);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<SessionProposalEvaluationCriteriaResponsesModel> Search(int searchValue)
    {
      return apiClient.Endpoints.SessionProposalEvaluationCriteriaResponses.Search($"{nameof(SessionProposalEvaluationCriteriaResponsesModel.SessionProposalEvaluation)} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="sessionProposalEvaluationId">Session proposal evaluation sequence number</param>
    /// <param name="evaluationResponseId">Session proposal criteria response id</param>
    /// <returns></returns>
    public SessionProposalEvaluationCriteriaResponsesModel Add(int sessionProposalEvaluationId, int evaluationResponseId)
    {
      SessionProposalEvaluationCriteriaResponsesModel sessionProposalEvaluationCriteriaResponse = new SessionProposalEvaluationCriteriaResponsesModel()
      {
        SessionProposalEvaluation = sessionProposalEvaluationId,
        EvaluationResponse = evaluationResponseId
      };

      return apiClient.Endpoints.SessionProposalEvaluationCriteriaResponses.Add( sessionProposalEvaluationCriteriaResponse);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="sessionProposalEvaluationCriteriaResponseId">Session proposal evaluation criteria response ID</param>
    /// <param name="evaluationResponseId">Session proposal criteria response id</param>
    /// <returns></returns>
    public SessionProposalEvaluationCriteriaResponsesModel Edit(int sessionProposalEvaluationCriteriaResponseId, int evaluationResponseId)
    {
      SessionProposalEvaluationCriteriaResponsesModel sessionProposalEvaluationCriteriaResponse = apiClient.Endpoints.SessionProposalEvaluationCriteriaResponses.Get( sessionProposalEvaluationCriteriaResponseId);

      sessionProposalEvaluationCriteriaResponse.EvaluationResponse = evaluationResponseId;

      return apiClient.Endpoints.SessionProposalEvaluationCriteriaResponses.Update( sessionProposalEvaluationCriteriaResponse);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>    
    public void Delete(int sessionProposalEvaluationCriteriaResponseId)
    {
      apiClient.Endpoints.SessionProposalEvaluationCriteriaResponses.Delete( sessionProposalEvaluationCriteriaResponseId);  
    }
  }
}
