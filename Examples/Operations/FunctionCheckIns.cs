using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class FunctionCheckIns : Base
  {
    public FunctionCheckIns(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public FunctionCheckInsModel Get(int sequence)
    {
      return apiClient.Endpoints.FunctionCheckIns.Get( sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<FunctionCheckInsModel> Search(int searchValue)
    {
      return apiClient.Endpoints.FunctionCheckIns.Search($"{nameof(FunctionCheckInsModel.Event)} eq {searchValue}");
    }

    /// <summary>
    /// A retrieve by odata query.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<FunctionCheckInsModel> RetrieveByOData(string oData)
    {
      return apiClient.Endpoints.FunctionCheckIns.Search(oData).Results;
    }

    /// <summary>
    /// This is shows how you perform a Function Check In on a registrant
    /// </summary>
    /// <param name="orgCode">Organization Code</param>
    /// <param name="checkInDateTime">Check-in date</param>
    /// <param name="checkInNote">Check-in note, can be empty</param>
    /// <param name="orderNumber">Registrant order number</param>
    /// <param name="eventId">Event number</param>
    /// <param name="functionId">Registrant function ID</param>
    /// <param name="regSequenceNbr">Order registrant sequnce number</param>
    /// <param name="regAcct">Order registrant account code</param>
    public FunctionCheckInsModel Add(string orgCode,
                                    DateTime checkInDateTime,
                                    string checkInNote,
                                    int orderNumber,
                                    int eventId,
                                    int functionId,
                                    int regSequenceNbr)
    {

      FunctionCheckInsModel functionCheckInModel = new FunctionCheckInsModel
      {
        OrganizationCode = orgCode,
        CheckIn = checkInDateTime,
        CheckInNote = checkInNote,
        OrderNumber = orderNumber,
        Event = eventId,
        Function = functionId,
        RegistrantSequence = regSequenceNbr
      };

      return apiClient.Endpoints.FunctionCheckIns.Add( functionCheckInModel);
    }

    /// <summary>
    /// This is shows how you perform a Function Check Out on a registrant
    /// </summary> 
    public FunctionCheckInsModel Edit(int sequence, string checkInNote)
    {
      FunctionCheckInsModel functionCheckInModel = apiClient.Endpoints.FunctionCheckIns.Get( sequence);

      functionCheckInModel.CheckInNote = checkInNote;

      return apiClient.Endpoints.FunctionCheckIns.Update( functionCheckInModel);
    }

    public FunctionCheckInsModel EditAdvanced(int sequence, DateTime checkOutDate, int functionId)
    {
      FunctionCheckInsModel functionCheckInModel = apiClient.Endpoints.FunctionCheckIns.Get( sequence);

      functionCheckInModel.CheckOut = checkOutDate;
      functionCheckInModel.CheckInNote = "ABC was here";
      functionCheckInModel.Function = functionId;

      return apiClient.Endpoints.FunctionCheckIns.Update( functionCheckInModel);
    }


    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(int sequence)
    {
      apiClient.Endpoints.FunctionCheckIns.Delete( sequence);
    }
  }
}
