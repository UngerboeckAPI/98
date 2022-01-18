using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;

/// <summary>
/// Find endpoint calls for this subject here.
/// </summary>
namespace Ungerboeck.Api.Sdk.Endpoints
{
  public class EventTaskDetails : Base<EventTaskDetailsModel>
  {
    protected internal EventTaskDetails(ApiClient api) : base(api) { }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public EventTaskDetailsModel Get(int eventTaskConfigurationID, Ungerboeck.Api.Models.Options.Subjects.EventTaskDetails options = null)
    {
      return base.Get(new {eventTaskConfigurationID }, options);
    }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<EventTaskDetailsModel> Search(string searchOData, Search options = null)
    {
      return base.Search(null, searchOData, options);
    }

  }
}

