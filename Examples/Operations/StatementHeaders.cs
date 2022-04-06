using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class StatementHeaders : Base
  {
    public StatementHeaders(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public StatementHeadersModel Get(string orgCode, int batchSequence,int sequence)
    {
      return apiClient.Endpoints.StatementHeaders.Get( orgCode, batchSequence, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<StatementHeadersModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.StatementHeaders.Search(orgCode, $"{nameof(StatementHeadersModel.BatchSequence)} eq {searchValue}");
    }

    
    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="orgCode">org code of object to Update</param>
    /// <param name="batchSequence">batch sequence of object to update</param>
    /// <param name="sequence">sequence of object to update</param>
    /// <returns></returns>
    public StatementHeadersModel Edit(string orgCode, int batchSequence, int sequence, StatementHeadersModel statementHeadersModelNew)
    {
      var statementHeaderModel = apiClient.Endpoints.StatementHeaders.Get(orgCode, batchSequence, sequence);

      if (statementHeaderModel != null)
      {
        statementHeaderModel.ReportedAmount = statementHeadersModelNew.ReportedAmount;
        statementHeaderModel.Corrected = statementHeadersModelNew.Corrected;
        statementHeaderModel.Print = statementHeadersModelNew.Print;
        statementHeaderModel.SecondTIN = statementHeadersModelNew.SecondTIN;
      }

      return apiClient.Endpoints.StatementHeaders.Update(statementHeaderModel);
    }

    
    /// <summary>
    /// A basic add example
    /// </summary>    
    /// <returns></returns>
    public StatementHeadersModel Add()
    {
      var statementHeader = new StatementHeadersModel
      {
        Organization = "10",
        BatchSequence = 11,
        Description = "Meyer Engineering INc.",
        TaxID = "64-86576",
        Amount = 4387,
        ReportedAmount = 2500,
        Account = "00010114",
        Type = "1099-MSC",
        Status = "S",
        Print = "Y",
        Corrected = "Y",
        SecondTIN = "Y",
        OrganizationFederalID = "56872345",
        OrganizationStateID = "85695201"
      };

      return apiClient.Endpoints.StatementHeaders.Add(statementHeader);
    }

  }
}



