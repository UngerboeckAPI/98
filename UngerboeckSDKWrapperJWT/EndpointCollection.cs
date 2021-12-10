using Ungerboeck.Api.Sdk.Endpoints;

namespace Ungerboeck.Api.Sdk
{
  public class EndpointCollection
  {

    private readonly ApiClient client;
    public EndpointCollection(ApiClient api)
    {
      client = api;
    }

    private AccountAffiliations AccountAffiliationsApi;
    public AccountAffiliations AccountAffiliations
    {
      get
      {
        if (AccountAffiliationsApi == null) AccountAffiliationsApi = new AccountAffiliations(client);
        return AccountAffiliationsApi;
      }
    }

    private AccountLeads AccountLeadsApi;
    public AccountLeads AccountLeads
    {
      get
      {
        if (AccountLeadsApi == null) AccountLeadsApi = new AccountLeads(client);
        return AccountLeadsApi;
      }
    }

    private AccountMailingLists AccountMailingListsApi;
    public AccountMailingLists AccountMailingLists
    {
      get
      {
        if (AccountMailingListsApi == null) AccountMailingListsApi = new AccountMailingLists(client);
        return AccountMailingListsApi;
      }
    }

    private AccountProductsAndServices AccountProductsAndServicesApi;
    public AccountProductsAndServices AccountProductsAndServices
    {
      get
      {
        if (AccountProductsAndServicesApi == null) AccountProductsAndServicesApi = new AccountProductsAndServices(client);
        return AccountProductsAndServicesApi;
      }
    }

    private Accounts AccountsApi;
    public Accounts Accounts
    {
      get
      {
        if (AccountsApi == null) AccountsApi = new Accounts(client);
        return AccountsApi;
      }
    }

    private AccountsReceivableVoucherAllocations AccountsReceivableVoucherAllocationsApi;
    public AccountsReceivableVoucherAllocations AccountsReceivableVoucherAllocations
    {
      get
      {
        if (AccountsReceivableVoucherAllocationsApi == null) AccountsReceivableVoucherAllocationsApi = new AccountsReceivableVoucherAllocations(client);
        return AccountsReceivableVoucherAllocationsApi;
      }
    }

    private AccountsReceivableVouchers AccountsReceivableVouchersApi;
    public AccountsReceivableVouchers AccountsReceivableVouchers
    {
      get
      {
        if (AccountsReceivableVouchersApi == null) AccountsReceivableVouchersApi = new AccountsReceivableVouchers(client);
        return AccountsReceivableVouchersApi;
      }
    }

    private AccountTypes AccountTypesApi;
    public AccountTypes AccountTypes
    {
      get
      {
        if (AccountTypesApi == null) AccountTypesApi = new AccountTypes(client);
        return AccountTypesApi;
      }
    }

    private Activities ActivitiesApi;
    public Activities Activities
    {
      get
      {
        if (ActivitiesApi == null) ActivitiesApi = new Activities(client);
        return ActivitiesApi;
      }
    }

    private Affiliations AffiliationsApi;
    public Affiliations Affiliations
    {
      get
      {
        if (AffiliationsApi == null) AffiliationsApi = new Affiliations(client);
        return AffiliationsApi;
      }
    }

    private AlternateAddresses AlternateAddressesApi;
    public AlternateAddresses AlternateAddresses
    {
      get
      {
        if (AlternateAddressesApi == null) AlternateAddressesApi = new AlternateAddresses(client);
        return AlternateAddressesApi;
      }
    }

    private APDemographics APDemographicsApi;
    public APDemographics APDemographics
    {
      get
      {
        if (APDemographicsApi == null) APDemographicsApi = new APDemographics(client);
        return APDemographicsApi;
      }
    }

    private APPaymentTaxes APPaymentTaxesApi;
    public APPaymentTaxes APPaymentTaxes
    {
      get
      {
        if (APPaymentTaxesApi == null) APPaymentTaxesApi = new APPaymentTaxes(client);
        return APPaymentTaxesApi;
      }
    }

    private APTaxes APTaxesApi;
    public APTaxes APTaxes
    {
      get
      {
        if (APTaxesApi == null) APTaxesApi = new APTaxes(client);
        return APTaxesApi;
      }
    }

    private ARDemographics ARDemographicsApi;
    public ARDemographics ARDemographics
    {
      get
      {
        if (ARDemographicsApi == null) ARDemographicsApi = new ARDemographics(client);
        return ARDemographicsApi;
      }
    }

    private AssetBookDefaults AssetBookDefaultsApi;
    public AssetBookDefaults AssetBookDefaults
    {
      get
      {
        if (AssetBookDefaultsApi == null) AssetBookDefaultsApi = new AssetBookDefaults(client);
        return AssetBookDefaultsApi;
      }
    }

    private AssetsDepreciationDetails AssetsDepreciationDetailsApi;
    public AssetsDepreciationDetails AssetsDepreciationDetails
    {
      get
      {
        if (AssetsDepreciationDetailsApi == null) AssetsDepreciationDetailsApi = new AssetsDepreciationDetails(client);
        return AssetsDepreciationDetailsApi;
      }
    }

    private AssetTransactions AssetTransactionsApi;
    public AssetTransactions AssetTransactions
    {
      get
      {
        if (AssetTransactionsApi == null) AssetTransactionsApi = new AssetTransactions(client);
        return AssetTransactionsApi;
      }
    }

    private ApiUtility ApiUtilityApi;
    public ApiUtility ApiUtility
    {
      get
      {
        if (ApiUtilityApi == null) ApiUtilityApi = new ApiUtility(client);
        return ApiUtilityApi;
      }
    }

    private BankAccounts BankAccountsApi;
    public BankAccounts BankAccounts
    {
      get
      {
        if (BankAccountsApi == null) BankAccountsApi = new BankAccounts(client);
        return BankAccountsApi;
      }
    }

    private BankReconciliations BankReconciliationsApi;
    public BankReconciliations BankReconciliations
    {
      get
      {
        if (BankReconciliationsApi == null) BankReconciliationsApi = new BankReconciliations(client);
        return BankReconciliationsApi;
      }
    }

    private Blocks BlocksApi;
    public Blocks Blocks
    {
      get
      {
        if (BlocksApi == null) BlocksApi = new Blocks(client);
        return BlocksApi;
      }
    }

