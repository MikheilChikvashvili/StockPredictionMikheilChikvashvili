using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockPredictionMikheilChikvashvili.Models
{
    public class Stocks
    {
        public float ID { get; set; }

        public string Date { get; set; }

        public float Open { get; set; }

        public float High { get; set; }

        public float Low { get; set; }

        public float Close { get; set; }

        public float Volume { get; set; }

    }
}
