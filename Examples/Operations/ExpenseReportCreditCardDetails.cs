using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class ExpenseReportCreditCardDetails : Base
  {
    public ExpenseReportCreditCardDetails(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public ExpenseReportCreditCardDetailsModel Get(int CardTransactionDetailID)
    {
      return apiClient.Endpoints.ExpenseReportCreditCardDetails.Get( CardTransactionDetailID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<ExpenseReportCreditCardDetailsModel> Search(string searchValue)
    {
      return apiClient.Endpoints.ExpenseReportCreditCardDetails.Search($"{nameof(ExpenseReportCreditCardDetailsModel.Description)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    /// <returns></returns>
    public ExpenseReportCreditCardDetailsModel Add()
    {
      var ExpenseReportCreditCardDetails = new ExpenseReportCreditCardDetailsModel
      {
        Description = "Expense Report Credit Card Details Event functiona testing ",
        Date = DateTime.UtcNow,
        Amount = 570,
        ExpenseReportID = 1,
        Currency = "USD"
      };

      return apiClient.Endpoints.ExpenseReportCreditCardDetails.Add( ExpenseReportCreditCardDetails);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="cardTransactionDetailID">Card Transaction Detail ID of object to update</param>
    /// <returns></returns>

    public ExpenseReportCreditCardDetailsModel Edit(int cardTransactionDetailID, string NewDecrsiption)
    {
      ExpenseReportCreditCardDetailsModel expenseReportCreditCardDetails = apiClient.Endpoints.ExpenseReportCreditCardDetails.Get( cardTransactionDetailID);

      expenseReportCreditCardDetails.Description = NewDecrsiption;

      return apiClient.Endpoints.ExpenseReportCreditCardDetails.Update(expenseReportCreditCardDetails);
    }

    public ExpenseReportCreditCardDetailsModel EditAdvanced(int cardTransactionDetailID )
    {
      ExpenseReportCreditCardDetailsModel expenseReportCreditCardDetails = apiClient.Endpoints.ExpenseReportCreditCardDetails.Get( cardTransactionDetailID);

      expenseReportCreditCardDetails.Date = DateTime.UtcNow;
      expenseReportCreditCardDetails.Description = "Event and Function Testing updated";
      expenseReportCreditCardDetails.Amount = 667;
      expenseReportCreditCardDetails.Currency = "AUS";

      return apiClient.Endpoints.ExpenseReportCreditCardDetails.Update(expenseReportCreditCardDetails);
    }
  }
}

