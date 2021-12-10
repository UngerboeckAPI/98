using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Ungerboeck.Api.Sdk.Helpers
{
  public static class Errors
  {
    public static string GetAPIErrorMessage(Exception ex)
    {
      //Depending on when the exception is thrown, it may change the exception type.
      // Errors created during an async / await call get wrapped as an AggregateException
      if (ex.GetType() == typeof(AggregateException))
      {
        return ((AggregateException)ex).InnerExceptions.FirstOrDefault()?.Message;
      }
      
      return ex.Message;
    }
  }
}