    private Bookings BookingsApi;
    public Bookings Bookings
    {
      get
      {
        if (BookingsApi == null) BookingsApi = new Bookings(client);
        return BookingsApi;
      }
    }

    private Booths BoothsApi;
    public Booths Booths
    {
      get
      {
        if (BoothsApi == null) BoothsApi = new Booths(client);
        return BoothsApi;
      }
    }

    private BudgetTransactions BudgetTransactionsApi;
    public BudgetTransactions BudgetTransactions
    {
      get
      {
        if (BudgetTransactionsApi == null) BudgetTransactionsApi = new BudgetTransactions(client);
        return BudgetTransactionsApi;
      }
    }

    private BulletinApproval BulletinApprovalApi;
    public BulletinApproval BulletinApproval
    {
      get
      {
        if (BulletinApprovalApi == null) BulletinApprovalApi = new BulletinApproval(client);
        return BulletinApprovalApi;
      }
    }

    private Bulletins BulletinsApi;
    public Bulletins Bulletins
    {
      get
      {
        if (BulletinsApi == null) BulletinsApi = new Bulletins(client);
        return BulletinsApi;
      }
    }

    private CampaignDetails CampaignDetailsApi;
    public CampaignDetails CampaignDetails
    {
      get
      {
        if (CampaignDetailsApi == null) CampaignDetailsApi = new CampaignDetails(client);
        return CampaignDetailsApi;
      }
    }

    private Campaigns CampaignsApi;
    public Campaigns Campaigns
    {
      get
      {
        if (CampaignsApi == null) CampaignsApi = new Campaigns(client);
        return CampaignsApi;
      }
    }

    private CashBookTransactions CashBookTransactionsApi;
    public CashBookTransactions CashBookTransactions
    {
      get
      {
        if (CashBookTransactionsApi == null) CashBookTransactionsApi = new CashBookTransactions(client);
        return CashBookTransactionsApi;
      }
    }

    private Checklists ChecklistsApi;
    public Checklists Checklists
    {
      get
      {
        if (ChecklistsApi == null) ChecklistsApi = new Checklists(client);
        return ChecklistsApi;
      }
    }

    private Communications CommunicationsApi;
    public Communications Communications
    {
      get
      {
        if (CommunicationsApi == null) CommunicationsApi = new Communications(client);
        return CommunicationsApi;
      }
    }

    private Concessions ConcessionsApi;
    public Concessions Concessions
    {
      get
      {
        if (ConcessionsApi == null) ConcessionsApi = new Concessions(client);
        return ConcessionsApi;
      }
    }

    private Contracts ContractsApi;
    public Contracts Contracts
    {
      get
      {
        if (ContractsApi == null) ContractsApi = new Contracts(client);
        return ContractsApi;
      }
    }

    private Countries CountriesApi;
    public Countries Countries
    {
      get
      {
        if (CountriesApi == null) CountriesApi = new Countries(client);
        return CountriesApi;
      }
    }

    private Conversations ConversationsApi;
    public Conversations Conversations
    {
      get
      {
        if (ConversationsApi == null) ConversationsApi = new Conversations(client);
        return ConversationsApi;
      }
    }

    private ConversationAccounts ConversationAccountsApi;
    public ConversationAccounts ConversationAccounts
    {
      get
      {
        if (ConversationAccountsApi == null) ConversationAccountsApi = new ConversationAccounts(client);
        return ConversationAccountsApi;
      }
    }

    private ConversationMessages ConversationMessagesApi;
    public ConversationMessages ConversationMessages
    {
      get
      {
        if (ConversationMessagesApi == null) ConversationMessagesApi = new ConversationMessages(client);
        return ConversationMessagesApi;
      }
    }

    private CurrencyCodes CurrencyCodesApi;
    public CurrencyCodes CurrencyCodes
    {
      get
      {
        if (CurrencyCodesApi == null) CurrencyCodesApi = new CurrencyCodes(client);
        return CurrencyCodesApi;
      }
    }

    private CurrencyRates CurrencyRatesApi;
    public CurrencyRates CurrencyRates
    {
      get
      {
        if (CurrencyRatesApi == null) CurrencyRatesApi = new CurrencyRates(client);
        return CurrencyRatesApi;
      }
    }

    private CustomerTerms CustomerTermsApi;
    public CustomerTerms CustomerTerms
    {
      get
      {
        if (CustomerTermsApi == null) CustomerTermsApi = new CustomerTerms(client);
        return CustomerTermsApi;
      }
    }

    private CustomFieldSets CustomFieldSetsApi;
    public CustomFieldSets CustomFieldSets
    {
      get
      {
        if (CustomFieldSetsApi == null) CustomFieldSetsApi = new CustomFieldSets(client);
        return CustomFieldSetsApi;
      }
    }

    private CustomFieldValidationTables CustomFieldValidationTablesApi;
    public CustomFieldValidationTables CustomFieldValidationTables
    {
      get
      {
        if (CustomFieldValidationTablesApi == null) CustomFieldValidationTablesApi = new CustomFieldValidationTables(client);
        return CustomFieldValidationTablesApi;
      }
    }

    private Cycles CyclesApi;
    public Cycles Cycles
    {
      get
      {
        if (CyclesApi == null) CyclesApi = new Cycles(client);
        return CyclesApi;
      }
    }

    private DailyRevenueAndCostAnalysis DailyRevenueAndCostAnalysisApi;
    public DailyRevenueAndCostAnalysis DailyRevenueAndCostAnalysis
    {
      get
      {
        if (DailyRevenueAndCostAnalysisApi == null) DailyRevenueAndCostAnalysisApi = new DailyRevenueAndCostAnalysis(client);
        return DailyRevenueAndCostAnalysisApi;
      }
    }

    private DailyRevenueJobControls DailyRevenueJobControlsApi;
    public DailyRevenueJobControls DailyRevenueJobControls
    {
      get
      {
        if (DailyRevenueJobControlsApi == null) DailyRevenueJobControlsApi = new DailyRevenueJobControls(client);
        return DailyRevenueJobControlsApi;
      }
    }

    private Departments DepartmentsApi;
    public Departments Departments
    {
      get
      {
        if (DepartmentsApi == null) DepartmentsApi = new Departments(client);
        return DepartmentsApi;
      }
    }

