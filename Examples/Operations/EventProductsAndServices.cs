using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class EventProductsAndServices : Base
  {
    public EventProductsAndServices(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventProductsAndServicesModel Get(string orgCode, int sequenceNumber)
    {
      return apiClient.Endpoints.EventProductsAndServices.Get( orgCode, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventProductsAndServicesModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.EventProductsAndServices.Search(orgCode, $"{nameof(EventProductsAndServicesModel.EventID)} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example with the minimal required fields for an Event product
    /// </summary> 
    public EventProductsAndServicesModel AddEventProduct(string orgCode, int eventId, string productCode) {
      var myProduct = new EventProductsAndServicesModel {
        OrganizationCode = orgCode,
        EventID = eventId,
        ProductServiceCode = productCode
      };

      return apiClient.Endpoints.EventProductsAndServices.Add( myProduct);
    }

    /// <summary>
    /// A basic add example with the minimal required fields for an Exhibitor product
    /// </summary> 
    public EventProductsAndServicesModel AddExhibitorProduct(string orgCode, int exhibitorId, string productCode) {
      var myProduct = new EventProductsAndServicesModel {
        OrganizationCode = orgCode,
        ExhibitorID = exhibitorId,
        ProductServiceCode = productCode
      };

      return apiClient.Endpoints.EventProductsAndServices.Add( myProduct);
    }

    /// <summary>
    /// A basic add example with a constructed EventProductsAndServicesModel object
    /// </summary> 
    public EventProductsAndServicesModel Add(EventProductsAndServicesModel myProduct) {
      return apiClient.Endpoints.EventProductsAndServices.Add( myProduct);
    }

    /// <summary>
    /// A basic edit example with a constructed EventProductsAndServiceModel object
    /// </summary> 
    public EventProductsAndServicesModel Edit(EventProductsAndServicesModel myProduct) {
      return apiClient.Endpoints.EventProductsAndServices.Update( myProduct);
    }

  }
}
