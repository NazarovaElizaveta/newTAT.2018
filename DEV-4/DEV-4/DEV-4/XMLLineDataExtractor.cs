using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_4
{
  /// <summary>
  /// This class for extract XML line data.
  /// </summary>
  public class XMLLineDataExtractor
  {
    public List<XMLLineData> Extract(string xmlLine)
    {
      int position = 0;
      List<XMLLineData> listXMLLineData = new List<XMLLineData>();
      xmlLine = xmlLine.Trim();
      while (position < (xmlLine.Length - 1))
      {
        listXMLLineData.Add(ExtractDataPortion(xmlLine, ref position));
      }
      return listXMLLineData;
    }

    private XMLLineData ExtractDataPortion(string xmlLine, ref int position)
    {
      int startPos = xmlLine.IndexOf('<', position);
      int endPos = xmlLine.IndexOf('>', position);

      if (startPos > position)
      {
        String result = xmlLine.Substring(position + 1, startPos - position - 1);
        position = startPos;
        return new XMLLineData(result, XMLLineDataType.RawData);
      }

      if (endPos == startPos)
      {
        position = xmlLine.Length;
        return new XMLLineData(xmlLine, XMLLineDataType.RawData);
      }

      XMLLineDataType type = (xmlLine[++startPos] == '/') ? XMLLineDataType.CloseNode : XMLLineDataType.OpenNode;

      position = endPos;
      if (type == XMLLineDataType.CloseNode)
      {
        startPos++;
      }
      return new XMLLineData(xmlLine.Substring(startPos, endPos - startPos), type);
    }
  }
}
