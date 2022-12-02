using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using StockPredictionMikheilChikvashviliML.Model;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;

namespace StockPredictionTest
{
    [TestClass]
    public class PredictionTest
    {
        
        [TestMethod]
        public void TestMethod1()
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\user\Downloads\MacroTrends_Data_Download_AAPL.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            ModelInput input = new ModelInput();

            float min = float.MaxValue;
            float max = float.MinValue;
            float[] deviations = new float[rowCount-9765];
            for(int i = 9765; i < rowCount; i++)
            {
                input.Open = (float)(xlRange.Cells[i, 2] as Excel.Range).Value2;
                input.Low = (float)(xlRange.Cells[i, 4] as Excel.Range).Value2;
                input.High = (float)(xlRange.Cells[i, 3] as Excel.Range).Value2;
                input.Volume = (float)(xlRange.Cells[i, 6] as Excel.Range).Value2;

                var predictionResult = ConsumeModel.Predict(input);
                float close = (float)(xlRange.Cells[i, 5] as Excel.Range).Value2;
                deviations[i - 9765] = (Math.Abs(close - predictionResult.Score) / close)*100;
                if ((Math.Abs(close - predictionResult.Score)/close)*100 < min)
                {
                    min = (Math.Abs(close - predictionResult.Score)/close)*100;
                }
                if ((Math.Abs(close - predictionResult.Score)/close)*100 > max)
                {
                    max = (Math.Abs(close - predictionResult.Score)/close)*100;
                }
            }

            float stdDeviation = 0.0F;
            float avrg = deviations.Average();
            foreach(float i in deviations)
            {
                stdDeviation += (float)Math.Pow(i - avrg, 2.0);
            }
            stdDeviation = stdDeviation / (rowCount - 9765);
            Array.Sort(deviations);
            float median = (deviations[deviations.Length/2] + deviations[deviations.Length/2+1])/2;

            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
    }
}
