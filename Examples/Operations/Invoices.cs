using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Invoices : Base
  {
    public Invoices(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public InvoicesModel Get(string orgCode, int invoiceNumber, string source)
    {
      return apiClient.Endpoints.Invoices.Get( orgCode, invoiceNumber, source);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<InvoicesModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.Invoices.Search(orgCode, $"{nameof(InvoicesModel.Event)} eq {searchValue}");
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public InvoicesModel Edit(string orgCode, int invoice, string source, string newStatus)
    {
      var myInvoice = apiClient.Endpoints.Invoices.Get( orgCode, invoice, source);

      myInvoice.CollectionStatus = newStatus;

      return apiClient.Endpoints.Invoices.Update( myInvoice);
    }
  }
}
