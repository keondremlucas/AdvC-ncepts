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
            bool loopOption = true;
            var data = File.ReadAllText("./data.json");
            var datajson = JsonSerializer.Deserialize<List<Data>>(data);
            Analytics analytics = new Analytics(datajson);
            
            
            while(loopOption){

                Console.WriteLine("Write 1 for column on column operations:");
                Console.WriteLine("Write 2 for single column operations:");
                var selectedOption = Int32.Parse(Console.ReadLine());

                if(selectedOption == 1){
                    Console.WriteLine("Type of operation: ( 1 for addition, 2 for division, 3 for multiplication, 4 for subtract )");
                    var typeOfOperation = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("First column:");
                    var column1 = Console.ReadLine();

                    Console.WriteLine("Second column:");
                    var column2 = Console.ReadLine();

                    var analyticsData = analytics.CombineColumn(column1, column2, typeOfOperation);
                    
                }

                if(selectedOption == 2){
                    Console.WriteLine("Type of operation: ( 1 for sqaure, 2 for add 5, 3 for devide by 7.3, 4 for square root, 5 for negation )");
                    var typeOfOperation = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("column:");
                    var column =(Console.ReadLine());


                    var analyticsData = analytics.ColumnOperation(column, typeOfOperation);
                    
                }


            }
            
        }
    }

}
