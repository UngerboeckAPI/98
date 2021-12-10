using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class TimesheetBatchDetails : Base
  {
    public TimesheetBatchDetails(HttpClient USISDKClient) : base(USISDKClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public TimesheetBatchDetailsModel Get(string orgCode, string batch, int sequence)
    {
      return APIUtil.GetTimesheetBatchDetail(USISDKClient, orgCode, batch, sequence);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<TimesheetBatchDetailsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<TimesheetBatchDetailsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
