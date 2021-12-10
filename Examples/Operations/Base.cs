using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Ungerboeck.Api.Sdk;

namespace Examples.Operations
{
    public class Base
    {
    protected readonly ApiClient apiClient;

    protected Base(ApiClient apiClient)
    {
      this.apiClient = apiClient;
    }
  }    
}
