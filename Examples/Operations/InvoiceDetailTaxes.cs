using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class InvoiceDetailTaxes : Base
  {
    public InvoiceDetailTaxes(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public InvoiceDetailTaxesModel Get(string orgCode, int invoiceNumber, int orderNumber, int orderLineNumber, int sequenceNbr)
    {
      return apiClient.Endpoints.InvoiceDetailTaxes.Get( orgCode, invoiceNumber, orderNumber, orderLineNumber, sequenceNbr);
    }


    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<InvoiceDetailTaxesModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.InvoiceDetailTaxes.Search(orgCode, $"{nameof(InvoiceDetailTaxesModel.OrderNumber)} eq {searchValue}");
    }
  }
}
