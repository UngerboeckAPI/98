using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;
using System.Threading.Tasks;
using Ungerboeck.Api.Models.Search;
using System;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// Find endpoint calls for this subject here.
  /// </summary>
  public class ServiceOrderItems : Base<ServiceOrderItemsModel>
  {
    protected internal ServiceOrderItems(ApiClient api) : base(api) { }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="orgCode">Fill this with the Organization Code in which the search will take place.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public new SearchResponse<ServiceOrderItemsModel> Search(string orgCode, string searchOData, Search options = null)
    {
      return SearchSync(orgCode, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to run an aync search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="orgCode">Fill this with the Organization Code in which the search will take place.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public new Task<SearchResponse<ServiceOrderItemsModel>> SearchAsync(string orgCode, string searchOData, Search options = null)
    {
      return base.SearchAsync(orgCode, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public ServiceOrderItemsModel Get(string orgCode, int orderNumber, int orderLineNumber, Ungerboeck.Api.Models.Options.Subjects.ServiceOrderItems options = null)
    {
      return GetSync(new { orgCode, orderNumber, orderLineNumber }, options);
    }

    /// <summary>
    /// Use this async endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public Task<ServiceOrderItemsModel> GetAsync(string orgCode, int orderNumber, int orderLineNumber, Ungerboeck.Api.Models.Options.Subjects.ServiceOrderItems options = null)
    {
      return base.GetAsync(new { orgCode, orderNumber, orderLineNumber }, options);
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public ServiceOrderItemsModel Update(ServiceOrderItemsModel model, Ungerboeck.Api.Models.Options.Subjects.ServiceOrderItems options = null)
    {
      return UpdateSync(new { model.OrganizationCode, model.OrderNumber, model.OrderLineNumber }, model, options);
    }

    /// <summary>
    /// Use this async endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public Task<ServiceOrderItemsModel> UpdateAsync(ServiceOrderItemsModel model, Ungerboeck.Api.Models.Options.Subjects.ServiceOrderItems options = null)
    {
      return base.UpdateAsync(new { model.OrganizationCode, model.OrderNumber, model.OrderLineNumber }, model, options);
    }

    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public ServiceOrderItemsModel Add(ServiceOrderItemsModel model, Ungerboeck.Api.Models.Options.Subjects.ServiceOrderItems options = null)
    {
      return base.AddSync(model, options);
    }


    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public Task<ServiceOrderItemsModel> AddAsync(ServiceOrderItemsModel model, Ungerboeck.Api.Models.Options.Subjects.ServiceOrderItems options = null)
    {
      return base.AddAsync(model, options);
    }

    /// <summary>
    /// Use this endpoint to delete a single entry of this subject.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>Nothing if successful.</returns>
    public HttpResponseMessage Delete(string orgCode, int orderNumber, int orderLineNumber, Ungerboeck.Api.Models.Options.Subjects.ServiceOrderItems options = null)
    {
      return DeleteSync(new { orgCode, orderNumber, orderLineNumber }, options);
    }

    /// <summary>
    /// Use this async endpoint to delete a single entry of this subject.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>Nothing if successful.</returns>
    public Task<HttpResponseMessage> DeleteAsync(string orgCode, int orderNumber, int orderLineNumber, Ungerboeck.Api.Models.Options.Subjects.ServiceOrderItems options = null)
    {
      return base.DeleteAsync(new { orgCode, orderNumber, orderLineNumber }, options);
    }

    /// <summary>
    /// You can do multiple save operations in one transaction.  See the API Help sandbox for a list of what has Bulk.
    /// </summary>
    /// <param name="bulkRequestModel">This contains the list of bulk items, as well as the choice to continue on failure of a save.</param>
    /// <returns>BuldResponseModel, containing the results of the bulk process</returns>
    public Ungerboeck.Api.Models.Bulk.BulkResponseModel Bulk(Ungerboeck.Api.Models.Bulk.BulkRequestModel bulkRequestModel, Ungerboeck.Api.Models.Options.Subjects.ServiceOrderItems options = null)
    {
      return BulkSync(bulkRequestModel, options);
    }

    /// <summary>
    /// You can do multiple save operations in one transaction.  See the API Help sandbox for a list of what has Bulk.
    /// </summary>
    /// <param name="bulkRequestModel">This contains the list of bulk items, as well as the choice to continue on failure of a save.</param>
    /// <returns>BuldResponseModel, containing the results of the bulk process</returns>
    public Task<Ungerboeck.Api.Models.Bulk.BulkResponseModel> BulkAsync(Ungerboeck.Api.Models.Bulk.BulkRequestModel bulkRequestModel, Ungerboeck.Api.Models.Options.Subjects.ServiceOrderItems options = null)
    {
      return base.BulkAsync(bulkRequestModel, options);
    }

    /// <summary>
    /// Custom endpoint.  Add a new item to an existing package from the price list.
    /// </summary>
    /// <param name="packageItem">A SaveNewItemToExistingPackageModel, includes Price list item Seqence and package header order Line.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A new service order item model</returns>
    public ServiceOrderItemsModel SaveNewItemToExistingPackage(SaveNewItemToExistingPackageModel packageItem, Ungerboeck.Api.Models.Options.Subjects.ServiceOrderItems options = null)
    {      
      var task = SaveNewItemToExistingPackageAsync(packageItem, options);
      return CustomSync(task);
    }
    
    /// <summary>
    /// Custom endpoint.  Async add a new item to an existing package from the price list.
    /// </summary>
    /// <param name="packageItem">A SaveNewItemToExistingPackageModel, includes Price list item Seqence and package header order Line.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A new service order item model</returns>
    public Task<ServiceOrderItemsModel> SaveNewItemToExistingPackageAsync(SaveNewItemToExistingPackageModel packageItem, Ungerboeck.Api.Models.Options.Subjects.ServiceOrderItems options = null)
    {
      Task<ServiceOrderItemsModel> response
            = PostAsync<SaveNewItemToExistingPackageModel, ServiceOrderItemsModel>(Client, $"ServiceOrderItems/SaveNewItemToExistingPackage/", packageItem, options);
      return response;
    }
  }
}
