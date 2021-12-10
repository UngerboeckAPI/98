using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// Find endpoint calls for this subject here.
  /// </summary>
  public class OrderRegistrants : Base<OrderRegistrantsModel>
  {
    protected internal OrderRegistrants(ApiClient api) : base(api) { }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="orgCode">Fill this with the Organization Code in which the search will take place.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public new Ungerboeck.Api.Models.Search.SearchResponse<OrderRegistrantsModel> Search(string orgCode, string searchOData, Search options = null)
    {
      return base.Search(orgCode, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public OrderRegistrantsModel Get(string orgCode, int registrantSequenceNbr, Ungerboeck.Api.Models.Options.Subjects.OrderRegistrants options = null)
    {
      return base.Get(new { orgCode, registrantSequenceNbr }, options);
    }

    /// <summary>
    /// Use this endpoint to edit a single entry of this subject.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>An updated, single model for this subject.</returns>
    public OrderRegistrantsModel Update(OrderRegistrantsModel model, Ungerboeck.Api.Models.Options.Subjects.OrderRegistrants options = null)
    {
      return base.Update(new { model.OrganizationCode, model.RegistrantSequenceNbr }, model, options);
    }

    /// <summary>
    /// Custom endpoint.  Set order registrant Approval Status
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>HttpResponseMessage indicating success</returns>
    public HttpResponseMessage SetRegistrantApproval(RegistrationApprovalsModel orderRegistrantApproval, Ungerboeck.Api.Models.Options.Subjects.OrderRegistrants options = null)
    {
      System.Threading.Tasks.Task<HttpResponseMessage> response = PutAsync<RegistrationApprovalsModel, HttpResponseMessage>(Client, $"OrderRegistrants/{orderRegistrantApproval.OrganizationCode}/{orderRegistrantApproval.RegistrantSequenceNbr}/SetRegistrantApproval", orderRegistrantApproval, options);

      return CustomSync(response);
    }

    /// <summary>
    /// Custom endpoint.  Use this to check in a registrant
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>HttpResponseMessage indicating success</returns>
    public HttpResponseMessage CheckIn(string orgCode, int registrantSequenceNbr, int eventID, Ungerboeck.Api.Models.Options.Subjects.OrderRegistrants options = null)
    {
      System.Threading.Tasks.Task<HttpResponseMessage> response = PutAsync<HttpResponseMessage>(Client, $"OrderRegistrants/{orgCode}/{registrantSequenceNbr}/{eventID}/CheckIn", null, options);

      return CustomSync(response);
    }

    /// <summary>
    /// Custom endpoint.  Use this to uncheck in a registrant
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>HttpResponseMessage indicating success</returns>
    public HttpResponseMessage ClearCheckIn(string orgCode, int registrantSequenceNbr, int eventID, Ungerboeck.Api.Models.Options.Subjects.OrderRegistrants options = null)
    {
      System.Threading.Tasks.Task<HttpResponseMessage> response = PutAsync<HttpResponseMessage>(Client, $"OrderRegistrants/{orgCode}/{registrantSequenceNbr}/{eventID}/ClearCheckIn", null, options);

      return CustomSync(response);
    }
  }
}
