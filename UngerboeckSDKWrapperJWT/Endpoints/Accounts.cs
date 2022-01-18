using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// Find endpoint calls for this subject here.
  /// </summary>
  public class Accounts : Base<AllAccountsModel>
  {
    protected internal Accounts(ApiClient api) : base(api) { }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="orgCode">Fill this with the Organization Code in which the search will take place.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public new Ungerboeck.Api.Models.Search.SearchResponse<AllAccountsModel> Search(string orgCode, string searchOData, Search options = null)
    {
      return SearchSync(orgCode, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to run an async search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="orgCode">Fill this with the Organization Code in which the search will take place.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public new Task<Ungerboeck.Api.Models.Search.SearchResponse<AllAccountsModel>> SearchAsync(string orgCode, string searchOData, Search options = null)
    {
      return base.SearchAsync(orgCode, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public AllAccountsModel Get(string orgCode, string accountCode, Ungerboeck.Api.Models.Options.Subjects.Accounts options = null)
    {      
      return GetSync(new { orgCode, accountCode }, options);
    }


    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A task for a single model for this subject.</returns>
    public Task<AllAccountsModel> GetAsync(string orgCode, string accountCode, Ungerboeck.Api.Models.Options.Subjects.Accounts options = null)
    {
      return base.GetAsync(new { orgCode, accountCode }, options);
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public AllAccountsModel Update(AllAccountsModel model, Ungerboeck.Api.Models.Options.Subjects.Accounts options = null)
    {
      return UpdateSync(new { model.Organization, model.AccountCode }, model, options);
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public Task<AllAccountsModel> UpdateAsync(AllAccountsModel model, Ungerboeck.Api.Models.Options.Subjects.Accounts options = null)
    {
      return base.UpdateAsync(new { model.Organization, model.AccountCode }, model, options);
    }

    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public AllAccountsModel Add(AllAccountsModel model, Ungerboeck.Api.Models.Options.Subjects.Accounts options = null)
    {      
      return AddSync(model, options);
    }

    /// <summary>
    /// Use this endpoint to add a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public Task<AllAccountsModel> AddAsync(AllAccountsModel model, Ungerboeck.Api.Models.Options.Subjects.Accounts options = null)
    {
      return base.AddAsync(model, options);
    }

    /// <summary>
    /// You can do multiple save operations in one transaction.  See the API Help sandbox for a list of what has Bulk.
    /// </summary>
    /// <param name="bulkRequestModel">This contains the list of bulk items, as well as the choice to continue on failure of a save.</param>
    /// <returns>BuldResponseModel, containing the results of the bulk process</returns>
    public Ungerboeck.Api.Models.Bulk.BulkResponseModel Bulk(Ungerboeck.Api.Models.Bulk.BulkRequestModel bulkRequestModel, Ungerboeck.Api.Models.Options.Subjects.Accounts options = null)
    {
      return base.BulkSync(bulkRequestModel, options);
    }

    /// <summary>
    /// You can do multiple save operations in one transaction.  See the API Help sandbox for a list of what has Bulk.
    /// </summary>
    /// <param name="bulkRequestModel">This contains the list of bulk items, as well as the choice to continue on failure of a save.</param>
    /// <returns>BuldResponseModel, containing the results of the bulk process</returns>
    public Task<Ungerboeck.Api.Models.Bulk.BulkResponseModel> BulkAsync(Ungerboeck.Api.Models.Bulk.BulkRequestModel bulkRequestModel, Ungerboeck.Api.Models.Options.Subjects.Accounts options = null)
    {
      return base.BulkAsync(bulkRequestModel, options);
    }

    protected override void CollectValidationOverridesFromOptions(ref List<int> validationOverrides, Dictionary<string, string> headers, Ungerboeck.Api.Models.Options.Base baseOptions)
    {
      var options = GetOptions<Models.Options.Subjects.Accounts>(baseOptions);
      SetValidation(validationOverrides, options?.BlockDuplicateAccounts, ValidationCodes.BlockDuplicateAccounts);
    }
  }
}
