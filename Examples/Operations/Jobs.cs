using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Examples.Operations
{
  public class Jobs : Base
  {
    public Jobs(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public JobsModel Get(string orgCode, int jobID)
    {
      return apiClient.Endpoints.Jobs.Get( orgCode, jobID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<JobsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Jobs.Search(orgCode, $"{nameof(JobsModel.Account)} eq '{searchValue}'");
    }

    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    public Ungerboeck.Api.Models.Search.SearchResponse<JobsModel> SearchForUserFields(string orgCode)
    {
      
      //For non-account user fields, the format is [User field Class]|[User field Type]|[Organization Code]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.

      //This is searching for Job user fields of Issue Class = J (job ), Issue Type code = DJ, organization code = 10, and User Text 02 (TXT_02).  It will return jobs where the value is "pop"
      return apiClient.Endpoints.Jobs.Search(orgCode, "J|DJ|10|UserText02 eq 'pop'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>  
    public JobsModel Add(string orgCode, string jobName, string accountCode)
    {
      var myJob = new JobsModel
      {
        Organization = orgCode,
        Description = jobName,
        Account = accountCode,
        StartDate = DateTime.Now,
        EndDate = DateTime.Now,
      };

      return apiClient.Endpoints.Jobs.Add( myJob);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public JobsModel Edit(string orgCode, int jobID, string newJobName)
    {
      var myJob = apiClient.Endpoints.Jobs.Get( orgCode, jobID);

      myJob.Description = newJobName;

      return apiClient.Endpoints.Jobs.Update( myJob);
    }

    /// <summary>
    /// An example of changing the Order UserFields type. This will remove existing values from Order UserFields.
    /// </summary>
    public JobsModel EditOrderUserFieldsType(string orgCode, int jobID, string newOrderUserFieldsType)
    {
      var myJob = apiClient.Endpoints.Jobs.Get( orgCode, jobID);

      myJob.OrderUserFieldsType = newOrderUserFieldsType;

      return apiClient.Endpoints.Jobs.Update( myJob);
    }

    /// <summary>
    /// An example of cancelling a job. 
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="jobID"></param>
    /// <returns></returns>
    public JobsModel CancelJob(string orgCode, int jobID)
    {
      const string myCancelReasonCode = "DE";

      var myJob = apiClient.Endpoints.Jobs.Get( orgCode, jobID);

      myJob.Status = "80"; //'Setting to a status greater than or equal to 80 and less than or equal to 89 is sign for cancelling (80 <= x <= 89)
      myJob.Reason = myCancelReasonCode + "|JC";  //You need to supply a Reason code when cancelling an job.  It's represented by the a pipe delimited code, namely (Reason code | Cancel Reason Application code).  The Cancel Reason Application code is always EC for jobs.You can find the Reason Code in the Ungerboeck window "Job Cancellation Reasons" from the main menu.The code is located under the 'code' column in the grid.You can also find it in the database under MM210_REASON_CODE

      myJob.FunctionStatus = "82"; //When cancelling an job, the system needs to know what to status code to set on the job's functions.  Set it to a cancelled status of functions.
                                     //Note that FunctionStatus is never filled in the JobModel on a GET.  It's just a place to set Function Status when cancelling an job.

      return apiClient.Endpoints.Jobs.Update( myJob);
    }

    /// <summary>
    /// An example of adding a new job with UserFields.
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="jobName"></param>
    /// <param name="accountCode"></param>
    /// <param name="issueType"></param>
    /// <param name="newTxt12Value"></param>
    /// <returns></returns>
    public JobsModel AddWithUserFields(string orgCode, string jobName, string accountCode, string issueType, string newTxt12Value)
    {
      var myJob = new JobsModel
      {
        Organization = orgCode,
        Description = jobName,
        Account = accountCode,
        StartDate = DateTime.Now,
        EndDate = DateTime.Now,
        JobUserFieldSets = new List<UserFields>(),
      };

      //Here's how to add a user field set with values to a new job
      UserFields myUserField = new UserFields
      {
        //Note that class is always JobSales (J) and is automatically set in Ungerboeck.
        Type = issueType, //Use the Opportunity Type code from your user field.  This matches the value stored in Ungerboeck table column CR073_ISSUE_TYPE.
        UserText12 = newTxt12Value //Set the value in the user field property
      };
      myJob.JobUserFieldSets.Add(myUserField); //Then add it back into the JobModel object.  You can add multiple user field sets to the same job object before saving.

      return apiClient.Endpoints.Jobs.Add( myJob);
    }

    /// <summary>
    /// An example of editing the UserFields on an existing job.
    /// </summary>
    public JobsModel EditWithUserFields(string orgCode, int jobID, string issueType, string newText02Value, DateTime newDate02Value)
    {
      var myJob = apiClient.Endpoints.Jobs.Get( orgCode, jobID);

      //Here's how to edit a user field set with values on an existing job
      var myJobUDFSet = (from o in myJob.JobUserFieldSets where o.Type == issueType select o).FirstOrDefault();
      myJobUDFSet.UserText02 = newText02Value; //Set the value in the user field property
      myJobUDFSet.UserDateTime02 = newDate02Value; //Set the value in the user field property

      return apiClient.Endpoints.Jobs.Update(myJob);
    }

    /// <summary>
    /// This example is designed to show sample values to use in other editable properties.  For more information, see the model property info in the /api/help sandbox.
    /// </summary>
    public JobsModel EditAdvanced(string orgCode, int jobID)
    {
      const string myAccount = "RAYNOR";
      const string myParentAccount = "COMBINE";
      const string myContactAccount = "LSTRIDER";
      const int otherJobID = 11111;

      var myJob = apiClient.Endpoints.Jobs.Get( orgCode, jobID);

      myJob.Description = "Modified Description";
      myJob.SecondCoordinator = myAccount;
      myJob.ThirdCoordinator = myAccount;
      myJob.FourthCoordinator = myAccount;
      myJob.Account = "COMBINE"; //Just like in Ungerboeck, you may change the account even after an job is created.                                                                                                            
      myJob.ActualCost = 5;
      myJob.ActualRevenue = 5;
      myJob.BillTo = myParentAccount; //Account code of bill to account                                                                                                                                                 
      myJob.BillToContact = myContactAccount;  //Account code of bill-to contact                                                                                                                                        
      myJob.Category = "CO"; //Category code for job categories                                                                                                                                                       
      myJob.Class = "GARDL"; //Class code for job classes                                                                                                                                                               
      myJob.Contact = myContactAccount;
      myJob.Coordinator = myContactAccount;
      myJob.ForecastCost = 5;
      myJob.ForecastRevenue = 5;
      myJob.FunctionUserFieldsType = "BU|C"; //Code of Function User fields. It consists of [Issue Type]|[Issue Class].  This is populated from [CR158_ISSUE_TYPE]|[CR158_ISSUE_CLASS].                                 
      myJob.Indicator = "JB";
      myJob.Note1 = "Test";
      myJob.Note2 = "Test";
      myJob.OrderUserFieldsType = "CK|C"; //This is the code of Order User fields.  It consists of [Issue Type]|[Issue Class].  This is populated from [CR158_ISSUE_TYPE]|[CR158_ISSUE_CLASS].                          
      myJob.OrderedCost = 5;
      myJob.OrderedRevenue = 5;
      myJob.OtherActual = 5;
      myJob.OtherForecast = 5;
      myJob.OtherOrdered = 5;
      myJob.OtherRevised = 5;
      myJob.ParentJob = otherJobID;
      myJob.PriceList = "2001-STD";
      myJob.Public = "Y";
      myJob.RevisedCost = 5;
      myJob.RevisedRevenue = 5;
      myJob.Salesperson = myAccount;
      myJob.Search = "APISRCH";
      myJob.Status = "30";  //This is the code for statuses.  Filling this in may affect other fields based on the value.  Greater than 29 is firm, greater than 79 is considered cancelled.                            
      myJob.Type = "EDU";

      //Various date values                                                                                                                                                                                              
      myJob.StartDate = DateTime.Now.Date;
      myJob.StartTime = DateTime.Now;
      myJob.EndDate = DateTime.Now.Date.AddDays(1);
      myJob.EndTime = DateTime.Now;

      return apiClient.Endpoints.Jobs.Update( myJob);
    }

    /// <summary>
    /// This example is designed to show how to change the start/end dates and times.  For more information, see the model property info in the /api/help sandbox.
    /// </summary>
    public JobsModel EditDateTimes(string orgCode, int jobID)
    {
      var myJob = apiClient.Endpoints.Jobs.Get( orgCode, jobID);

      //Various date values                                                                                                                                                                                              
      myJob.StartDate = DateTime.Now.Date;
      myJob.StartTime = DateTime.Now;
      myJob.EndDate = DateTime.Now.Date.AddDays(1);
      myJob.EndTime = DateTime.Now;

      return apiClient.Endpoints.Jobs.Update( myJob);
    }
  }
}