    private Distributions DistributionsApi;
    public Distributions Distributions
    {
      get
      {
        if (DistributionsApi == null) DistributionsApi = new Distributions(client);
        return DistributionsApi;
      }
    }

    private DocumentClasses DocumentClassesApi;
    public DocumentClasses DocumentClasses
    {
      get
      {
        if (DocumentClassesApi == null) DocumentClassesApi = new DocumentClasses(client);
        return DocumentClassesApi;
      }
    }

    private Documents DocumentsApi;
    public Documents Documents
    {
      get
      {
        if (DocumentsApi == null) DocumentsApi = new Documents(client);
        return DocumentsApi;
      }
    }

    private EventJobCategories EventJobCategoriesApi;
    public EventJobCategories EventJobCategories
    {
      get
      {
        if (EventJobCategoriesApi == null) EventJobCategoriesApi = new EventJobCategories(client);
        return EventJobCategoriesApi;
      }
    }

    private EventJobClasses EventJobClassesApi;
    public EventJobClasses EventJobClasses
    {
      get
      {
        if (EventJobClassesApi == null) EventJobClassesApi = new EventJobClasses(client);
        return EventJobClassesApi;
      }
    }

    private EventJobTypes EventJobTypesApi;
    public EventJobTypes EventJobTypes
    {
      get
      {
        if (EventJobTypesApi == null) EventJobTypesApi = new EventJobTypes(client);
        return EventJobTypesApi;
      }
    }

    private EventPortalMessages EventPortalMessagesApi;
    public EventPortalMessages EventPortalMessages
    {
      get
      {
        if (EventPortalMessagesApi == null) EventPortalMessagesApi = new EventPortalMessages(client);
        return EventPortalMessagesApi;
      }
    }

    private EventOpportunities EventOpportunitiesApi;
    public EventOpportunities EventOpportunities
    {
      get
      {
        if (EventOpportunitiesApi == null) EventOpportunitiesApi = new EventOpportunities(client);
        return EventOpportunitiesApi;
      }
    }

    private EventProductsAndServices EventProductsAndServicesApi;
    public EventProductsAndServices EventProductsAndServices
    {
      get
      {
        if (EventProductsAndServicesApi == null) EventProductsAndServicesApi = new EventProductsAndServices(client);
        return EventProductsAndServicesApi;
      }
    }

    private Events EventsApi;
    public Events Events
    {
      get
      {
        if (EventsApi == null) EventsApi = new Events(client);
        return EventsApi;
      }
    }

    private EventServices EventServicesApi;
    public EventServices EventServices
    {
      get
      {
        if (EventServicesApi == null) EventServicesApi = new EventServices(client);
        return EventServicesApi;
      }
    }

    private EventsPriceList EventsPriceListApi;
    public EventsPriceList EventsPriceList
    {
      get
      {
        if (EventsPriceListApi == null) EventsPriceListApi = new EventsPriceList(client);
        return EventsPriceListApi;
      }
    }

    private EventStatuses EventStatusesApi;
    public EventStatuses EventStatuses
    {
      get
      {
        if (EventStatusesApi == null) EventStatusesApi = new EventStatuses(client);
        return EventStatusesApi;
      }
    }

    private Exhibitors ExhibitorsApi;
    public Exhibitors Exhibitors
    {
      get
      {
        if (ExhibitorsApi == null) ExhibitorsApi = new Exhibitors(client);
        return ExhibitorsApi;
      }
    }

    private ExpenseReportApprovals ExpenseReportApprovalsApi;
    public ExpenseReportApprovals ExpenseReportApprovals
    {
      get
      {
        if (ExpenseReportApprovalsApi == null) ExpenseReportApprovalsApi = new ExpenseReportApprovals(client);
        return ExpenseReportApprovalsApi;
      }
    }

    private ExpenseReportCreditCardDetails ExpenseReportCreditCardDetailsApi;
    public ExpenseReportCreditCardDetails ExpenseReportCreditCardDetails
    {
      get
      {
        if (ExpenseReportCreditCardDetailsApi == null) ExpenseReportCreditCardDetailsApi = new ExpenseReportCreditCardDetails(client);
        return ExpenseReportCreditCardDetailsApi;
      }
    }

    private ExpenseReportDetails ExpenseReportDetailsApi;
    public ExpenseReportDetails ExpenseReportDetails
    {
      get
      {
        if (ExpenseReportDetailsApi == null) ExpenseReportDetailsApi = new ExpenseReportDetails(client);
        return ExpenseReportDetailsApi;
      }
    }

    private ExpenseReportHeaders ExpenseReportHeadersApi;
    public ExpenseReportHeaders ExpenseReportHeaders
    {
      get
      {
        if (ExpenseReportHeadersApi == null) ExpenseReportHeadersApi = new ExpenseReportHeaders(client);
        return ExpenseReportHeadersApi;
      }
    }

    private ExternalInvoiceDetails ExternalInvoiceDetailsApi;
    public ExternalInvoiceDetails ExternalInvoiceDetails
    {
      get
      {
        if (ExternalInvoiceDetailsApi == null) ExternalInvoiceDetailsApi = new ExternalInvoiceDetails(client);
        return ExternalInvoiceDetailsApi;
      }
    }

    private ExternalInvoices ExternalInvoicesApi;
    public ExternalInvoices ExternalInvoices
    {
      get
      {
        if (ExternalInvoicesApi == null) ExternalInvoicesApi = new ExternalInvoices(client);
        return ExternalInvoicesApi;
      }
    }

    private ExternalInvoiceSummaries ExternalInvoiceSummariesApi;
    public ExternalInvoiceSummaries ExternalInvoiceSummaries
    {
      get
      {
        if (ExternalInvoiceSummariesApi == null) ExternalInvoiceSummariesApi = new ExternalInvoiceSummaries(client);
        return ExternalInvoiceSummariesApi;
      }
    }

    private FiscalPeriods FiscalPeriodsApi;
    public FiscalPeriods FiscalPeriods
    {
      get
      {
        if (FiscalPeriodsApi == null) FiscalPeriodsApi = new FiscalPeriods(client);
        return FiscalPeriodsApi;
      }
    }

