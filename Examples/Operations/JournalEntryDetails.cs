using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class JournalEntryDetails : Base
  {
    public JournalEntryDetails(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public JournalEntryDetailsModel Get(string orgCode, int year, int period, string source, string entryNumber, int line)
    {
      return apiClient.Endpoints.JournalEntryDetails.Get( orgCode, year, period, source, entryNumber, line);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<JournalEntryDetailsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.JournalEntryDetails.Search(orgCode, $"{nameof(JournalEntryDetailsModel.EntryNumber)} eq '{searchValue}'");
    }

    /// <summary>
    /// Adds a Journal Entry 
    /// </summary>
    public JournalEntryDetailsModel Add(string orgCode, int Event, int year, int period, string source, string entryNumber, string status, string description, string glAccount, System.DateTime date)
    {
      var myJournalEntryDetail = new JournalEntryDetailsModel
      {
        Organization = orgCode,
        Event = Event,
        Year = year,
        Period = period,
        Source = source,
        EntryNumber = entryNumber,
        Status = status,
        Description = description,
        GLAccount = glAccount,
        Date = date
      };

      return apiClient.Endpoints.JournalEntryDetails.Add( myJournalEntryDetail);
    }

    /// <summary>
    /// Updates an existing journal entry by updating the description value
    /// </summary>
    public JournalEntryDetailsModel Edit(string orgCode, int year, int period, string source, string entryNumber, int line)
    {
      JournalEntryDetailsModel journalEntryDetailModel = apiClient.Endpoints.JournalEntryDetails.Get( orgCode, year, period, source, entryNumber, line);
      string description = journalEntryDetailModel.Description + " : Inventory JE import " + System.DateTime.Now.ToString();
      journalEntryDetailModel.Description = description;

      journalEntryDetailModel = apiClient.Endpoints.JournalEntryDetails.Update( journalEntryDetailModel);
      return journalEntryDetailModel;
    }
  }
}
