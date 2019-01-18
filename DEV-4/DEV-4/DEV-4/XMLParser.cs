using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DEV_4
{
  /// <summary>
  /// This class parses XMLFile.
  /// </summary>
  class XMLParser
  {
    static void Main(string[] args)
    {      
      if (args.Length != 1)
      {
        Console.WriteLine("Wrong number of arguments");
        return;
      }      
      string pathXMLFile = args[0];
      StreamReader file = new System.IO.StreamReader(pathXMLFile);      
      string xmlLine;

      XMLLineDataExtractor dataExtractor = new XMLLineDataExtractor();

      List<XMLLineData> dataList = new List<XMLLineData>();

      while ((xmlLine = file.ReadLine()) != null)
      {
        dataList.InsertRange(dataList.Count, dataExtractor.Extract(xmlLine));
      }

      XMLTagsProcessor tagsProcessor = new XMLTagsProcessor(dataList);
      var tagsList = tagsProcessor.CreateTagsList();
      tagsList.Sort();

      foreach (var data in tagsList)
      {
        Console.WriteLine(data);
      }

      var attributesList = tagsProcessor.CreateAtrributesList();
      attributesList.Sort();

      foreach (var data in attributesList)
      {
        Console.WriteLine(data);
      }
    }
  }
}
