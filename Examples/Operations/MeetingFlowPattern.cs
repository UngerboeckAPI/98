using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class MeetingFlowPattern : Base
  {
    public MeetingFlowPattern(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public MeetingFlowPatternModel Get(string orgCode, string flowApplicationCode, int meetingTourSequenceNbr, int flowSequenceNumber)
    {
      return apiClient.Endpoints.MeetingFlowPattern.Get( orgCode, flowApplicationCode, meetingTourSequenceNbr, flowSequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>  
    public SearchResponse<MeetingFlowPatternModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.MeetingFlowPattern.Search(orgCode, $"{nameof(MeetingFlowPatternModel.FlowSequenceNumber)} eq {searchValue}");
    }
  }
}
