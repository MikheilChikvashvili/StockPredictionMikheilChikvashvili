using Microsoft.ML.Data;

namespace StockPredictionMikheilChikvashviliML.Model
{
    public class ModelInput
    {
        [ColumnName("ID"), LoadColumn(0)]
        public float ID { get; set; }


        [ColumnName("Date"), LoadColumn(1)]
        public string Date { get; set; }


        [ColumnName("Open"), LoadColumn(2)]
        public float Open { get; set; }


        [ColumnName("High"), LoadColumn(3)]
        public float High { get; set; }


        [ColumnName("Low"), LoadColumn(4)]
        public float Low { get; set; }


        [ColumnName("Close"), LoadColumn(5)]
        public float Close { get; set; }


        [ColumnName("Volume"), LoadColumn(6)]
        public float Volume { get; set; }


    }
}
