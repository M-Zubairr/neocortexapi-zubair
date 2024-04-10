using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhanceMultisequenceLearning.Data
{
    public class Report
    {
        public Report() { }

        public string SequenceName { get; set; }
        public int[] SequenceData { get; set; }
        public List<string> PredictionLog { get; set; }
        public double Accuracy { get; set; }
        public int Matches { get; set; }
        public int TotalPredictions {  get; set; }

    }
}
