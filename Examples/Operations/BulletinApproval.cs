using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class BulletinApproval : Base
  {
    public BulletinApproval(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public BulletinApprovalModel Get(string orgCode, int meetingSequenceNumber, int bulletinSequenceNumber, int sequenceNumber, string bulletinFileID)
    {
      return apiClient.Endpoints.BulletinApproval.Get( orgCode, meetingSequenceNumber, bulletinSequenceNumber, sequenceNumber, bulletinFileID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<BulletinApprovalModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.BulletinApproval.Search(orgCode, $"{nameof(BulletinApprovalModel.MeetingSequenceNumber)} eq {searchValue}");
    }

  }
}
