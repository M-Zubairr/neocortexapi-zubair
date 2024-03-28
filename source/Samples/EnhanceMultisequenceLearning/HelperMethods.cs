using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhanceMultisequenceLearning
{
    public class HelperMethods
    {
        /// <summary>
        /// Transforms a list of SequenceString into a list of Sequence.
        /// </summary>
        /// <param name="data">The list of SequenceString to transform.</param>
        /// <returns>A list of Sequence objects.</returns>
        public static List<Sequence> TransformData(List<SequenceString> data)
        {
            if (data == null)
                throw new ArgumentNullException();

            List<Sequence> transformedData = new List<Sequence>();
            foreach (var x in data)
            {
                transformedData.Add(new Sequence() { name = x.name, data = HelperMethods.ConvertToAscii(x.data) });
            }
            return transformedData;
        }
        /// <summary>
        /// Converts characters to their corresponding ASCII values.
        /// </summary>
        /// <param name="characters">The string containing characters to convert.</param>
        /// <returns>An array of integers representing the ASCII values of the characters.</returns>
        public static int[] ConvertToAscii(string characters)
        {
            List<int> asciiValues = new List<int>();

            if (characters == null)
                throw new ArgumentNullException();

            foreach (char character in characters.ToLower())
            {
                if (character >= 'a' && character <= 'z')
                {
                    int asciiValue = (int)character;
                    asciiValues.Add(asciiValue);
                }
            }

            return asciiValues.ToArray();
        }
    }
}
