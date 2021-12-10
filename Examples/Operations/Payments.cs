using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Payments : Base
  {
    public Payments(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PaymentsModel Get(string orgCode, string accountCode, int sequence)
    {
      return apiClient.Endpoints.Payments.Get( orgCode, accountCode, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<PaymentsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Payments.Search(orgCode, $"{nameof(PaymentsModel.Account)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>  
    /// <param name="transaction">This is the value from the AR005_TSM column in AR005_TRANS_TYPES.  This sets the default for various fields in the background</param>
    public PaymentsModel Add(string orgCode, string accountCode, string noteText, string transaction, int paidAmount, int orderNumber)
    {
      var myPayment = new PaymentsModel
      {
        Organization = orgCode,
        Account = accountCode,
        Note = noteText,
        Transaction = transaction,
        PaidAmount = paidAmount,
        OrderNumber = orderNumber //Note that Event information is defaulted in from the order
      };

      return apiClient.Endpoints.Payments.Add( myPayment);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public PaymentsModel Edit(string orgCode, string accountCode, int sequence, string NewNoteText)
    {
      var myPayment = apiClient.Endpoints.Payments.Get( orgCode, accountCode, sequence);

      myPayment.Note = NewNoteText;

      return apiClient.Endpoints.Payments.Update( myPayment);
    }
    public PaymentsModel EditAdvanced(string orgCode, string accountCode, int sequence)
    {

      var myPayment = apiClient.Endpoints.Payments.Get( orgCode, accountCode, sequence);

      myPayment.Reference = "Check";    //This should not contain sensitive info for API use.  Corresponds with AR020_CC_CHECK
      myPayment.UserReference = "Some user info"; //Corresponds with AR020_USER_REFERENCE
      myPayment.Internal = "Y";          //Y or N for if the payment is internal or not
      myPayment.Date = System.DateTime.Now;              //This defaults to current date if not filled


      //The payor info fields should only be edited if the payor is a 3rd party
      //.Name = "Some Company"; Used for Organization Accounts
      myPayment.FirstName = "Adam";
      myPayment.LastName = "Jensen";
      myPayment.Address1 = "123 Some Street";
      myPayment.Address2 = "Block 4";
      myPayment.Address3 = "Apt D";
      myPayment.City = "Chicago";
      myPayment.State = "Illinois";
      myPayment.PostalCode = "60290";
      myPayment.Country = "***";  //The country code from the Ungerboeck Countries window.  *** is the default country.


      return apiClient.Endpoints.Payments.Update( myPayment);
    }

    /// <summary>
    /// How to add a payment tied to an invoice 
    /// </summary>  
    /// <param name="transaction">This is the value from the AR005_TSM column in AR005_TRANS_TYPES.  This sets the default for various fields in the background</param>
    /// <param name="invoiceNumber">This is the sequence of the invoice (This is found in v20 under Invoices window -> Sequence column in grid.  Also in database as AR030_INVOICE)</param>
    public PaymentsModel AddInvoicePayment(string orgCode, string accountCode, string noteText, string transaction, int paidAmount, int invoiceNumber)
    {
      var myPayment = new PaymentsModel
      {
        Organization = orgCode,
        Account = accountCode,
        Note = noteText,
        Transaction = transaction,
        PaidAmount = paidAmount,
        Invoice = invoiceNumber,
        Date = System.DateTime.Now
      };

      return apiClient.Endpoints.Payments.Add( myPayment);
    }
  }
}
