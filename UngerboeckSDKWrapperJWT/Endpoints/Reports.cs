using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Subjects.Reports;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// Find endpoint calls for this subject here.
  /// </summary>
  public class Reports : Base<UngerboeckModel>
  {
    protected internal Reports(ApiClient api) : base(api) { }

    /// <summary>
    /// Custom endpoint.  Gets the report parameters for the report being run.
    /// </summary>
    /// <param name="orgCode">Org Code to run the report against</param>
    /// <param name="sequenceNumber">Report Master Sequence</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>ParametersModel, showing the parameters used for the report</returns>
    public ParametersModel GetParameters(string orgCode, int sequenceNumber, Ungerboeck.Api.Models.Options.Subjects.Reports options = null)
    {
      System.Threading.Tasks.Task<ParametersModel> reportsTask = GetAsync<ParametersModel>(Client, $"Reports/{orgCode}/{sequenceNumber}/GetParameters", options);
      return CustomSync(reportsTask);
    }

    /// <summary>
    /// Custom endpoint.  Runs the report with the request passed in.
    /// </summary>
    /// <param name="orgCode">Org Code to run the report against</param>
    /// <param name="sequenceNumber">Report Master Sequence</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>ReportResponseModel containing the report</returns>
    public ReportResponseModel RunReport(string orgCode, int sequenceNumber, ReportRequestModel reportRequestModel, Ungerboeck.Api.Models.Options.Subjects.Reports options = null)
    {
      System.Threading.Tasks.Task<ReportResponseModel> ReportRequestModelTask = PutAsync<ReportRequestModel, ReportResponseModel>(Client,
          $"Reports/{orgCode}/{sequenceNumber}/RunReport", reportRequestModel, options);
      return CustomSync(ReportRequestModelTask);
    }
  }
}