    private FiscalYears FiscalYearsApi;
    public FiscalYears FiscalYears
    {
      get
      {
        if (FiscalYearsApi == null) FiscalYearsApi = new FiscalYears(client);
        return FiscalYearsApi;
      }
    }

    private FixedAssetBookDetails FixedAssetBookDetailsApi;
    public FixedAssetBookDetails FixedAssetBookDetails
    {
      get
      {
        if (FixedAssetBookDetailsApi == null) FixedAssetBookDetailsApi = new FixedAssetBookDetails(client);
        return FixedAssetBookDetailsApi;
      }
    }

    private FixedAssetsRegisters FixedAssetsRegistersApi;
    public FixedAssetsRegisters FixedAssetsRegisters
    {
      get
      {
        if (FixedAssetsRegistersApi == null) FixedAssetsRegistersApi = new FixedAssetsRegisters(client);
        return FixedAssetsRegistersApi;
      }
    }

    private FulfillmentOrderItems FulfillmentOrderItemsApi;
    public FulfillmentOrderItems FulfillmentOrderItems
    {
      get
      {
        if (FulfillmentOrderItemsApi == null) FulfillmentOrderItemsApi = new FulfillmentOrderItems(client);
        return FulfillmentOrderItemsApi;
      }
    }

    private FulfillmentOrders FulfillmentOrdersApi;
    public FulfillmentOrders FulfillmentOrders
    {
      get
      {
        if (FulfillmentOrdersApi == null) FulfillmentOrdersApi = new FulfillmentOrders(client);
        return FulfillmentOrdersApi;
      }
    }

    private FunctionCheckIns FunctionCheckInsApi;
    public FunctionCheckIns FunctionCheckIns
    {
      get
      {
        if (FunctionCheckInsApi == null) FunctionCheckInsApi = new FunctionCheckIns(client);
        return FunctionCheckInsApi;
      }
    }

    private Functions FunctionsApi;
    public Functions Functions
    {
      get
      {
        if (FunctionsApi == null) FunctionsApi = new Functions(client);
        return FunctionsApi;
      }
    }

    private FunctionSeatingCharts FunctionSeatingChartsApi;
    public FunctionSeatingCharts FunctionSeatingCharts
    {
      get
      {
        if (FunctionSeatingChartsApi == null) FunctionSeatingChartsApi = new FunctionSeatingCharts(client);
        return FunctionSeatingChartsApi;
      }
    }

    private GLAccounts GLAccountsApi;
    public GLAccounts GLAccounts
    {
      get
      {
        if (GLAccountsApi == null) GLAccountsApi = new GLAccounts(client);
        return GLAccountsApi;
      }
    }

    private GLDeferralRevenueDetails GLDeferralRevenueDetailsApi;
    public GLDeferralRevenueDetails GLDeferralRevenueDetails
    {
      get
      {
        if (GLDeferralRevenueDetailsApi == null) GLDeferralRevenueDetailsApi = new GLDeferralRevenueDetails(client);
        return GLDeferralRevenueDetailsApi;
      }
    }

    private GLDeferralRevenueHeaders GLDeferralRevenueHeadersApi;
    public GLDeferralRevenueHeaders GLDeferralRevenueHeaders
    {
      get
      {
        if (GLDeferralRevenueHeadersApi == null) GLDeferralRevenueHeadersApi = new GLDeferralRevenueHeaders(client);
        return GLDeferralRevenueHeadersApi;
      }
    }

    private GLDistributions GLDistributionsApi;
    public GLDistributions GLDistributions
    {
      get
      {
        if (GLDistributionsApi == null) GLDistributionsApi = new GLDistributions(client);
        return GLDistributionsApi;
      }
    }

    private GLMainAccounts GLMainAccountsApi;
    public GLMainAccounts GLMainAccounts
    {
      get
      {
        if (GLMainAccountsApi == null) GLMainAccountsApi = new GLMainAccounts(client);
        return GLMainAccountsApi;
      }
    }

    private GLSources GLSourcesApi;
    public GLSources GLSources
    {
      get
      {
        if (GLSourcesApi == null) GLSourcesApi = new GLSources(client);
        return GLSourcesApi;
      }
    }

    private GroupProfiles GroupProfilesApi;
    public GroupProfiles GroupProfiles
    {
      get
      {
        if (GroupProfilesApi == null) GroupProfilesApi = new GroupProfiles(client);
        return GroupProfilesApi;
      }
    }

    private InventoryBalances InventoryBalancesApi;
    public InventoryBalances InventoryBalances
    {
      get
      {
        if (InventoryBalancesApi == null) InventoryBalancesApi = new InventoryBalances(client);
        return InventoryBalancesApi;
      }
    }

    private InventoryBatchDetails InventoryBatchDetailsApi;
    public InventoryBatchDetails InventoryBatchDetails
    {
      get
      {
        if (InventoryBatchDetailsApi == null) InventoryBatchDetailsApi = new InventoryBatchDetails(client);
        return InventoryBatchDetailsApi;
      }
    }

    private InventoryItems InventoryItemsApi;
    public InventoryItems InventoryItems
    {
      get
      {
        if (InventoryItemsApi == null) InventoryItemsApi = new InventoryItems(client);
        return InventoryItemsApi;
      }
    }

    private InventoryStats InventoryStatsApi;
    public InventoryStats InventoryStats
    {
      get
      {
        if (InventoryStatsApi == null) InventoryStatsApi = new InventoryStats(client);
        return InventoryStatsApi;
      }
    }

    private InventorySuppliers InventorySuppliersApi;
    public InventorySuppliers InventorySuppliers
    {
      get
      {
        if (InventorySuppliersApi == null) InventorySuppliersApi = new InventorySuppliers(client);
        return InventorySuppliersApi;
      }
    }

    private InventoryTransactions InventoryTransactionsApi;
    public InventoryTransactions InventoryTransactions
    {
      get
      {
        if (InventoryTransactionsApi == null) InventoryTransactionsApi = new InventoryTransactions(client);
        return InventoryTransactionsApi;
      }
    }

    private InvoiceDetails InvoiceDetailsApi;
    public InvoiceDetails InvoiceDetails
    {
      get
      {
        if (InvoiceDetailsApi == null) InvoiceDetailsApi = new InvoiceDetails(client);
        return InvoiceDetailsApi;
      }
    }

