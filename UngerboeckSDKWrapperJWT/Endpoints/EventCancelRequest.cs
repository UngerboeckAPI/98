using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;

/// <summary>
/// Find endpoint calls for this subject here.
/// </summary>
namespace Ungerboeck.Api.Sdk.Endpoints
{
  public class EventCancelRequest : Base<EventCancelRequestModel>
  {
    protected internal EventCancelRequest(ApiClient api) : base(api) { }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public EventCancelRequestModel Get(string orgCode, int eventID, Ungerboeck.Api.Models.Options.Subjects.EventCancelRequest options = null)
    {
      return base.Get(new { orgCode, eventID }, options);
    }
  }
}

