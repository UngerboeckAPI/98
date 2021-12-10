using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;
using System.Data;


namespace Examples.Operations
{
  public class Blocks : Base
  {
    public Blocks(ApiClient apiClient) : base(apiClient) { }


    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public BlocksModel Get(string orgCode, int eventId, string code)
    {
      return apiClient.Endpoints.Blocks.Get( orgCode, eventId, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<BlocksModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.Blocks.Search(orgCode, $"{nameof(BlocksModel.Event)} eq {searchValue}");
    }

    /// <summary>
    /// An example of retrieving all of the Event/Contract blocks.
    /// </summary>
    /// <param name="orgCode"></param>
    /// <returns></returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<BlocksModel> RetrieveEventBlocks(string orgCode, int eventId)
    {
      return apiClient.Endpoints.Blocks.Search(orgCode, $"Event eq {eventId} and Class eq 'C'"); //C = Contract/Event Blocks, H = Housing/Registration Blocks
    }
    
  }
}