    private InvoiceDetailTaxes InvoiceDetailTaxesApi;
    public InvoiceDetailTaxes InvoiceDetailTaxes
    {
      get
      {
        if (InvoiceDetailTaxesApi == null) InvoiceDetailTaxesApi = new InvoiceDetailTaxes(client);
        return InvoiceDetailTaxesApi;
      }
    }

    private Invoices InvoicesApi;
    public Invoices Invoices
    {
      get
      {
        if (InvoicesApi == null) InvoicesApi = new Invoices(client);
        return InvoicesApi;
      }
    }

    private Jobs JobsApi;
    public Jobs Jobs
    {
      get
      {
        if (JobsApi == null) JobsApi = new Jobs(client);
        return JobsApi;
      }
    }

    private JournalEntries JournalEntriesApi;
    public JournalEntries JournalEntries
    {
      get
      {
        if (JournalEntriesApi == null) JournalEntriesApi = new JournalEntries(client);
        return JournalEntriesApi;
      }
    }

    private JournalEntryDetails JournalEntryDetailsApi;
    public JournalEntryDetails JournalEntryDetails
    {
      get
      {
        if (JournalEntryDetailsApi == null) JournalEntryDetailsApi = new JournalEntryDetails(client);
        return JournalEntryDetailsApi;
      }
    }

    private MailingLists MailingListsApi;
    public MailingLists MailingLists
    {
      get
      {
        if (MailingListsApi == null) MailingListsApi = new MailingLists(client);
        return MailingListsApi;
      }
    }

    private MarketListItems MarketListItemsApi;
    public MarketListItems MarketListItems
    {
      get
      {
        if (MarketListItemsApi == null) MarketListItemsApi = new MarketListItems(client);
        return MarketListItemsApi;
      }
    }

    private MarketLists MarketListsApi;
    public MarketLists MarketLists
    {
      get
      {
        if (MarketListsApi == null) MarketListsApi = new MarketLists(client);
        return MarketListsApi;
      }
    }

    private MarketSegments MarketSegmentsApi;
    public MarketSegments MarketSegments
    {
      get
      {
        if (MarketSegmentsApi == null) MarketSegmentsApi = new MarketSegments(client);
        return MarketSegmentsApi;
      }
    }

    private MeetingFlowPattern MeetingFlowPatternApi;
    public MeetingFlowPattern MeetingFlowPattern
    {
      get
      {
        if (MeetingFlowPatternApi == null) MeetingFlowPatternApi = new MeetingFlowPattern(client);
        return MeetingFlowPatternApi;
      }
    }

    private MeetingNotes MeetingNotesApi;
    public MeetingNotes MeetingNotes
    {
      get
      {
        if (MeetingNotesApi == null) MeetingNotesApi = new MeetingNotes(client);
        return MeetingNotesApi;
      }
    }

    private Meetings MeetingsApi;
    public Meetings Meetings
    {
      get
      {
        if (MeetingsApi == null) MeetingsApi = new Meetings(client);
        return MeetingsApi;
      }
    }

    private MembershipCards MembershipCardsApi;
    public MembershipCards MembershipCards
    {
      get
      {
        if (MembershipCardsApi == null) MembershipCardsApi = new MembershipCards(client);
        return MembershipCardsApi;
      }
    }

    private MembershipEngagements MembershipEngagementsApi;
    public MembershipEngagements MembershipEngagements
    {
      get
      {
        if (MembershipEngagementsApi == null) MembershipEngagementsApi = new MembershipEngagements(client);
        return MembershipEngagementsApi;
      }
    }

    private MembershipEngagementTypes MembershipEngagementTypesApi;
    public MembershipEngagementTypes MembershipEngagementTypes
    {
      get
      {
        if (MembershipEngagementTypesApi == null) MembershipEngagementTypesApi = new MembershipEngagementTypes(client);
        return MembershipEngagementTypesApi;
      }
    }

    private MembershipOrderItems MembershipOrderItemsApi;
    public MembershipOrderItems MembershipOrderItems
    {
      get
      {
        if (MembershipOrderItemsApi == null) MembershipOrderItemsApi = new MembershipOrderItems(client);
        return MembershipOrderItemsApi;
      }
    }

    private MembershipOrders MembershipOrdersApi;
    public MembershipOrders MembershipOrders
    {
      get
      {
        if (MembershipOrdersApi == null) MembershipOrdersApi = new MembershipOrders(client);
        return MembershipOrdersApi;
      }
    }

    private Notes NotesApi;
    public Notes Notes
    {
      get
      {
        if (NotesApi == null) NotesApi = new Notes(client);
        return NotesApi;
      }
    }

    private Opportunities OpportunitiesApi;
    public Opportunities Opportunities
    {
      get
      {
        if (OpportunitiesApi == null) OpportunitiesApi = new Opportunities(client);
        return OpportunitiesApi;
      }
    }

    private OpportunityStatuses OpportunityStatusesApi;
    public OpportunityStatuses OpportunityStatuses
    {
      get
      {
        if (OpportunityStatusesApi == null) OpportunityStatusesApi = new OpportunityStatuses(client);
        return OpportunityStatusesApi;
      }
    }

    private OrderRegistrants OrderRegistrantsApi;
    public OrderRegistrants OrderRegistrants
    {
      get
      {
        if (OrderRegistrantsApi == null) OrderRegistrantsApi = new OrderRegistrants(client);
        return OrderRegistrantsApi;
      }
    }

    private OrderStatuses OrderStatusesApi;
    public OrderStatuses OrderStatuses
    {
      get
      {
        if (OrderStatusesApi == null) OrderStatusesApi = new OrderStatuses(client);
        return OrderStatusesApi;
      }
    }

    private OrganizationParameters OrganizationParametersApi;
    public OrganizationParameters OrganizationParameters
    {
      get
      {
        if (OrganizationParametersApi == null) OrganizationParametersApi = new OrganizationParameters(client);
        return OrganizationParametersApi;
      }
    }

    private PaymentPlanDetails PaymentPlanDetailsApi;
    public PaymentPlanDetails PaymentPlanDetails
    {
      get
      {
        if (PaymentPlanDetailsApi == null) PaymentPlanDetailsApi = new PaymentPlanDetails(client);
        return PaymentPlanDetailsApi;
      }
    }

