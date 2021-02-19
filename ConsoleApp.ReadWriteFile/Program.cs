using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp.ReadWriteFile
{
  class Program
  {
    static void Main(string[] args)
    {
      List<string> RecordList = new List<string>();
      long Id = 123456789;
      int Record = 15;

      ReadFile(RecordList);

      CheckRecord(RecordList, Id, Record);

      WriteFile(RecordList);
    }
    static void CheckRecord(List<string> recordList, long id, int record)
    {
      string oldRecord = "";
      int indexOfRecordLine = recordList.Count;
      foreach (var item in recordList)
      {
        int indexOfSeparator;
        if(item.Contains($"{id}"))
        {
          indexOfRecordLine = recordList.IndexOf(item);
          indexOfSeparator = item.IndexOf(":");
          for (int i = indexOfSeparator + 1; i < item.Length; i++)
          {
            oldRecord += item[i];
          }
        }
      }
      if(int.Parse(oldRecord) < record)
      {
        recordList[indexOfRecordLine] = $"{id}:{record}";
      }
      //return recordList;
    }




    static void ReadFile(List<string> recordList)
    {
      recordList.Clear();
      using(StreamReader sr = new StreamReader("FileToRead.txt"))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
          recordList.Add(line);
        }
      }
      //return recordList;
    }





    static void WriteFile(List<string> recordList)
    {
      using (StreamWriter sw = new StreamWriter("FileToWrite.txt", false)) /* false for rewrite file */
      {
        foreach (var item in recordList)
        {
          sw.WriteLine(item);
        }
      }
    }








  }
}
