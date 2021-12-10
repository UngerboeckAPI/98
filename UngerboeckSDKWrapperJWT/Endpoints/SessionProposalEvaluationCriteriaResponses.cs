using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// Find endpoint calls for this subject here.
  /// </summary>
  public class SessionProposalEvaluationCriteriaResponses : Base<SessionProposalEvaluationCriteriaResponsesModel>
  {
    protected internal SessionProposalEvaluationCriteriaResponses(ApiClient api) : base(api) { }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<SessionProposalEvaluationCriteriaResponsesModel> Search(string searchOData, Search options = null)
    {
      return base.Search(null, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public SessionProposalEvaluationCriteriaResponsesModel Get(int abstractEvaluationResponseId, Ungerboeck.Api.Models.Options.Subjects.SessionProposalEvaluationCriteriaResponses options = null)
    {
      return base.Get(new { abstractEvaluationResponseId }, options);
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public SessionProposalEvaluationCriteriaResponsesModel Update(SessionProposalEvaluationCriteriaResponsesModel model, Ungerboeck.Api.Models.Options.Subjects.SessionProposalEvaluationCriteriaResponses options = null)
    {
      return base.Update(new { model.Id }, model, options);
    }

    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public SessionProposalEvaluationCriteriaResponsesModel Add(SessionProposalEvaluationCriteriaResponsesModel model, Ungerboeck.Api.Models.Options.Subjects.SessionProposalEvaluationCriteriaResponses options = null)
    {
      return base.Add(model, options);
    }

    /// <summary>
    /// Use this endpoint to delete a single entry of this subject.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>Nothing if successful.</returns>
    public HttpResponseMessage Delete(int abstractEvaluationResponseId, Ungerboeck.Api.Models.Options.Subjects.SessionProposalEvaluationCriteriaResponses options = null)
    {
      return base.Delete(new { abstractEvaluationResponseId }, options);
    }
  }
}
