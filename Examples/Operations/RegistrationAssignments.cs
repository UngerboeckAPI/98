using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class RegistrationAssignments : Base
  {
    public RegistrationAssignments(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    /// <param name="orgCode">Registration Assignment Organization Code.</param>
    /// <param name="sequenceNumber">Registration Assignment Primary key.</param>
    public RegistrationAssignmentsModel Get(string orgCode, int sequenceNumber)
    {
      return apiClient.Endpoints.RegistrationAssignments.Get( orgCode, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    /// <param name="orgCode">Registration Assignments Organization Code.</param>
    public SearchResponse<RegistrationAssignmentsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.RegistrationAssignments.Search(orgCode, $"{nameof(RegistrationAssignmentsModel.OrderNumber)} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example
    /// </summary>  
    /// <param name="orgCode">Registration Assignment Organization Code.</param>
    /// <param name="layoutSeq">The primary key for the function seating chart in which this Registration Assignment is on.</param>
    /// <param name="seatQuantity">The assignments seat quantity.</param>
    /// <param name="orderNumber">The order number for which this Registration Assignment was placed on.</param>
    /// <param name="orderLine">The order line for which this Registration Assignment was placed on.</param>
    /// <param name="assignmentNote">Assignment Note.</param>
    public RegistrationAssignmentsModel Add(string orgCode, int layoutSeq, int seatQuantity, 
                                            int orderNumber, int orderLine, string assignmentNote)
    {
      var myRegistrationAssignment = new RegistrationAssignmentsModel
      {
        OrgCode = orgCode,
        AssignmentNote = assignmentNote,
        LayoutSequence = layoutSeq,
        SeatQuantity = seatQuantity,
        OrderNumber = orderNumber,
        OrderLine = orderLine
      };

      return apiClient.Endpoints.RegistrationAssignments.Add( myRegistrationAssignment);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    /// <param name="orgCode">Registration Assignment Organization Code.</param>
    /// <param name="sequenceNumber">Registration Assignment Primary key.</param>
    /// <param name="seatQuantity">New Registration Assignment seat quantity.</param>
    /// <param name="newAssignmentNote">New Registration Assignment Note.</param>
    public RegistrationAssignmentsModel Edit(string orgCode, int sequenceNumber, int seatQuantity, string newAssignmentNote)
    {
      var myRegistrationAssignment = apiClient.Endpoints.RegistrationAssignments.Get( orgCode, sequenceNumber);

      myRegistrationAssignment.AssignmentNote = newAssignmentNote;
      myRegistrationAssignment.SeatQuantity = seatQuantity;

      return apiClient.Endpoints.RegistrationAssignments.Update( myRegistrationAssignment);
    }

    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, int sequenceNumber)
    {
      apiClient.Endpoints.RegistrationAssignments.Delete(orgCode, sequenceNumber);
    }

  }
}
