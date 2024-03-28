using EnhanceMultisequenceLearning.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhanceMultisequenceLearning
{
    public class ModelTrainer
    {
        public static List<Report> RunMultiSequenceLearningExperiment(List<Sequence> sequences, List<Sequence> sequenceEval, List<Sequence> sequencesTest, bool isNumberDatatset, int index)
        {
            var reports = new List<Report>();
            var experiment = new MultiSequenceLearning();
            var predictor = experiment.Run(sequences, isNumberDatatset, index);

            foreach (Sequence item in sequenceEval)
            {
                var report = new Report
                {
                    SequenceName = item.name,
                    SequenceData = item.data
                };

                double accuracy = PredictNextElement(predictor, item.data, report);
                report.Accuracy = accuracy;
                reports.Add(report);

                Console.WriteLine($"Accuracy for {item.name} sequence: {accuracy}%");
            }

            foreach (Sequence item in sequencesTest)
            {
                var report = new Report
                {
                    SequenceName = item.name,
                    SequenceData = item.data
                };

                double accuracy = PredictNextElement(predictor, item.data, report);
                report.Accuracy = accuracy;
                reports.Add(report);

                Console.WriteLine($"Accuracy for {item.name} sequence: {accuracy}%");
            }

            return reports;
        }
    }
}
