using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;


namespace AdvC_ncepts
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllText("./data.json");
            var datajson = JsonSerializer.Deserialize<List<DataPipe>>(data);
            foreach(var a in datajson)
            Console.WriteLine(a.data);

        }
    }
}
