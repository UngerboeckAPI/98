using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class GLSources : Base
  {
    public GLSources(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public GLSourcesModel Get(string orgCode,string source)
    {
      return apiClient.Endpoints.GLSources.Get( orgCode, source);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<GLSourcesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.GLSources.Search(orgCode, $"{nameof(GLSourcesModel.Description)} eq '{searchValue}'");
    }
  }
}

