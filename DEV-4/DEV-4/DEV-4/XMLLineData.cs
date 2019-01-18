using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_4
{
  /// <summary>
  /// Enum of XML line data type.
  /// </summary>
  public enum XMLLineDataType
  {
    OpenNode,
    CloseNode,
    RawData
  } 
  /// <summary>
  /// This class for XML line data.
  /// </summary>
  public class XMLLineData
  {
    public XMLLineDataType DataType { get; set; }
    public string Data { get; set; }

    public XMLLineData(string data, XMLLineDataType type)
    {
      DataType = type;
      Data = data;
    }

    public override string ToString()
    {
      return Data;
    }
  }
}
