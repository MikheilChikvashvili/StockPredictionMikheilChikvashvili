using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using StockPredictionMikheilChikvashviliML.Model;
using System.Linq;

namespace StockPredictionTest
{
    [TestClass]
    public class PredictionTest
    {

        [TestMethod]
        public void TestMethod1()
        {
            var reader = new StreamReader(@"..\..\..\MacroTrends_Data_Download_AAPLCSV.csv");

            int offset = 9765;
            string[][] cells = new string[824][];
            int index = 0;
            while (!reader.EndOfStream)
            {
                if (offset > 0)
                {
                    reader.ReadLine();
                    offset--;
                    continue;
                }

                cells[index] = reader.ReadLine().Split(',');
                index++;
            }

            ModelInput input = new ModelInput();
            float[] deviations = new float[cells.Length];
            float min = float.MaxValue;
            float max = float.MinValue;
            for (int i = 0; i < cells.Length; i++)
            {
                input.Open = float.Parse(cells[i][1]);
                input.Low = float.Parse(cells[i][3]);
                input.High = float.Parse(cells[i][2]);
                input.Volume = float.Parse(cells[i][5]);

                var predictionResult = ConsumeModel.Predict(input);
                float close = float.Parse(cells[i][4]);
                deviations[i] = (Math.Abs(close - predictionResult.Score) / close) * 100;
                if ((Math.Abs(close - predictionResult.Score) / close) * 100 < min)
                {
                    min = (Math.Abs(close - predictionResult.Score) / close) * 100;
                }
                if ((Math.Abs(close - predictionResult.Score) / close) * 100 > max)
                {
                    max = (Math.Abs(close - predictionResult.Score) / close) * 100;
                }
            }

            float stdDeviation = 0.0F;
            float avrg = deviations.Average();
            foreach (float i in deviations)
            {
                stdDeviation += (float)Math.Pow(i - avrg, 2.0);
            }
            stdDeviation = (float)Math.Sqrt((stdDeviation / (cells.Length)));
            Array.Sort(deviations);
            float median = (deviations[deviations.Length / 2] + deviations[deviations.Length / 2 + 1]) / 2;

            if (stdDeviation > 3)
            {
                throw (new Exception());
            }

            if (median > 3)
            {
                throw (new Exception());
            }
        }
    }
}