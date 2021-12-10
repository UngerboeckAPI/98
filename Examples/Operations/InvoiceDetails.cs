using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class InvoiceDetails : Base
  {
    public InvoiceDetails(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public InvoiceDetailsModel Get(string orgCode,int invoiceNumber, int orderNumber, int orderLine)
    {
      return apiClient.Endpoints.InvoiceDetails.Get( orgCode, invoiceNumber, orderNumber, orderLine);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<InvoiceDetailsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.InvoiceDetails.Search(orgCode, $"{nameof(InvoiceDetailsModel.OrderNumber)} eq {searchValue}");
    }
  }
}
