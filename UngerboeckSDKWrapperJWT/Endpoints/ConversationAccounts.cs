using System.Collections.Generic;
using System.Net.Http;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Options;
using Ungerboeck.Api.Models.Subjects;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  public class ConversationAccounts : Base<ConversationAccountsModel>
  {

    protected internal ConversationAccounts(ApiClient api) : base(api) { }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<ConversationAccountsModel> Search(string searchOData, Search options = null)
    {
      return base.Search(null, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public ConversationAccountsModel Get(int id, Ungerboeck.Api.Models.Options.Subjects.ConversationAccounts options = null)
    {
      return base.Get(new { id }, options);
    }
  }
}