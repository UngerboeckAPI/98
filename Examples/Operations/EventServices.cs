using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class EventServices : Base
  {
    public EventServices(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public EventServicesModel Get(string orgCode, int eventId, int sequenceNumber)
    {
      return apiClient.Endpoints.EventServices.Get( orgCode, eventId, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<EventServicesModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.EventServices.Search(orgCode, $"{nameof(EventServicesModel.EventID)} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example with a constructed EventServicesModel object
    /// </summary> 
    public EventServicesModel Add(EventServicesModel myEventService)
    {
      return apiClient.Endpoints.EventServices.Add( myEventService);
    }

    /// <summary>
    /// A basic edit example with a constructed EventServiceModel object
    /// </summary> 
    public EventServicesModel Edit(EventServicesModel myEventService)
    {
      return apiClient.Endpoints.EventServices.Update( myEventService);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>    
    public void Delete(string orgCode, int eventId, int sequenceNumber)
    {
      apiClient.Endpoints.EventServices.Delete( orgCode, eventId, sequenceNumber);  
    }
  }
}
