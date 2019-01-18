using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_4
{
  /// <summary>
  /// This class for XML tags processor.
  /// </summary>
  public class XMLTagsProcessor
  {
    List<XMLLineData> XMLDataList { get; set; }

    public XMLTagsProcessor(List<XMLLineData> XMLDataList)
    {
      this.XMLDataList = XMLDataList;
    }

    /// <summary>
    /// This list for create tags list.
    /// </summary>
    /// <returns>Our tags list.</returns>
    public List<String> CreateTagsList()
    {
      List<String> tagsList = new List<String>();
      List<String> openedNodes = new List<String>();

      for (int i = 1; i < XMLDataList.Count; i++)
      {
        var data = XMLDataList[i];

        if (data.DataType == XMLLineDataType.OpenNode)
        {
          openedNodes.Add(data.Data);
          continue;
        }

        if (data.DataType == XMLLineDataType.RawData)
        {
          StringBuilder resultBuilder = new StringBuilder();
          foreach (String str in openedNodes)
          {
            var node = str;            
            int spaceIndex = node.IndexOf(' ');

            if (spaceIndex != -1)
            {
              node = node.Substring(0, spaceIndex);
            }

            resultBuilder.Append(node);
            resultBuilder.Append('-');
          }
          resultBuilder.Append(data.Data);
          tagsList.Add(resultBuilder.ToString());
          continue;
        }
        openedNodes.RemoveAt(openedNodes.Count - 1);
      }
      return tagsList;
    }

    /// <summary>
    /// This list for create attributes list.
    /// </summary>
    /// <returns>Our create attribute list.</returns>
    public List<String> CreateAtrributesList()
    {
      List<String> attribList = new List<String>();
      List<String> openedNodes = new List<String>();

      XMLAttributesExtractor extractor = new XMLAttributesExtractor();

      for (int i = 1; i < XMLDataList.Count; i++)
      {
        var data = XMLDataList[i];

        if (data.DataType == XMLLineDataType.OpenNode)
        {
          var node = data.Data;

          int spaceIndex = node.IndexOf(' ');
          if (spaceIndex != -1)
          {
            node = node.Substring(0, spaceIndex);
          }
          openedNodes.Add(node);
          if (spaceIndex != -1)
          {
            var attributes = extractor.Extract(data.Data.Substring(spaceIndex + 1, data.Data.Length - spaceIndex - 1));
            StringBuilder resultBuilder = new StringBuilder();
            foreach (String str in openedNodes)
            {
              resultBuilder.Append(str);
              resultBuilder.Append('-');
            }

            foreach (var attribute in attributes)
            {
              StringBuilder builder = new StringBuilder(resultBuilder.ToString());
              builder.Append(attribute.Name);
              builder.Append('-');
              builder.Append(attribute.Value);
              attribList.Add(builder.ToString());
            }
          }
          continue;
        }

        if (data.DataType == XMLLineDataType.CloseNode)
        {
          openedNodes.RemoveAt(openedNodes.Count - 1);
        }
      }
      return attribList;
    }
  }
}
