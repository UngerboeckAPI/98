using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class MeetingNotes : Base
  {
    public MeetingNotes(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public MeetingNotesModel Get(string orgCode, string bulletinApplication, int meeting, int bulletinSeqNbr, int sequenceNbr)
    {
      return apiClient.Endpoints.MeetingNotes.Get( orgCode, bulletinApplication, meeting, bulletinSeqNbr, sequenceNbr);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<MeetingNotesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.MeetingNotes.Search(orgCode, $"{nameof(MeetingNotesModel.Class)} eq '{searchValue}'");
    }
  }
}
