using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;
using System.Threading.Tasks;
using Ungerboeck.Api.Models.Search;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// Find endpoint calls for this subject here.
  /// </summary>
  public class FulfillmentOrderItems : Base<FulfillmentOrderItemsModel>
  {
    protected internal FulfillmentOrderItems(ApiClient api) : base(api) { }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="orgCode">Fill this with the Organization Code in which the search will take place.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public new SearchResponse<FulfillmentOrderItemsModel> Search(string orgCode, string searchOData, Search options = null)
    {
      return SearchAsync(orgCode, searchOData, options).Result;
    }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public FulfillmentOrderItemsModel Get(string orgCode, int orderNumber, int orderLineNumber, Ungerboeck.Api.Models.Options.Subjects.FulfillmentOrderItems options = null)
    {
      return GetAsync(new { orgCode, orderNumber, orderLineNumber }, options).Result;
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public FulfillmentOrderItemsModel Update(FulfillmentOrderItemsModel model, Ungerboeck.Api.Models.Options.Subjects.FulfillmentOrderItems options = null)
    {
      return UpdateAsync(new { model.OrganizationCode, model.OrderNumber, model.OrderLineNumber }, model, options).Result;
    }

    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public FulfillmentOrderItemsModel Add(FulfillmentOrderItemsModel model, Ungerboeck.Api.Models.Options.Subjects.FulfillmentOrderItems options = null)
    {
      return base.AddAsync(model, options).Result;
    }

    /// <summary>
    /// Use this endpoint to delete a single entry of this subject.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>Nothing if successful.</returns>
    public HttpResponseMessage Delete(string orgCode, int orderNumber, int orderLineNumber, Ungerboeck.Api.Models.Options.Subjects.FulfillmentOrderItems options = null)
    {
      return DeleteAsync(new { orgCode, orderNumber, orderLineNumber }, options).Result;
    }

  }
}
