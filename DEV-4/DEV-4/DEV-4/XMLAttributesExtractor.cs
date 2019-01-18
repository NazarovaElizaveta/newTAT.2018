using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_4
{
  /// <summary>
  /// This class for XML attributes extractor.
  /// </summary>
  public class XMLAttributesExtractor
  {
    /// <summary>
    /// This list for extract XML attribute.
    /// </summary>    
    /// <returns>Our attribute list</returns>
    public List<XMLAttribute> Extract(string line)
    {
      List<XMLAttribute> attributeList = new List<XMLAttribute>();

      int position = 0;
      while (position < line.Length - 1)
      {
        int newPosition = line.IndexOf('=', position);
        var attribute = new XMLAttribute();
        attribute.Name = line.Substring(position, newPosition - position);

        int valuePosition = line.IndexOf('\"', newPosition + 2);
        attribute.Value = line.Substring(newPosition + 2, valuePosition - newPosition - 2);
        position = valuePosition;
        attributeList.Add(attribute);
      }
      return attributeList;
    }
  }
}