    private PaymentPlanHeaders PaymentPlanHeadersApi;
    public PaymentPlanHeaders PaymentPlanHeaders
    {
      get
      {
        if (PaymentPlanHeadersApi == null) PaymentPlanHeadersApi = new PaymentPlanHeaders(client);
        return PaymentPlanHeadersApi;
      }
    }

    private PaymentPlans PaymentPlansApi;
    public PaymentPlans PaymentPlans
    {
      get
      {
        if (PaymentPlansApi == null) PaymentPlansApi = new PaymentPlans(client);
        return PaymentPlansApi;
      }
    }

    private Payments PaymentsApi;
    public Payments Payments
    {
      get
      {
        if (PaymentsApi == null) PaymentsApi = new Payments(client);
        return PaymentsApi;
      }
    }

    private PendingPayments PendingPaymentsApi;
    public PendingPayments PendingPayments
    {
      get
      {
        if (PendingPaymentsApi == null) PendingPaymentsApi = new PendingPayments(client);
        return PendingPaymentsApi;
      }
    }

    private PhysicalCountInventoryBatchHeaders PhysicalCountInventoryBatchHeadersApi;
    public PhysicalCountInventoryBatchHeaders PhysicalCountInventoryBatchHeaders
    {
      get
      {
        if (PhysicalCountInventoryBatchHeadersApi == null) PhysicalCountInventoryBatchHeadersApi = new PhysicalCountInventoryBatchHeaders(client);
        return PhysicalCountInventoryBatchHeadersApi;
      }
    }

    private POContracts POContractsApi;
    public POContracts POContracts
    {
      get
      {
        if (POContractsApi == null) POContractsApi = new POContracts(client);
        return POContractsApi;
      }
    }

    private PreferenceSettings PreferenceSettingsApi;
    public PreferenceSettings PreferenceSettings
    {
      get
      {
        if (PreferenceSettingsApi == null) PreferenceSettingsApi = new PreferenceSettings(client);
        return PreferenceSettingsApi;
      }
    }

    private PriceList PriceListApi;
    public PriceList PriceList
    {
      get
      {
        if (PriceListApi == null) PriceListApi = new PriceList(client);
        return PriceListApi;
      }
    }

    private PriceListItems PriceListItemsApi;
    public PriceListItems PriceListItems
    {
      get
      {
        if (PriceListItemsApi == null) PriceListItemsApi = new PriceListItems(client);
        return PriceListItemsApi;
      }
    }

    private ProductsAndServices ProductsAndServicesApi;
    public ProductsAndServices ProductsAndServices
    {
      get
      {
        if (ProductsAndServicesApi == null) ProductsAndServicesApi = new ProductsAndServices(client);
        return ProductsAndServicesApi;
      }
    }

    private PublicLanguages PublicLanguagesApi;
    public PublicLanguages PublicLanguages
    {
      get
      {
        if (PublicLanguagesApi == null) PublicLanguagesApi = new PublicLanguages(client);
        return PublicLanguagesApi;
      }
    }

    private PurchaseOrderApproval PurchaseOrderApprovalApi;
    public PurchaseOrderApproval PurchaseOrderApproval
    {
      get
      {
        if (PurchaseOrderApprovalApi == null) PurchaseOrderApprovalApi = new PurchaseOrderApproval(client);
        return PurchaseOrderApprovalApi;
      }
    }

    private PurchaseOrderApprovalLevels PurchaseOrderApprovalLevelsApi;
    public PurchaseOrderApprovalLevels PurchaseOrderApprovalLevels
    {
      get
      {
        if (PurchaseOrderApprovalLevelsApi == null) PurchaseOrderApprovalLevelsApi = new PurchaseOrderApprovalLevels(client);
        return PurchaseOrderApprovalLevelsApi;
      }
    }

    private PurchaseOrderDistributions PurchaseOrderDistributionsApi;
    public PurchaseOrderDistributions PurchaseOrderDistributions
    {
      get
      {
        if (PurchaseOrderDistributionsApi == null) PurchaseOrderDistributionsApi = new PurchaseOrderDistributions(client);
        return PurchaseOrderDistributionsApi;
      }
    }

    private PurchaseOrderItems PurchaseOrderItemsApi;
    public PurchaseOrderItems PurchaseOrderItems
    {
      get
      {
        if (PurchaseOrderItemsApi == null) PurchaseOrderItemsApi = new PurchaseOrderItems(client);
        return PurchaseOrderItemsApi;
      }
    }

    private PurchaseOrders PurchaseOrdersApi;
    public PurchaseOrders PurchaseOrders
    {
      get
      {
        if (PurchaseOrdersApi == null) PurchaseOrdersApi = new PurchaseOrders(client);
        return PurchaseOrdersApi;
      }
    }

    private PurchaseOrderTaxes PurchaseOrderTaxesApi;
    public PurchaseOrderTaxes PurchaseOrderTaxes
    {
      get
      {
        if (PurchaseOrderTaxesApi == null) PurchaseOrderTaxesApi = new PurchaseOrderTaxes(client);
        return PurchaseOrderTaxesApi;
      }
    }

    private PurchaseOrderUserApprovals PurchaseOrderUserApprovalsApi;
    public PurchaseOrderUserApprovals PurchaseOrderUserApprovals
    {
      get
      {
        if (PurchaseOrderUserApprovalsApi == null) PurchaseOrderUserApprovalsApi = new PurchaseOrderUserApprovals(client);
        return PurchaseOrderUserApprovalsApi;
      }
    }

    private ReceivableTransactionTypes ReceivableTransactionTypesApi;
    public ReceivableTransactionTypes ReceivableTransactionTypes
    {
      get
      {
        if (ReceivableTransactionTypesApi == null) ReceivableTransactionTypesApi = new ReceivableTransactionTypes(client);
        return ReceivableTransactionTypesApi;
      }
    }

    private RegistrationAssignments RegistrationAssignmentsApi;
    public RegistrationAssignments RegistrationAssignments
    {
      get
      {
        if (RegistrationAssignmentsApi == null) RegistrationAssignmentsApi = new RegistrationAssignments(client);
        return RegistrationAssignmentsApi;
      }
    }

