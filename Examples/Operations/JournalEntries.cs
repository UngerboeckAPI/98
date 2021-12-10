
using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Operations
{
  public class JournalEntries : Base
  {
    public JournalEntries(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public JournalEntriesModel Get(string orgCode, int year, int period, string source, string entryNumber)
    {
      return apiClient.Endpoints.JournalEntries.Get( orgCode, year, period, source, entryNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<JournalEntriesModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.JournalEntries.Search(orgCode, $"{nameof(JournalEntriesModel.Year)} eq {searchValue}");
    }

    /// <summary>
    /// Adds a Journal Entry 
    /// </summary>
    public JournalEntriesModel Add(string orgCode, int Event, int year, int period, string source, string entryNumber, string status, string description, System.DateTime transactionDate)
    {
      var myJournalEntry = new JournalEntriesModel
      {
        Organization = orgCode,
        Event = Event,
        Year = year,
        Period = period,
        Source = source,
        EntryNumber = entryNumber,
        Status = status,
        Description = description,
        TransactionDate = transactionDate
      };

      return apiClient.Endpoints.JournalEntries.Add( myJournalEntry);
    }
   
    /// <summary>
    /// Updates an existing journal entry by updating the description value
    /// </summary>
    public JournalEntriesModel Edit(string orgCode, int year, int period, string source, string entryNumber)
    {
      JournalEntriesModel journalEntryModel = apiClient.Endpoints.JournalEntries.Get( orgCode, year, period, source, entryNumber);
      string description = "Journal entry description edited via test " + System.DateTime.Now.ToString();
      journalEntryModel.Description = description;


      journalEntryModel = apiClient.Endpoints.JournalEntries.Update( journalEntryModel);
      return journalEntryModel;
    }

    /// <summary>
    /// You can retrieve journal entries attached to journal entries items by utilizing the Select ability of the odata string.  
    /// Be sure to include the [], as this denotes it's a nested model.
    /// </summary> 
    public Ungerboeck.Api.Models.Search.SearchResponse<JournalEntriesModel> GetWithJournalEntryDetails(string orgCode, int year, int period, string source, string entryNumber)
    {
      Ungerboeck.Api.Models.Options.Search options = new Ungerboeck.Api.Models.Options.Search() { Select = new List<string> { "[JournalEntryDetails]" } };
      return apiClient.Endpoints.JournalEntries.Search(orgCode, $"Year eq {year} and Period eq {period} and Source eq '{source}' and EntryNumber eq '{entryNumber}'", options );
    }

  }
}
