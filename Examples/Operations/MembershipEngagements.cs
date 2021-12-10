using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Sdk;

namespace Examples.Operations
{
  public class MembershipEngagements : Base
  {
    public MembershipEngagements(ApiClient apiClient) : base(apiClient)
    {
    }

    public MembershipEngagementsModel Get(int engagementId)
    {
      return apiClient.Endpoints.MembershipEngagements.Get( engagementId);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<MembershipEngagementsModel> Search(int searchValue)
    {
      return apiClient.Endpoints.MembershipEngagements.Search($"{nameof(MembershipEngagementsModel.EventId)} eq {searchValue}");
    }

    public MembershipEngagementsModel Add(string orgCode,
                                         int eventId,
                                         int functionId,
                                         int orderNumber,
                                         int orderLine,
                                         int accountMemberId,
                                         int engagementTypeId,
                                         int transactionId,
                                         string transactionType,
                                         int membershipCardId,
                                         DateTime attendedDate,
                                         int amount,
                                         int engagementValue,
                                         string source,
                                         string referenceBatchId)
    {
      MembershipEngagementsModel MembershipEngagementsModel = new MembershipEngagementsModel()
      {
        OrgCode = orgCode,
        EventId = eventId,
        FunctionId = functionId,
        OrderNumber = orderNumber,
        OrderLine = orderLine,
        AccountMemberId = accountMemberId,
        EngagementTypeId = engagementTypeId,
        TransactionId = transactionId,
        TransactionType = transactionType,
        MembershipCardId = membershipCardId,
        AttendedDate = attendedDate,
        Amount = amount,
        EngagementValue = engagementValue,
        Source = source,
        ReferenceBatchId = referenceBatchId
      };

      return apiClient.Endpoints.MembershipEngagements.Add( MembershipEngagementsModel);
    }

    public MembershipEngagementsModel Edit(int engagementId, int amount)
    {
      MembershipEngagementsModel MembershipEngagementsModel = Get(engagementId);

      MembershipEngagementsModel.Amount = amount;

      return apiClient.Endpoints.MembershipEngagements.Update( MembershipEngagementsModel);
    }

    public MembershipEngagementsModel EditAdvanced(int engagementId)
    {

      var myMembershipEngagement = apiClient.Endpoints.MembershipEngagements.Get( engagementId);

      myMembershipEngagement.OrgCode = "10";
      myMembershipEngagement.Amount = 20;
      myMembershipEngagement.TransactionId = 123456;
      myMembershipEngagement.TransactionType = "VISA";
      myMembershipEngagement.Source = "Ungerboeck API";

      return apiClient.Endpoints.MembershipEngagements.Update( myMembershipEngagement);
    }

    public void Delete(int engagementId)
    {
      apiClient.Endpoints.MembershipEngagements.Delete(engagementId);
    }
  }
}