    private RegistrationConfigurations RegistrationConfigurationsApi;
    public RegistrationConfigurations RegistrationConfigurations
    {
      get
      {
        if (RegistrationConfigurationsApi == null) RegistrationConfigurationsApi = new RegistrationConfigurations(client);
        return RegistrationConfigurationsApi;
      }
    }

    private RegistrationOrderItems RegistrationOrderItemsApi;
    public RegistrationOrderItems RegistrationOrderItems
    {
      get
      {
        if (RegistrationOrderItemsApi == null) RegistrationOrderItemsApi = new RegistrationOrderItems(client);
        return RegistrationOrderItemsApi;
      }
    }

    private RegistrationOrders RegistrationOrdersApi;
    public RegistrationOrders RegistrationOrders
    {
      get
      {
        if (RegistrationOrdersApi == null) RegistrationOrdersApi = new RegistrationOrders(client);
        return RegistrationOrdersApi;
      }
    }

    private RegistrationPreferenceTypes RegistrationPreferenceTypesApi;
    public RegistrationPreferenceTypes RegistrationPreferenceTypes
    {
      get
      {
        if (RegistrationPreferenceTypesApi == null) RegistrationPreferenceTypesApi = new RegistrationPreferenceTypes(client);
        return RegistrationPreferenceTypesApi;
      }
    }

    private Relationships RelationshipsApi;
    public Relationships Relationships
    {
      get
      {
        if (RelationshipsApi == null) RelationshipsApi = new Relationships(client);
        return RelationshipsApi;
      }
    }

    private RelationshipTypes RelationshipTypesApi;
    public RelationshipTypes RelationshipTypes
    {
      get
      {
        if (RelationshipTypesApi == null) RelationshipTypesApi = new RelationshipTypes(client);
        return RelationshipTypesApi;
      }
    }

    private Reports ReportsApi;
    public Reports Reports
    {
      get
      {
        if (ReportsApi == null) ReportsApi = new Reports(client);
        return ReportsApi;
      }
    }

    private RequisitionApproval RequisitionApprovalApi;
    public RequisitionApproval RequisitionApproval
    {
      get
      {
        if (RequisitionApprovalApi == null) RequisitionApprovalApi = new RequisitionApproval(client);
        return RequisitionApprovalApi;
      }
    }

    private RequisitionItems RequisitionItemsApi;
    public RequisitionItems RequisitionItems
    {
      get
      {
        if (RequisitionItemsApi == null) RequisitionItemsApi = new RequisitionItems(client);
        return RequisitionItemsApi;
      }
    }

    private Requisitions RequisitionsApi;
    public Requisitions Requisitions
    {
      get
      {
        if (RequisitionsApi == null) RequisitionsApi = new Requisitions(client);
        return RequisitionsApi;
      }
    }

    private RequisitionTaxes RequisitionTaxesApi;
    public RequisitionTaxes RequisitionTaxes
    {
      get
      {
        if (RequisitionTaxesApi == null) RequisitionTaxesApi = new RequisitionTaxes(client);
        return RequisitionTaxesApi;
      }
    }

    private Resources ResourcesApi;
    public Resources Resources
    {
      get
      {
        if (ResourcesApi == null) ResourcesApi = new Resources(client);
        return ResourcesApi;
      }
    }

    private ResourceTaxRates ResourceTaxRatesApi;
    public ResourceTaxRates ResourceTaxRates
    {
      get
      {
        if (ResourceTaxRatesApi == null) ResourceTaxRatesApi = new ResourceTaxRates(client);
        return ResourceTaxRatesApi;
      }
    }

    private Roles RolesApi;
    public Roles Roles
    {
      get
      {
        if (RolesApi == null) RolesApi = new Roles(client);
        return RolesApi;
      }
    }

    private ServiceOrderItems ServiceOrderItemsApi;
    public ServiceOrderItems ServiceOrderItems
    {
      get
      {
        if (ServiceOrderItemsApi == null) ServiceOrderItemsApi = new ServiceOrderItems(client);
        return ServiceOrderItemsApi;
      }
    }

    private ServiceOrders ServiceOrdersApi;
    public ServiceOrders ServiceOrders
    {
      get
      {
        if (ServiceOrdersApi == null) ServiceOrdersApi = new ServiceOrders(client);
        return ServiceOrdersApi;
      }
    }

    private SessionProposalEvaluationCriteriaResponses SessionProposalEvaluationCriteriaResponsesApi;
    public SessionProposalEvaluationCriteriaResponses SessionProposalEvaluationCriteriaResponses
    {
      get
      {
        if (SessionProposalEvaluationCriteriaResponsesApi == null) SessionProposalEvaluationCriteriaResponsesApi = new SessionProposalEvaluationCriteriaResponses(client);
        return SessionProposalEvaluationCriteriaResponsesApi;
      }
    }

    private SessionProposalEvaluations SessionProposalEvaluationsApi;
    public SessionProposalEvaluations SessionProposalEvaluations
    {
      get
      {
        if (SessionProposalEvaluationsApi == null) SessionProposalEvaluationsApi = new SessionProposalEvaluations(client);
        return SessionProposalEvaluationsApi;
      }
    }

    private SessionProposals SessionProposalsApi;
    public SessionProposals SessionProposals
    {
      get
      {
        if (SessionProposalsApi == null) SessionProposalsApi = new SessionProposals(client);
        return SessionProposalsApi;
      }
    }

    private Setups SetupsApi;
    public Setups Setups
    {
      get
      {
        if (SetupsApi == null) SetupsApi = new Setups(client);
        return SetupsApi;
      }
    }

    private SpaceComponents SpaceComponentsApi;
    public SpaceComponents SpaceComponents
    {
      get
      {
        if (SpaceComponentsApi == null) SpaceComponentsApi = new SpaceComponents(client);
        return SpaceComponentsApi;
      }
    }

    private SpaceFeatures SpaceFeaturesApi;
    public SpaceFeatures SpaceFeatures
    {
      get
      {
        if (SpaceFeaturesApi == null) SpaceFeaturesApi = new SpaceFeatures(client);
        return SpaceFeaturesApi;
      }
    }

