using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Departments : Base
  {
    public Departments(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public DepartmentsModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.Departments.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<DepartmentsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Departments.Search(orgCode, $"{nameof(DepartmentsModel.Description)} eq '{searchValue}'");
    }
  }
}
