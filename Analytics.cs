using System;
using System.Linq;
using System.Collections.Generic;


namespace AdvC_ncepts{
    public class Analytics{
        private List<Data> _data;
        public Analytics(List<Data> data){
            _data = data;
        }
        Func<int, int, double> sum = (a, b) => a+b ;
        Func<double, double, double> division = (a, b) => a/b ;
        Func<int, int, double> multiply = (a, b) => a*b ;
        Func<int, int, double> subtract = (a, b) => a-b ;
        Func<int, double> squareRoot = (a) => Math.Sqrt(a);

        public IEnumerable<CorrectedData> CombineColumn(string column1, string column2, int operationType){
            
            List<CorrectedData> resColumn = new List<CorrectedData>();

            foreach (var item in _data)
            {
                var col1 = (int) typeof(Data).GetProperty(column1).GetValue(item);
                var col2 = (int) typeof(Data).GetProperty(column2).GetValue(item);
                var res = operationType==1? sum(col1, col2): operationType==2? division(col1, col2): operationType==3? multiply(col1, col2)
                : operationType==4? subtract(col1, col2):throw new Exception();
                CorrectedData correctedData = new CorrectedData(item.A, item.B, item.C, res);
                resColumn.Add(correctedData);

            }
            
            if(resColumn.Count > 0){

                foreach (var item in resColumn)
                {
                    Console.WriteLine(item);
                }
                
            }


            // var colA = (from c in _data select c.A).ToList();
            // var colB = (from c in _data select c.B).ToList();
            // var colC = (from c in _data select c.C).ToList();

            // switch ((column1, column2))
            // {
            //     case ('A','B'):
            //     for(int index = 0; index < colA.Count; index++){
            //          resColumn.Add(sum(colA[index], colB[index]));
            //     }
            //     break;
            //     case ('A','C'):
            //     for(int index = 0; index < colA.Count; index++){
            //          resColumn.Add(sum(colA[index], colC[index]));
            //     }
            //     break;
            //     case ('B','C'):
            //     for(int index = 0; index < colB.Count; index++){
            //          resColumn.Add(sum(colB[index], colC[index]));
            //     }
            //     break;
               
                
            // }


            return resColumn;
        }

        public IEnumerable<Data> ColumnOperation(string column, int operationType){
            List<Data> resColumn = new List<Data>();
            
            foreach (var item in _data)
            {
                var col = (int) typeof(Data).GetProperty(column).GetValue(item);
                var res = operationType==1? multiply(col, col): operationType==2? sum(col, 5): operationType==3? division(col, 7.3)
                : operationType==4? squareRoot(col): operationType==5? multiply(col, -1):throw new ArgumentException("Opeation type incorrect");
                // var overrideCol = (int) typeof(Data).GetProperty(column).GetValue(item);

                Data newData;
                if(column == "A"){
                    newData = new Data((int)res, item.B, item.C);
                    resColumn.Add(newData);
                }else
                if(column == "B"){
                    newData = new Data(item.A, (int)res, item.C);
                    resColumn.Add(newData);
                }else
                if(column == "C"){
                    newData = new Data(item.A, item.B, (int)res);
                    resColumn.Add(newData);
                }
            
            }

             if(resColumn.Count > 0){

                foreach (var item in resColumn)
                {
                    Console.WriteLine(item);
                }
                
            }


            return resColumn;
        }

    }
}