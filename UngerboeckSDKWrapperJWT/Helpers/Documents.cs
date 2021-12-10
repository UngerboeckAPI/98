using System;
using System.Collections.Generic;
using System.Text;

namespace Ungerboeck.Api.Sdk.Helpers
{
  public static class Documents
  {
    ///<summary>
    ///Convert base 64 string to byte array in chunks based on a multiple of 3.  This is done to prevent a system out of memory exception.
    ///</summary>
    ///<param name="astrBytes"></param>
    ///<returns></returns>

    public static byte[] DecodeStringForDocuments(string astrBytes)
    {
      byte[] objBytes = null;
      byte[] objBuffer = new byte[6479];

      if (!string.IsNullOrEmpty(astrBytes))
      {
        using (System.IO.MemoryStream objInputMemStream = new System.IO.MemoryStream())
        {
          using (System.IO.StreamWriter objStreamWriter = new System.IO.StreamWriter(objInputMemStream))
          {
            objStreamWriter.Write(astrBytes);
            objStreamWriter.Flush();
            objInputMemStream.Position = 0;
            using (System.IO.MemoryStream objOutputMemStream = new System.IO.MemoryStream())
            {
              int intBytesRead = objInputMemStream.Read(objBuffer, 0, objBuffer.Length);
              while (intBytesRead > 0)
              {
                string strBase64Chunk = Encoding.UTF8.GetString(objBuffer, 0, intBytesRead);
                byte[] objByteChunk = Convert.FromBase64String(strBase64Chunk);
                objOutputMemStream.Write(objByteChunk, 0, objByteChunk.Length);
                intBytesRead = objInputMemStream.Read(objBuffer, 0, objBuffer.Length);
              }

              objBytes = objOutputMemStream.ToArray();
            }
          }
        }
      }

      return objBytes;
    }

    ///<summary>
    ///Convert a byte array into a base 64 string in chunks based on a multiple of 3.  This is done to help prevent a system out of memory exception.
    ///</summary>
    ///<param name="aobjBytes"></param>
    ///<returns></returns>
    public static string GetEncodedStringForDocuments(byte[] aobjBytes)
    {
      const int intChunk = 6480;
      var sbEncodedBytes = new StringBuilder();

      if (aobjBytes != null && aobjBytes.Length > 0)
      {
        if (aobjBytes.Length <= intChunk)
        {
          sbEncodedBytes.Append(Convert.ToBase64String(aobjBytes));
        }
        else
        {
          for (int i = 0; i <= (aobjBytes.Length - 1); i += intChunk)
          {
            sbEncodedBytes.Append(Convert.ToBase64String(Slice(aobjBytes, i, i + intChunk)));
          }

        }

      }

      return sbEncodedBytes.ToString();
    }

    private static byte[] Slice(byte[] source, int startIndex, int endIndex)
    {
      int length;
      byte[] slice = null;
      if (source != null && source.Length > 0 && startIndex >= 0 && endIndex > startIndex)
      {
        if (endIndex > (source.Length - 1))
        {
          length = (source.Length - startIndex);
        }
        else
        {
          length = (endIndex - startIndex);
        }

        if (length > 0)
        {
          slice = new byte[length - 1 + 1];
          for (int i = 0; i <= length - 1; i++)
          {
            slice[i] = source[i + startIndex];
          }
        }
      }

      return slice;
    }
  }
}
