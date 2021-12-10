using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class TimesheetBatches : Base
  {
    public TimesheetBatches(HttpClient USISDKClient) : base(USISDKClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public TimesheetBatchesModel Get(string orgCode, string batch)
    {
      return APIUtil.GetTimesheetBatch(USISDKClient, orgCode, batch);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<TimesheetBatchesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<TimesheetBatchesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
