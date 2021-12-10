using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class FunctionSeatingCharts : Base
  {
    public FunctionSeatingCharts(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    /// <param name="orgCode">The organization code of the function seating chart.</param>
    /// <param name="sequenceNumber">The primary key of the function seating chart.</param>
    public FunctionSeatingChartsModel Get(string orgCode, int sequenceNumber)
    {
      return apiClient.Endpoints.FunctionSeatingCharts.Get( orgCode, sequenceNumber);
    }

    /// <summary>
    /// A retrieve all by organization code
    /// </summary> 
    /// <param name="orgCode">The organization code of the function seating chart.</param>
    public SearchResponse<FunctionSeatingChartsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.FunctionSeatingCharts.Search(orgCode, $"{nameof(FunctionSeatingChartsModel.Description)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>  
    /// <param name="orgCode">The organization code of the function seating chart.</param>
    /// <param name="chartName">Function chart description.</param>
    /// <param name="capacity">Function Chart capacity</param>
    /// <param name="eventId">Function Chart EventId, must be specified for which event and function the chart will apply to.</param>
    /// <param name="functionId">Function Chart FunctionId, must be specified for which event and function the chart will apply to.</param>
    /// <param name="fillMethod">Manual or Auto-Assign, Fill method. Manual = 2, Auto-Assign = 1.</param>
    /// <param name="groupCodeA">One of the group code descriptors to ghelp group tables in the grid.</param>
    /// <param name="inventoryCode">A unique code to help users search for the function seating chart.</param>
    public FunctionSeatingChartsModel Add(string orgCode, string chartName, int capacity, 
                                          int eventId, int functionId, int fillMethod,
                                          string groupCodeA, string inventoryCode)
    {
      var myFunctionSeatingChart = new FunctionSeatingChartsModel
      {
        OrgCode = orgCode,
        Description = chartName,
        Capacity = capacity,
        EventId = eventId,
        FunctionId = functionId,
        FillMethod = fillMethod,
        GroupCodeA = groupCodeA,
        InventoryCode = inventoryCode
      };

      return apiClient.Endpoints.FunctionSeatingCharts.Add( myFunctionSeatingChart);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    /// <param name="orgCode">The organization code of the function seating chart.</param>
    /// <param name="sequenceNumber">The primary key of the function seating chart.</param>
    /// <param name="newChartDescription">New Function Seating Chart Description.</param>
    public FunctionSeatingChartsModel Edit(string orgCode, int sequenceNumber, string newChartDescription)
    {
      var myFunctionSeatingChart = apiClient.Endpoints.FunctionSeatingCharts.Get( orgCode, sequenceNumber);

      myFunctionSeatingChart.Description = newChartDescription;

      return apiClient.Endpoints.FunctionSeatingCharts.Update( myFunctionSeatingChart);
    }
    
    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, int sequenceNumber)
    {
      apiClient.Endpoints.FunctionSeatingCharts.Delete(orgCode, sequenceNumber);
    }
  }
}
