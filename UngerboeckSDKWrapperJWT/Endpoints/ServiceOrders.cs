using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// Find endpoint calls for this subject here.
  /// </summary>
  public class ServiceOrders : Base<ServiceOrdersModel>
  {
    protected internal ServiceOrders(ApiClient api) : base(api) { }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="orgCode">Fill this with the Organization Code in which the search will take place.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public new Ungerboeck.Api.Models.Search.SearchResponse<ServiceOrdersModel> Search(string orgCode, string searchOData, Search options = null)
    {
      return base.SearchSync(orgCode, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to async search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="orgCode">Fill this with the Organization Code in which the search will take place.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public new Task<Ungerboeck.Api.Models.Search.SearchResponse<ServiceOrdersModel>> SearchAsync(string orgCode, string searchOData, Search options = null)
    {
      return base.SearchAsync(orgCode, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public ServiceOrdersModel Get(string orgCode, int orderNumber, Ungerboeck.Api.Models.Options.Subjects.ServiceOrders options = null)
    {
      return base.GetSync(new { orgCode, orderNumber }, options);
    }

    /// <summary>
    /// Use this async endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public Task<ServiceOrdersModel> GetAsync(string orgCode, int orderNumber, Ungerboeck.Api.Models.Options.Subjects.ServiceOrders options = null)
    {
      return base.GetAsync(new { orgCode, orderNumber }, options);
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public ServiceOrdersModel Update(ServiceOrdersModel model, Ungerboeck.Api.Models.Options.Subjects.ServiceOrders options = null)
    {
      return base.UpdateSync(new { model.OrganizationCode, model.OrderNumber }, model, options);
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public Task<ServiceOrdersModel> UpdateAsync(ServiceOrdersModel model, Ungerboeck.Api.Models.Options.Subjects.ServiceOrders options = null)
    {
      return base.UpdateAsync(new { model.OrganizationCode, model.OrderNumber }, model, options);
    }

    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public ServiceOrdersModel Add(ServiceOrdersModel model, Ungerboeck.Api.Models.Options.Subjects.ServiceOrders options = null)
    {
      return base.AddSync(model, options);
    }

    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public Task<ServiceOrdersModel> AddAsync(ServiceOrdersModel model, Ungerboeck.Api.Models.Options.Subjects.ServiceOrders options = null)
    {
      return base.AddAsync(model, options);
    }

    /// <summary>
    /// Custom endpoint.  Use this action endpoint to set all work orders on a service order to status Complete.  This process replicates the "Complete Work Orders" functionality found in v20's "Service Orders" window.
    /// </summary>
    /// <param name="orgCode">The organization code of the service order.</param>
    /// <param name="orderNumber">The Order Number of the service order.</param>    
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>HttpPResponseMessage indicating success</returns>
    public HttpResponseMessage CompleteWorkOrders(string orgCode, int orderNumber, Ungerboeck.Api.Models.Options.Subjects.ServiceOrders options = null)
    {
      var task = CompleteWorkOrdersAsync(orgCode, orderNumber, options);
      return CustomSync(task);
    }

    /// <summary>
    /// Custom endpoint.  Use this action async endpoint to set all work orders on a service order to status Complete.  This process replicates the "Complete Work Orders" functionality found in v20's "Service Orders" window.
    /// </summary>
    /// <param name="orgCode">The organization code of the service order.</param>
    /// <param name="orderNumber">The Order Number of the service order.</param>    
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>HttpPResponseMessage indicating success</returns>
    public Task<HttpResponseMessage> CompleteWorkOrdersAsync(string orgCode, int orderNumber, Ungerboeck.Api.Models.Options.Subjects.ServiceOrders options = null)
    {
      System.Threading.Tasks.Task<HttpResponseMessage> response = PutAsync<HttpResponseMessage>(Client,
        $"ServiceOrders/{orgCode}/{orderNumber}/CompleteWorkOrders", null, options);

      return response;
    }

    /// <summary>
    /// Custom endpoint.  Use this action endpoint to move multiple Service Orders to a different event or a different function on the same event.  This process replicates the "Move Order" functionality found in Ungerboeck's "Service Orders" window.  If one or more orders fails to move, this endpoint will return a MoveOrdersBulkErrorsModel object.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>If one or more orders fails to move, this endpoint will return a MoveOrdersBulkErrorsModel object.</returns>
    public IEnumerable<MoveOrdersBulkErrorsModel> MoveOrdersBulk(MoveOrdersBulkModel moveBulkRegistrationOrdersInfo, Ungerboeck.Api.Models.Options.Subjects.ServiceOrders options = null)
    {
      var moveOrdersBulkErrorsTask = MoveOrdersBulkAsync(moveBulkRegistrationOrdersInfo, options);

      return CustomSync(moveOrdersBulkErrorsTask);
    }

    /// <summary>
    /// Custom endpoint.  Use this action endpoint to move multiple Service Orders to a different event or a different function on the same event.  This process replicates the "Move Order" functionality found in Ungerboeck's "Service Orders" window.  If one or more orders fails to move, this endpoint will return a MoveOrdersBulkErrorsModel object.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>If one or more orders fails to move, this endpoint will return a MoveOrdersBulkErrorsModel object.</returns>
    public Task<IEnumerable<MoveOrdersBulkErrorsModel>> MoveOrdersBulkAsync(MoveOrdersBulkModel moveBulkRegistrationOrdersInfo, Ungerboeck.Api.Models.Options.Subjects.ServiceOrders options = null)
    {
      System.Threading.Tasks.Task<IEnumerable<MoveOrdersBulkErrorsModel>> moveOrdersBulkErrorsTask =
        PutAsync<MoveOrdersBulkModel, IEnumerable<MoveOrdersBulkErrorsModel>>
                                (Client, "ServiceOrders/MoveOrdersBulk", moveBulkRegistrationOrdersInfo, options);

      return moveOrdersBulkErrorsTask;
    }

    /// <summary>
    /// Custom endpoint.  Use this action endpoint to move Service Orders to a different event or a different function on the same event.  This process replicates the "Move Order" functionality found in Ungerboeck's "Service Orders" window.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>Nothing if successful, response error message on fail.</returns>
    public HttpResponseMessage MoveOrder(MoveOrderModel moveServiceOrderInfo, Ungerboeck.Api.Models.Options.Subjects.ServiceOrders options = null)
    {
      System.Threading.Tasks.Task<HttpResponseMessage> response = MoveOrderAsync(moveServiceOrderInfo, options);
      return CustomSync(response);
    }

    /// <summary>
    /// Custom endpoint.  Use this action endpoint to move Service Orders to a different event or a different function on the same event.  This process replicates the "Move Order" functionality found in Ungerboeck's "Service Orders" window.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>Nothing if successful, response error message on fail.</returns>
    public Task<HttpResponseMessage> MoveOrderAsync(MoveOrderModel moveServiceOrderInfo, Ungerboeck.Api.Models.Options.Subjects.ServiceOrders options = null)
    {
      System.Threading.Tasks.Task<HttpResponseMessage> response = PutAsync<MoveOrderModel, HttpResponseMessage>(Client, "ServiceOrders/MoveOrder", moveServiceOrderInfo, options);
      return response;
    }
  }
}
