using System.Net.Http;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using Ungerboeck.Api.Sdk;

namespace Examples.Operations
{
  public class Notes : Base
  {
    public Notes(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public NotesModel Get(string orgCode, string type, string accountCode, decimal sequenceNumber)
    {
      return apiClient.Endpoints.Notes.Get( orgCode, type, accountCode, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<NotesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Notes.Search(orgCode, $"{nameof(NotesModel.Account)} eq '{searchValue}'");
    }

    public NotesModel AddAccountNote(string orgCode, string title, string text, string accountCode)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.AccountNote,
        Title = title,
        Text = text,
        Account = accountCode,
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddEventNote(string orgCode, string text, int eventID, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.EventNote,
        Title = newTitle,
        Text = text,
        Event = eventID,
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddOrderNote(string orgCode, string text, int orderNbr, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.OrderNote,
        Title = newTitle,
        Text = text,
        OrderNumber = orderNbr,
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddOrderItemsNote(string orgCode, string text, int orderNbr, int orderDetailNbr, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.OrderDetailNote,
        Title = newTitle,
        Text = text,
        OrderNumber = orderNbr,
        OrderDetailNbr = orderDetailNbr
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddBookingsNote(string orgCode, string text, int eventID, int sequenceNbr, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.BookingHeaderNote,
        Title = newTitle,
        Text = text,
        Event = eventID,
        BookingHeaderSequence = sequenceNbr
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddFunctionsNote(string orgCode, string text, int eventID, int functionID, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.FunctionNote,
        Title = newTitle,
        Text = text,
        Event = eventID,
        Function = functionID
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddExhibitorsNote(string orgCode, string text, int eventID, int exhibitorID, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.ExhibitorNote,
        Title = newTitle,
        Text = text,
        Event = eventID,
        ExhibitorID = exhibitorID
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddInvoiceNote(string orgCode, string text, int invoiceNbr, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.InvoiceNote,
        Title = newTitle,
        Text = text,
        InvoiceNumber = invoiceNbr
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddContractNote(string orgCode, string text, int contractSequence, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.ContractNote,
        Title = newTitle,
        Text = text,
        Contract = contractSequence
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddPurchaseOrderNote(string orgCode, string text, int orderNbr, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.PurchaseOrderHeaderNote,
        Title = newTitle,
        Text = text,
        OrderNumber = orderNbr,
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddPurchaseOrderDetailNote(string orgCode, string text, int orderNbr, int orderDetailNbr, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.PurchaseOrderDetailNote,
        Title = newTitle,
        Text = text,
        OrderNumber = orderNbr,
        OrderDetailNbr = orderDetailNbr
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddPriceListNote(string orgCode, string text, string priceList, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.PriceListNote,
        Title = newTitle,
        Text = text,
        PriceList = priceList
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddPriceListDetailNote(string orgCode, string text, string priceList, int priceListItem, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.PriceListDetailNote,
        Title = newTitle,
        Text = text,
        PriceList = priceList,
        PriceListItem = priceListItem
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddJournalEntryNote(string orgCode, string text, int fiscalYear, int fiscalPeriod, string entryNumber, string source, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.JournalEntryHeaderNote,
        Title = newTitle,
        Text = text,
        FiscalYear = fiscalYear,
        FiscalPeriod = fiscalPeriod,
        JournalEntryNumber = entryNumber,
        GLSource = source
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddJournalEntryDetailNote(string orgCode, string text, int fiscalYear, int fiscalPeriod, string entryNumber, string source, int entryDetailNbr, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.JournalEntryDetailNote,
        Title = newTitle,
        Text = text,
        FiscalYear = fiscalYear,
        FiscalPeriod = fiscalPeriod,
        GLSource = source,
        JournalEntryNumber = entryNumber,
        JournalEntryLineNumber = entryDetailNbr
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddResourceNote(string orgCode, string text, int sequenceNbr, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.ResourceMasterNote,
        Title = newTitle,
        Text = text,
        ResourceMasterSequenceNumber = sequenceNbr,
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddGLAccountNote(string orgCode, string text, string accountCode, string subAccountCode, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.GLAccountNote,
        Title = newTitle,
        Text = text,
        GLAccountCode = accountCode,
        GLSubAccountCode = subAccountCode
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddAccountAffiliationNote(string orgCode, string text, string accountCode, string affilCode, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.AccountAffiliationNote,
        Title = newTitle,
        Text = text,
        Account = accountCode,
        AffiliationCode = affilCode
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddPurchaseRequisitionDetailNote(string orgCode, string text, int orderNbr, int orderDtlNbr, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.PurchaseRequisitionDetailNote,
        Title = newTitle,
        Text = text,
        OrderNumber = orderNbr,
        OrderDetailNbr = orderDtlNbr,
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddPurchaseRequisitionNote(string orgCode, string text, int orderNbr, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.PurchaseRequisitionHeaderNote,
        Title = newTitle,
        Text = text,
        OrderNumber = orderNbr,
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddBankReconciliationNote(string orgCode, string text, int reconSequence, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.BankReconciliationNote,
        Title = newTitle,
        Text = text,
        BankReconciliationSeqNbr = reconSequence,
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddAccountProductServiceNote(string orgCode, string text, string accountCode, string prodCode, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.AccountProductServiceNote,
        Title = newTitle,
        Text = text,
        Account = accountCode,
        ProductServiceCode = prodCode
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddEventProductServiceNote(string orgCode, string text, int Event, string eventProductSequence, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.EventProductServiceNote,
        Title = newTitle,
        Text = text,
        Event = Event,
        ProductServiceCode = eventProductSequence
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddWorkOrderNote(string orgCode, string text, int orderNbr, string dept, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.WorkOrderNote,
        Title = newTitle,
        Text = text,
        OrderNumber = orderNbr,
        Department = dept
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddInventoryNote(string orgCode, string text, string code, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.InventoryNote,
        Title = newTitle,
        Text = text,
        InventoryItemCode = code
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddEventBlockNote(string orgCode, string text, string blockCode, int eventID, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.EventBlockNote,
        Title = newTitle,
        Text = text,
        BlockCode = blockCode,
        Event = eventID
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddQuoteNote(string orgCode, string text, int sequenceNbr, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.QuoteNote,
        Title = newTitle,
        Text = text,
        Quote = sequenceNbr
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddQuoteItemNote(string orgCode, string text, int sequenceNbr, int lineNbr, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.QuoteItemNote,
        Title = newTitle,
        Text = text,
        Quote = sequenceNbr,
        QuoteItem = lineNbr
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddCashTransactionNote(string orgCode, string text, int sequenceNbr, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.CashTransactionNote,
        Title = newTitle,
        Text = text,
        CashBookTransactionSeqNbr = sequenceNbr
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddSpaceRoomNote(string orgCode, string text, string code, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.SpaceRoomNote,
        Title = newTitle,
        Text = text,
        SpaceCode = code
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddAppointmentNote(string orgCode, string text, int ApptID, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.AppointmentNote,
        Title = newTitle,
        Text = text,
        AppointmentID = ApptID
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    public NotesModel AddTaskNote(string orgCode, string text, int taskID, string newTitle)
    {
      var myNote = new NotesModel
      {
        OrganizationCode = orgCode,
        Type = USISDKConstants.NoteType.TaskNote,
        Title = newTitle,
        Text = text,
        TaskID = taskID
      };

      return apiClient.Endpoints.Notes.Add( myNote);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public NotesModel Edit(string orgCode, string type, string accountCode, decimal sequenceNumber, string newText)
    {
      var myNote = apiClient.Endpoints.Notes.Get( orgCode, type, accountCode, sequenceNumber);

      myNote.Title = newText;

      return apiClient.Endpoints.Notes.Update( myNote);
    }

    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, string type, string accountCode, decimal sequenceNumber)
    {
      apiClient.Endpoints.Notes.Delete( orgCode, type, accountCode, sequenceNumber);
    }
  }
}
