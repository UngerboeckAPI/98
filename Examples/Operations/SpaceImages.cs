using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace Examples.Operations
{
  public class SpaceImages : Base
  {
    //25x25px squares of a single color in string form
    private const string GreenSquareImage =  "iVBORw0KGgoAAAANSUhEUgAAABkAAAAZCAIAAABLixI0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAtSURBVEhLY1Ta6MNAJcAEpakBRs0iDYyaRRoYNYs0MGoWaWDULNLA8DeLgQEAESsBUW1yWckAAAAASUVORK5CYIIA";
    private const string PurpleSquareImage = "iVBORw0KGgoAAAANSUhEUgAAABkAAAAZCAIAAABLixI0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAApSURBVEhLY1jsuYRaaNQs0tCoWaShUbNIQ6NmkYZGzSINjZpFCvJcAgDPs9C+PWMg4QAAAABJRU5ErkJgggA=";

    public SpaceImages(ApiClient apiClient) : base(apiClient) { }


    public SpaceImagesModel Get(string orgCode, int id)
    {
      return apiClient.Endpoints.SpaceImages.Get( orgCode, id);
    }

    public SearchResponse<SpaceImagesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.SpaceImages.Search(orgCode, $"{nameof(SpaceImagesModel.Description)} eq '{searchValue}'");
    }

    public SpaceImagesModel Add(string orgCode, string space)
    {
      var spaceImage = new SpaceImagesModel
      {
        OrgCode = orgCode,
        Space = space,
        MainImage = Ungerboeck.Api.Sdk.Helpers.Documents.DecodeStringForDocuments(GreenSquareImage),
        ThumbnailImage = Ungerboeck.Api.Sdk.Helpers.Documents.DecodeStringForDocuments(PurpleSquareImage),
        Description = "A new space image",
        AltTextMain = "A green square",
        AltTextThumbnail = "A purple square",
        Sequence = 1,
        AltTextAlternateDescription1Main = "An alternate description of the green square",
        AltTextAlternateDescription1Thumbnail = "An alternate description of the purple square"
      };

      return apiClient.Endpoints.SpaceImages.Add( spaceImage);
    }

    public SpaceImagesModel Edit(string orgCode, int id, string newText)
    {
      var spaceImage = apiClient.Endpoints.SpaceImages.Get( orgCode, id);

      spaceImage.Description = newText;

      return apiClient.Endpoints.SpaceImages.Update( spaceImage);
    }

    public void Delete(string orgCode, int id)
    {
      apiClient.Endpoints.SpaceImages.Delete( orgCode, id);
    }

    /// <summary>
    /// Example of how to update the image document on a space image
    /// </summary>
    /// <param name="spaceImage">SpaceImage model.  Use a GET to fetch an existing space image.</param>
    /// <param name="newImage">a Byte array representing the new image</param>
    /// <returns>an encoded string representing the image</returns>
    public string ChangeImage(SpaceImagesModel spaceImage, byte[] newImage)
    {
      spaceImage.MainImage = newImage;

      spaceImage = apiClient.Endpoints.SpaceImages.Update(spaceImage);

      return Ungerboeck.Api.Sdk.Helpers.Documents.GetEncodedStringForDocuments(spaceImage.MainImage);
    }
  }
}
