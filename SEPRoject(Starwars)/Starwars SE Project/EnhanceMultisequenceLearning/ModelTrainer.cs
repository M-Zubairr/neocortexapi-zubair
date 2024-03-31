using EnhanceMultisequenceLearning.Data;
using NeoCortexApi;

namespace EnhanceMultisequenceLearning
{
    public class ModelTrainer
    {
        /// <summary>
        /// Runs a multi-sequence learning experiment using the provided sequences, evaluates the performance
        /// on the evaluation sequences, and reports the accuracy. Additionally, evaluates the performance on
        /// the test sequences and reports the accuracy.
        /// </summary>
        /// <param name="sequences">List of training sequences.</param>
        /// <param name="sequenceEval">List of evaluation sequences.</param>
        /// <param name="sequencesTest">List of test sequences.</param>
        /// <param name="isNumberDatatset">Boolean indicating whether the dataset consists of numerical data.</param>
        /// <param name="index">Index parameter (if applicable).</param>
        /// <returns>List of reports containing accuracy information for each evaluated sequence.</returns>
        public static List<Report> RunMultiSequenceLearningExperiment(List<Sequence> sequences, List<Sequence> sequenceEval, List<Sequence> sequencesTest, bool isNumberDatatset, int index)
        {
            var reports = new List<Report>();
            var experiment = new MultiSequenceLearning();
            var predictor = experiment.Run(sequences, isNumberDatatset, index);

            // Evaluate performance on evaluation sequences
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
            // Evaluate performance on test sequences
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
        /// <summary>
        /// Predicts the next element in a sequence using the provided predictor, evaluates the accuracy of the predictions,
        /// and generates prediction logs for each prediction made.
        /// </summary>
        /// <param name="predictor">The predictor used for making predictions.</param>
        /// <param name="list">The input sequence for which predictions are made.</param>
        /// <param name="report">The report object to store prediction logs.</param>
        /// <returns>The accuracy of the predictions.</returns>
        private static double PredictNextElement(Predictor predictor, int[] list, Report report)
        {
            int matchCount = 0, predictions = 0;
            List<string> logs = new List<string>();

            predictor.Reset();

            for (int i = 0; i < list.Length - 1; i++)
            {
                int current = list[i];
                int next = list[i + 1];

                logs.Add(PredictElement(predictor, current, next, ref matchCount));
                predictions++;
            }

            report.PredictionLog = logs;
            return CalculateAccuracy(matchCount, predictions);
        }
        /// <summary>
        /// Predicts the next element in a sequence using the provided predictor based on the current element
        /// </summary>
        /// <param name="predictor">The predictor used for making predictions.</param>
        /// <param name="current">The current element in the sequence.</param>
        /// <param name="next">The next element in the sequence (ground truth).</param>
        /// <param name="matchCount">A reference to the count of correct predictions to be updated.</param>
        /// <returns>A string representing the prediction and its accuracy.</returns>
        private static string PredictElement(Predictor predictor, int current, int next, ref int matchCount)
        {
            Console.WriteLine($"Input: {current}");
            var predictions = predictor.Predict(current);
            // Check if predictions are made
            if (predictions.Any())
            {
                // Get the highest similarity prediction
                var highestPrediction = predictions.OrderByDescending(p => p.Similarity).First();
                string predictedSequence = highestPrediction.PredictedInput.Split('-').First();
                int predictedNext = int.Parse(highestPrediction.PredictedInput.Split('-').Last());

                Console.WriteLine($"Predicted Sequence: {predictedSequence} - Predicted next element: {predictedNext}");
                if (predictedNext == next)
                    matchCount++;

                return $"Input: {current}, Predicted Sequence: {predictedSequence}, Predicted next element: {predictedNext}";
            }
            else
            {
                Console.WriteLine("Nothing predicted");
                return $"Input: {current}, Nothing predicted";
            }
        }
        /// <summary>
        /// Calculates the accuracy of predictions based on the number of correct predictions and the total number of predictions made.
        /// </summary>
        /// <param name="matchCount">The number of correct predictions.</param>
        /// <param name="predictions">The total number of predictions made.</param>
        /// <returns>The accuracy percentage of the predictions.</returns>
        private static double CalculateAccuracy(int matchCount, int predictions)
        {
            return (double)matchCount / predictions * 100;
        }
    }
}
