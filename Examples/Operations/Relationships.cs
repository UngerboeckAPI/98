using System.Net.Http;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models.Bulk;

namespace Examples.Operations
{
  public class Relationships : Base
  {
    public Relationships(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public RelationshipsModel Get(string orgCode, string masterAccountCode, string subordinateAccountCode, string relationshipType)
    {
      return apiClient.Endpoints.Relationships.Get( orgCode, masterAccountCode, subordinateAccountCode, relationshipType);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<RelationshipsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Relationships.Search(orgCode, $"{nameof(RelationshipsModel.MasterAccountCode)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">The org code of both accounts</param>
    /// <param name="masterAccountCode">The account code of the parent account</param>
    /// <param name="subordinateAccountCode">The account code of the child account</param>
    /// <param name="relationshipType">This is the code for the relationship type of the relationship.  This is the foreign key code from the EV876 master table</param>
    /// <param name="eventSalesDesignation">Set at least one designation and whether if it's Primary or Secondary.  NOTE: Both the master and subordinate account should belong to that designation.  You can use the RelationshipDesignationStatus class to set the designation (ex: Ungerboeck.Api.Models.USISDKConstants.RelationshipDesignationStatus.Primary)</param>    
    public RelationshipsModel Add(string orgCode, string masterAccountCode, string subordinateAccountCode, string relationshipType, string eventSalesDesignation)
    {
      var myRelationship = new RelationshipsModel
      {        
        MasterOrganizationCode = orgCode,
        MasterAccountCode = masterAccountCode,
        SubordinateAccountCode = subordinateAccountCode,
        RelationshipType = relationshipType,
        SubordinateOrganizationCode = orgCode, //Note that multi-organization relationships aren't yet supported by the API.
        EventSalesDesignation = eventSalesDesignation        
      };

      return apiClient.Endpoints.Relationships.Add( myRelationship);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public RelationshipsModel Edit(string orgCode, string masterAccountCode, string subordinateAccountCode, string relationshipType, string newRelationshipText)
    {
      var myRelationship = apiClient.Endpoints.Relationships.Get( orgCode, masterAccountCode, subordinateAccountCode, relationshipType);

      myRelationship.RelationshipNote = newRelationshipText;

      return apiClient.Endpoints.Relationships.Update( myRelationship);
    }

    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, string masterAccountCode, string subordinateAccountCode, string relationshipType)
    {
      apiClient.Endpoints.Relationships.Delete( orgCode, masterAccountCode, subordinateAccountCode, relationshipType);
    }
    public RelationshipsModel EditAdvanced(string orgCode, string masterAccountCode, string subordinateAccountCode, string relationshipType)
    {

      var myRelationship = apiClient.Endpoints.Relationships.Get( orgCode, masterAccountCode, subordinateAccountCode, relationshipType);

      myRelationship.Contact = "ACCTCODE";  //This represents the contact for the relationship itself (EV873_ACCT_CODE3)

      //Ensure the two accounts actually have the account designation before setting the respective relationship designation!
      myRelationship.EventSalesDesignation = USISDKConstants.RelationshipDesignationStatus.Primary;
      myRelationship.TourSalesDesignation = USISDKConstants.RelationshipDesignationStatus.Inactive;
      myRelationship.PublicRelationsDesignation = USISDKConstants.RelationshipDesignationStatus.Inactive;
      myRelationship.MembershipDesignation = USISDKConstants.RelationshipDesignationStatus.Inactive;
      myRelationship.ReceivablesDesignation = USISDKConstants.RelationshipDesignationStatus.Inactive;
      myRelationship.PayablesDesignation = USISDKConstants.RelationshipDesignationStatus.Inactive;
      myRelationship.VisitorInquiryDesignation = USISDKConstants.RelationshipDesignationStatus.Inactive;
      myRelationship.RegistrationDesignation = USISDKConstants.RelationshipDesignationStatus.Inactive;
      myRelationship.SpeakerMgmtDesignation = USISDKConstants.RelationshipDesignationStatus.Inactive;
      myRelationship.PersonnelDesignation = USISDKConstants.RelationshipDesignationStatus.Secondary;


      return apiClient.Endpoints.Relationships.Update( myRelationship);
    }

    /// <summary>
    /// Example showing how to save multiple items of the same model at a time.  
    /// </summary>
    /// <param name="RelationshipsModel1">This contains a standard RelationshipsModel object.  A partial model mith missing properties is allowed.</param>
    /// <param name="bulkOperation1">Contains "create" or "update"</param>
    /// <param name="RelationshipsModel2">This contains a standard RelationshipsModel object.  A partial model mith missing properties is allowed.</param>
    /// <param name="bulkOperation2">Contains "create" or "update"</param>
    /// <param name="continueOnError">The bulk process is transactional and will save nothing if an item errors.  If you are submitting a list of unrelated items to save, set this as false and the bulk save process will attempt to continue saving if an item fails to save.  Note that certain errors will always result in the bulk operation halting.</param>
    /// <returns></returns>
    public BulkResponseModel Bulk(RelationshipsModel RelationshipsModel1, string bulkOperation1, RelationshipsModel RelationshipsModel2, string bulkOperation2, bool continueOnError)
    {
      /* If one item fails, you have the option to continue without it (see BulkRequestModel.ContinueOnError).  Use this for large updates of unrelated items.
          -You can track items via the BulkItemIndex tracker.*/

      var myBulkRequest = new BulkRequestModel
      {
        ContinueOnError = continueOnError
      };

      var mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = RelationshipsModel1, //This is a standard Ungerboeck Model found in our SDK
        Action = bulkOperation1, //contains "create" or "update".  Every item action can be independent.
        BulkItemIndex = 1 //Use this index to track items in the response.  Whether an item succeeds or fails, it will preserve the index you assign it.
      };

      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);

      mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = RelationshipsModel2,
        Action = bulkOperation2,
        BulkItemIndex = 2
      };

      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);

      return apiClient.Endpoints.Relationships.Bulk(myBulkRequest);
    }
  }
}
