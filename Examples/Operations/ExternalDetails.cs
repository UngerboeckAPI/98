using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;
using System;
using System.Data;

namespace Examples.Operations
{
  public class ExternalDetails : Base
  {
    public ExternalDetails(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public ExternalDetailsModel Get(string orgCode, int externalID)
    {
      return APIUtil.GetExternalDetail(USISDKClient, orgCode, externalID);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<ExternalDetailsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<ExternalDetailsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// Example of how to add a ExternalDetail
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="Description">The Description that you want to attach the ExternalDetail to</param>
    /// <param name="ExternalGLAccount">This is the user-configurable External GLAccount code the ExternalDetail takes place in</param>
    /// <param name="ExternalGLDesc">This should be set to the ExternalGLDesc of the ExternalDetail </param>
    /// <param name="Currency">This should be set to the Currency of the ExternalDetail </param>
    public ExternalDetailsModel Add()
    {
      var myExternalDetail = new ExternalDetailsModel
      {
        OrgCode = "10",
        Description = "B-Facility Fees Mystern",
        ExternalGLAccount = "0000-600-60-21015",
        ExternalGLDesc = "B-Facility Fees Mystern",
        GLAccount = "123456789",
        GLSubAccount = "",
        Resource = 5042,
        Currency = "USD"
      };

      return APIUtil.AddExternalDetailWithoutConflictCheck(USISDKClient, myExternalDetail);
    }


    /// <summary>
    /// A basic edit example
    /// </summary>  
    public ExternalDetailsModel Edit(string orgCode, int externalID, ExternalDetailsModel externalDetailsModelNew)
    {
      var myExternalDetails = APIUtil.GetExternalDetail(USISDKClient, orgCode, externalID);

      if (myExternalDetails != null)
      {
        myExternalDetails.Description = externalDetailsModelNew.Description;
        myExternalDetails.ExternalGLAccount = externalDetailsModelNew.ExternalGLAccount;
        myExternalDetails.ExternalGLDesc = externalDetailsModelNew.ExternalGLDesc;
        myExternalDetails.GLAccount = externalDetailsModelNew.GLAccount;
        myExternalDetails.Resource = externalDetailsModelNew.Resource;
        myExternalDetails.Currency = externalDetailsModelNew.Currency;
        myExternalDetails.GLPosted = externalDetailsModelNew.GLPosted;
      }

      return APIUtil.UpdateExternalDetailWithoutConflictCheck(USISDKClient, myExternalDetails);
    }

    /// <summary>
    /// This example is designed to show sample values to use in other editable properties.  For more information, see the model property info in the /api/help sandbox.
    /// </summary>
    public ExternalDetailsModel EditAdvanced(string orgCode, int externalID)
    {
      var myExternalDetails = APIUtil.GetExternalDetail(USISDKClient, orgCode, externalID);

      myExternalDetails.Description = "B-AR Ticket Sales";
      myExternalDetails.ExternalGLAccount = "0000-000-60-12005";
      myExternalDetails.ExternalGLDesc = "B-AR Ticket Sales";
      myExternalDetails.GLAccount = "123456789";
      myExternalDetails.Resource = 5042;
      myExternalDetails.Currency = "USD";
      myExternalDetails.GLPosted = "Y";

      return APIUtil.UpdateExternalDetailWithoutConflictCheck(USISDKClient, myExternalDetails);
    }


    /// <summary>
    /// Example showing how to save multiple items of the same model at a time.  
    /// </summary>
    /// <param name="ExternalDetailsModel1">This contains a standard ExternalDetailsModel object.  A partial model mith missing properties is allowed.</param>
    /// <param name="bulkOperation1">Contains "create" or "update"</param>
    /// <param name="ExternalDetailsModel2">This contains a standard ExternalDetailsModel object.  A partial model mith missing properties is allowed.</param>
    /// <param name="bulkOperation2">Contains "create" or "update"</param>
    /// <param name="continueOnError">The bulk process is transactional and will save nothing if an item errors.  If you are submitting a list of unrelated items to save, set this as false and the bulk save process will attempt to continue saving if an item fails to save.  Note that certain errors will always result in the bulk operation halting.</param>
    /// <returns></returns>
    public BulkResponseModel Bulk(ExternalDetailsModel ExternalDetailsModel1, string bulkOperation1, ExternalDetailsModel ExternalDetailsModel2, string bulkOperation2, bool continueOnError, bool skipExternalDetailConflicts)
    {
      /* If one item fails, you have the option to continue without it (see BulkRequestModel.ContinueOnError).  Use this for large updates of unrelated items.
          -You can track items via the BulkItemIndex tracker.*/

      var myBulkRequest = new BulkRequestModel
      {
        ContinueOnError = continueOnError
      };

      var mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = ExternalDetailsModel1, //This is a standard Ungerboeck Model found in our SDK
        Action = bulkOperation1, //contains "create" or "update".  Every item action can be independent.
        BulkItemIndex = 1 //Use this index to track items in the response.  Whether an item succeeds or fails, it will preserve the index you assign it.
      };

      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);

      mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = ExternalDetailsModel2,
        Action = bulkOperation2,
        BulkItemIndex = 2
      };

      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);

      if (skipExternalDetailConflicts)
      {
        //Use this header to skip ExternalDetail conflicts
        if (!USISDKClient.DefaultRequestHeaders.Contains("X-ValidationOverrides")) USISDKClient.DefaultRequestHeaders.Add("X-ValidationOverrides", "[{\"Code\": 12015}]");
      }


      return APIUtil.DoBulk<ExternalDetailsModel>(USISDKClient, myBulkRequest);
    }

  }
}
