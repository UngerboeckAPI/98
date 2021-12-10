using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Sdk;

namespace Examples.Operations
{
  public class MembershipCards : Base
  {
    public MembershipCards(ApiClient apiClient) : base(apiClient)
    {
    }

    public MembershipCardsModel Get(int cardId)
    {
      return apiClient.Endpoints.MembershipCards.Get( cardId);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<MembershipCardsModel> Search(string searchValue)
    {
      return apiClient.Endpoints.MembershipCards.Search($"{nameof(MembershipCardsModel.CardKeyword)} eq '{searchValue}'");
    }

    /// <summary>
    /// Add Membership Card Example
    /// </summary>
    /// <param name="accountMembershipId"></param>
    /// <param name="accountMemberId"></param>
    /// <param name="cardNumber"></param>
    /// <param name="cardDescription"></param>
    /// <param name="cardKeyword"></param>
    /// <param name="quantity"></param>
    /// <param name="issueDate"></param>
    /// <param name="expirationDate"></param>
    /// <param name="validDate"></param>
    /// <param name="cardStatusId"></param>
    /// <param name="lostStolen"></param>
    /// <param name="transferrable"></param>
    /// <returns></returns>
    public MembershipCardsModel Add(int accountMembershipId, 
                                    int accountMemberId, 
                                    int membershipPeriodId,
                                    string cardNumber,
                                    string cardDescription,
                                    string cardKeyword,
                                    int quantity,
                                    DateTime issueDate,
                                    DateTime expirationDate,
                                    DateTime validDate,
                                    int cardStatusId,
                                    bool lostStolen,
                                    bool transferrable,
                                    string barcode)
    {
      MembershipCardsModel membershipCardModel = new MembershipCardsModel()
      {
        AccountMembershipId = accountMembershipId,
        AccountMemberId = accountMemberId,
        PeriodId = membershipPeriodId,
        CardNumber = cardNumber,
        CardDescription = cardDescription,
        CardKeyword = cardKeyword,
        Quantity = quantity,
        IssueDate = issueDate,
        ExpirationDate = expirationDate,
        ValidDate = validDate,
        CardStatusId = cardStatusId,
        LostStolen = lostStolen,
        Transferrable = transferrable,
        Barcode = barcode
      };

      return apiClient.Endpoints.MembershipCards.Add( membershipCardModel);
    }

    public MembershipCardsModel Edit(int cardId, string cardDescription)
    {
      MembershipCardsModel membershipCardModel = Get(cardId);

      membershipCardModel.CardDescription = cardDescription;

      return apiClient.Endpoints.MembershipCards.Update( membershipCardModel);
    }

    public MembershipCardsModel EditAdvanced(int cardId)
    {

      var myMembershipCard = apiClient.Endpoints.MembershipCards.Get( cardId);

      myMembershipCard.CardNumber = "123456789";
      myMembershipCard.CardDescription = "New Card Description";
      myMembershipCard.CardKeyword = "Card Type";
      myMembershipCard.Quantity = 10;
      myMembershipCard.IssueDate = DateTime.Now;
      myMembershipCard.ExpirationDate = DateTime.Now;
      myMembershipCard.ValidDate = DateTime.Now;
      myMembershipCard.LostStolen = true;
      myMembershipCard.Transferrable = true;
      myMembershipCard.Barcode = "Barcode New";

      return apiClient.Endpoints.MembershipCards.Update( myMembershipCard);
    }

    public void Delete(int CardId)
    {
      apiClient.Endpoints.MembershipCards.Delete(CardId);      
    }
  }
}