    private SpaceHierarchyLevelOnes SpaceHierarchyLevelOnesApi;
    public SpaceHierarchyLevelOnes SpaceHierarchyLevelOnes
    {
      get
      {
        if (SpaceHierarchyLevelOnesApi == null) SpaceHierarchyLevelOnesApi = new SpaceHierarchyLevelOnes(client);
        return SpaceHierarchyLevelOnesApi;
      }
    }

    private SpaceHierarchyLevelTwos SpaceHierarchyLevelTwosApi;
    public SpaceHierarchyLevelTwos SpaceHierarchyLevelTwos
    {
      get
      {
        if (SpaceHierarchyLevelTwosApi == null) SpaceHierarchyLevelTwosApi = new SpaceHierarchyLevelTwos(client);
        return SpaceHierarchyLevelTwosApi;
      }
    }

    private SpaceImages SpaceImagesApi;
    public SpaceImages SpaceImages
    {
      get
      {
        if (SpaceImagesApi == null) SpaceImagesApi = new SpaceImages(client);
        return SpaceImagesApi;
      }
    }

    private Spaces SpacesApi;
    public Spaces Spaces
    {
      get
      {
        if (SpacesApi == null) SpacesApi = new Spaces(client);
        return SpacesApi;
      }
    }

    private SpaceSetups SpaceSetupsApi;
    public SpaceSetups SpaceSetups
    {
      get
      {
        if (SpaceSetupsApi == null) SpaceSetupsApi = new SpaceSetups(client);
        return SpaceSetupsApi;
      }
    }

    private StatementBatches StatementBatchesApi;
    public StatementBatches StatementBatches
    {
      get
      {
        if (StatementBatchesApi == null) StatementBatchesApi = new StatementBatches(client);
        return StatementBatchesApi;
      }
    }

    private StatementDetails StatementDetailsApi;
    public StatementDetails StatementDetails
    {
      get
      {
        if (StatementDetailsApi == null) StatementDetailsApi = new StatementDetails(client);
        return StatementDetailsApi;
      }
    }

    private StatementHeaders StatementHeadersApi;
    public StatementHeaders StatementHeaders
    {
      get
      {
        if (StatementHeadersApi == null) StatementHeadersApi = new StatementHeaders(client);
        return StatementHeadersApi;
      }
    }

    private TransactionMethods TransactionMethodsApi;
    public TransactionMethods TransactionMethods
    {
      get
      {
        if (TransactionMethodsApi == null) TransactionMethodsApi = new TransactionMethods(client);
        return TransactionMethodsApi;
      }
    }

    private UserDefinedFields UserDefinedFieldsApi;
    public UserDefinedFields UserDefinedFields
    {
      get
      {
        if (UserDefinedFieldsApi == null) UserDefinedFieldsApi = new UserDefinedFields(client);
        return UserDefinedFieldsApi;
      }
    }

    private UserRoles UserRolesApi;
    public UserRoles UserRoles
    {
      get
      {
        if (UserRolesApi == null) UserRolesApi = new UserRoles(client);
        return UserRolesApi;
      }
    }

    private Users UsersApi;
    public Users Users
    {
      get
      {
        if (UsersApi == null) UsersApi = new Users(client);
        return UsersApi;
      }
    }

    private ValidationEntries ValidationEntriesApi;
    public ValidationEntries ValidationEntries
    {
      get
      {
        if (ValidationEntriesApi == null) ValidationEntriesApi = new ValidationEntries(client);
        return ValidationEntriesApi;
      }
    }

    private VoucherApprovals VoucherApprovalsApi;
    public VoucherApprovals VoucherApprovals
    {
      get
      {
        if (VoucherApprovalsApi == null) VoucherApprovalsApi = new VoucherApprovals(client);
        return VoucherApprovalsApi;
      }
    }

    private VoucherBatches VoucherBatchesApi;
    public VoucherBatches VoucherBatches
    {
      get
      {
        if (VoucherBatchesApi == null) VoucherBatchesApi = new VoucherBatches(client);
        return VoucherBatchesApi;
      }
    }

    private VoucherDistribution VoucherDistributionApi;
    public VoucherDistribution VoucherDistribution
    {
      get
      {
        if (VoucherDistributionApi == null) VoucherDistributionApi = new VoucherDistribution(client);
        return VoucherDistributionApi;
      }
    }

    private VoucherPaymentInstructions VoucherPaymentInstructionsApi;
    public VoucherPaymentInstructions VoucherPaymentInstructions
    {
      get
      {
        if (VoucherPaymentInstructionsApi == null) VoucherPaymentInstructionsApi = new VoucherPaymentInstructions(client);
        return VoucherPaymentInstructionsApi;
      }
    }

    private VoucherPurchaseOrderDetails VoucherPurchaseOrderDetailsApi;
    public VoucherPurchaseOrderDetails VoucherPurchaseOrderDetails
    {
      get
      {
        if (VoucherPurchaseOrderDetailsApi == null) VoucherPurchaseOrderDetailsApi = new VoucherPurchaseOrderDetails(client);
        return VoucherPurchaseOrderDetailsApi;
      }
    }

    private Vouchers VouchersApi;
    public Vouchers Vouchers
    {
      get
      {
        if (VouchersApi == null) VouchersApi = new Vouchers(client);
        return VouchersApi;
      }
    }

    private VoucherTaxes VoucherTaxesApi;
    public VoucherTaxes VoucherTaxes
    {
      get
      {
        if (VoucherTaxesApi == null) VoucherTaxesApi = new VoucherTaxes(client);
        return VoucherTaxesApi;
      }
    }

    private Webhooks WebhooksApi;
    public Webhooks Webhooks
    {
      get
      {
        if (WebhooksApi == null) WebhooksApi = new Webhooks(client);
        return WebhooksApi;
      }
    }

    private WorkOrderItems WorkOrderItemsApi;
    public WorkOrderItems WorkOrderItems
    {
      get
      {
        if (WorkOrderItemsApi == null) WorkOrderItemsApi = new WorkOrderItems(client);
        return WorkOrderItemsApi;
      }
    }

    private WorkOrders WorkOrdersApi;
    public WorkOrders WorkOrders
    {
      get
      {
        if (WorkOrdersApi == null) WorkOrdersApi = new WorkOrders(client);
        return WorkOrdersApi;
      }
    }


  }
}
