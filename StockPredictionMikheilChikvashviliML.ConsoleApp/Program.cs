using System;
using StockPredictionMikheilChikvashviliML.Model;

namespace StockPredictionMikheilChikvashviliML.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create single instance of sample data from first line of dataset for model input
            ModelInput sampleData = new ModelInput()
            {
                Open = 164.7F,
                High = 166.6F,
                Low = 161.97F,
                Volume = 8.34744E+07F,
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = ConsumeModel.Predict(sampleData);

            Console.WriteLine("Using model to make single prediction -- Comparing actual Close with predicted Close from sample data...\n\n");
            Console.WriteLine($"Open: {sampleData.Open}");
            Console.WriteLine($"High: {sampleData.High}");
            Console.WriteLine($"Low: {sampleData.Low}");
            Console.WriteLine($"Volume: {sampleData.Volume}");
            Console.WriteLine($"\n\nPredicted Close: {predictionResult.Score}\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}
