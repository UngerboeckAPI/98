using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class DocumentClasses : Base
  {
    public DocumentClasses(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public DocumentClassesModel Get(string orgCode, string Class)
    {
      return apiClient.Endpoints.DocumentClasses.Get( orgCode, Class);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<DocumentClassesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.DocumentClasses.Search(orgCode, $"{nameof(DocumentClassesModel.Description)} eq '{searchValue}'");
    }
  }
}
