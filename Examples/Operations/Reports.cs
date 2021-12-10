using System.Collections.Generic;
using System.Net.Http;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Sdk;
using System;
using Ungerboeck.Api.Models.Subjects.Reports;

namespace Examples.Operations
{
  public class Reports : Base
  {

    public Reports(ApiClient apiClient) : base(apiClient) { }

    /// <summary>
    /// Tests the Get Parameters for the Controls Test
    /// </summary>
    public ParametersModel GetReportParameters(string orgCode, int sequenceNumber)
    {
      ParametersModel parametersModel = apiClient.Endpoints.Reports.GetParameters( orgCode, sequenceNumber);

      return parametersModel;
    }

    /// <summary>
    /// Tests the running of the controls text exported to pdf
    /// </summary>
    public ReportResponseModel RunReport(string orgCode, int sequenceNumber, ReportRequestModel reportRequestModel)
    {
      ReportResponseModel reportResponseModel = apiClient.Endpoints.Reports.RunReport( orgCode, sequenceNumber, reportRequestModel);

      return reportResponseModel;
    }

    /// <summary>
    /// Tests the running of the controls text exported to word
    /// </summary>
    public ReportResponseModel RunReport(string orgCode, int sequenceNumber)
    {
      ParameterValues parameter;
      ReportRequestModel reportRequestModel = new ReportRequestModel
      {
        ExportType = USISDKConstants.ReportConstants.ExportType.PDF
      };

      parameter = new ParameterValues
      {
        ParameterName = "Single Select Text Custom Values"
      };
      parameter.Values.Add("Value_2");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues
      {
        ParameterName = "Single Select No Custom Values"
      };
      parameter.Values.Add("Value_1");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues
      {
        ParameterName = "Multi Select No Custom Values"
      };
      parameter.Values.Add("Value_1");
      parameter.Values.Add("Value_2");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues
      {
        ParameterName = "Number Type"
      };
      parameter.Values.Add("8");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues
      {
        ParameterName = "Single Date"
      };
      parameter.Values.Add(DateTime.Now.ToString(USISDKConstants.ReportConstants.ReportDateFormat));
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues
      {
        ParameterName = "Currency Type"
      };
      parameter.Values.Add("8.95");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues
      {
        ParameterName = "Multi Select Text Box Custom Values"
      };
      parameter.Values.Add("Value_1");
      parameter.Values.Add("I'm Custom");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues
      {
        ParameterName = "Time Field"
      };
      parameter.Values.Add(DateTime.Now.ToString(USISDKConstants.ReportConstants.ReportDateFormat));
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues
      {
        ParameterName = "Date Time Field"
      };
      parameter.Values.Add(DateTime.Now.ToString(USISDKConstants.ReportConstants.ReportDateFormat));
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues
      {
        ParameterName = "Numeric Range Dropdown"
      };
      parameter.Values.Add("1");
      parameter.Values.Add("2");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues
      {
        ParameterName = "Numeric Range"
      };
      parameter.Values.Add("1");
      parameter.Values.Add("2");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues
      {
        ParameterName = "Date Range"
      };
      parameter.Values.Add(DateTime.Now.ToString(USISDKConstants.ReportConstants.ReportDateFormat));
      parameter.Values.Add(DateTime.Now.AddDays(7).ToString(USISDKConstants.ReportConstants.ReportDateFormat));
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues
      {
        ParameterName = "Boolean Value with Text"
      };
      parameter.Values.Add(true.ToString());
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues
      {
        ParameterName = "Boolean Value No Text"
      };
      parameter.Values.Add("True");
      reportRequestModel.Parameters.Add(parameter);

      ReportResponseModel reportResponseModelTest = apiClient.Endpoints.Reports.RunReport( orgCode, sequenceNumber, reportRequestModel);

      return reportResponseModelTest;
    }

  }
}
