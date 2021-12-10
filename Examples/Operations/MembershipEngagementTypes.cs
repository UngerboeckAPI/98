using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Sdk;

namespace Examples.Operations
{
  public class MembershipEngagementTypes : Base
  {
    public MembershipEngagementTypes(ApiClient apiClient) : base(apiClient)
    {
    }

    public MembershipEngagementTypesModel Get(int engagementTypeId)
    {
      return apiClient.Endpoints.MembershipEngagementTypes.Get( engagementTypeId);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<MembershipEngagementTypesModel> Search(string searchValue)
    {
      return apiClient.Endpoints.MembershipEngagementTypes.Search($"{nameof(MembershipEngagementTypesModel.Description)} eq '{searchValue}'");
    }

    public MembershipEngagementTypesModel Add(string orgCode,
                                              string description,
                                              int engagementClass,
                                              int engagementValueType,
                                              int engagementValue)
    {
      MembershipEngagementTypesModel membershipEngagementTypesModel = new MembershipEngagementTypesModel()
      {
        OrgCode = orgCode,
        Description = description,
        Class = engagementClass,
        ValueType = engagementValueType,
        Value = engagementValue
      };

      return apiClient.Endpoints.MembershipEngagementTypes.Add( membershipEngagementTypesModel);
    }

    public MembershipEngagementTypesModel Edit(int engagementTypeId, string engagementTypeDescription)
    {
      MembershipEngagementTypesModel membershipEngagementTypesModel = Get(engagementTypeId);

      membershipEngagementTypesModel.Description = engagementTypeDescription;

      return apiClient.Endpoints.MembershipEngagementTypes.Update( membershipEngagementTypesModel);
    }

    public MembershipEngagementTypesModel EditAdvanced(int engagementTypeId)
    {

      var myMembershipEngagementType = apiClient.Endpoints.MembershipEngagementTypes.Get( engagementTypeId);

      myMembershipEngagementType.OrgCode = "10";
      myMembershipEngagementType.Description = "Woah New EngagementTypes Description";
      myMembershipEngagementType.Class = 2;
      myMembershipEngagementType.ValueType = 1;
      myMembershipEngagementType.Value = 10;

      return apiClient.Endpoints.MembershipEngagementTypes.Update( myMembershipEngagementType);
    }

    public void Delete(int engagementTypeId)
    {
      apiClient.Endpoints.MembershipEngagementTypes.Delete(engagementTypeId);
    }
  }
}
