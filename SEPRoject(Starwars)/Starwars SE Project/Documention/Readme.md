# Project Title:ML 23/24-12 Enhancing Multi-Sequence Learning with accuracy #
The project "Enhanced Multi-Sequence Learning with Improved Accuracy" is developed using C# .Net Core within the Microsoft Visual Studio 2022 Integrated Development Environment (IDE). This project utilizes an open-source implementation of Hierarchical Temporal Memory (HTM) in C#/.Net Core to explore the functionality of the HTM model while it learns sequences of integers and alphabets, with the objective of enhancing the model's accuracy. 

## Project Description ##

### Objective: ###
The objective of this task is to analyze the previously impletemented sequence learing algorithm and further improve the efficiency of the current implementation. (for e.g, accuracy).

## Flow Diagram ##

[Flow Diagram](https://github.com/M-Zubairr/neocortexapi-Starwars/blob/master/SEPRoject(Starwars)/Starwars%20SE%20Project/Documention/FlowDiagram.PNG)

## Encoders ##
The encoder is a vital part of the HTM network, tasked with converting raw input data into a format that the system can comprehend and handle effectively. It achieves this by transforming the input data into binary vectors or sparse distributed representations (SDRs), which are then passed on to the spatial pooling process. Within this process, the encoder plays a key role in determining which bits should be set to one and which should be set to zero for a given input value, ensuring that important semantic details of the data are captured accurately. This is crucial because the HTM network operates on SDRs, which are binary vectors with only a small fraction of active bits. Therefore, the encoder's primary function is to convert various types of input data, such as continuous or discrete sensory data from sensors, into SDRs to facilitate effective processing by the HTM network.
## Type of Encoder ##
There are severl different typesof encoders but scalar encoders and HTM encoders are fundamental components of HTM systems, enabling the conversion of diverse types of input data into sparse distributed representations for processing and analysis by HTM algorithms.

**Scalar Encoders:**

Scalar encoders are used in HTM systems to encode scalar (single-valued) data into sparse distributed representations (SDRs), which are patterns of 1s and 0s where only a small fraction of the bits are active. Scalar encoders convert scalar values (such as numerical data) into SDRs, which are then processed by HTM algorithms.
Scalar values are mapped onto the SDR in such a way that similar values have similar SDRs, enabling the HTM system to recognize patterns and anomalies in the data.

## HTM Prediction Engine ##
The HTM prediction engine is a key component of the HTM framework. It is designed to analyze and make predictions based on time-series data. The prediction engine learns temporal patterns in data by forming connections between active neurons in a hierarchical structure.
The HTM prediction engine operates by continuously processing incoming data, learning from patterns, and making predictions about future states. 
## SDR (Sparse Distributed Representation) ##
Sparse Distributed Representation is a method of representing data where each item is encoded by the activity of a large number of units, but only a small fraction of those units are active at any given time. This representation is often used in neural networks and models of the brain because it can efficiently encode complex patterns while maintaining sparsity, which means that only a small percentage of units are active at once.
Sparse Distributed Representation (SDR) works by encoding information in high-dimensional vectors where only a small fraction of the elements are active (have a value of 1) at any given time, while the rest are inactive (have a value of 0). 

## Implementation ##
In this project, we have significantly enhanced the multi-sequence learning framework originally based on Numenta's HTM model, expanding its capabilities to handle both numeric and alphabetic datasets. The project comprises two distinct components: one dedicated to learning from numeric datasets and another tailored for alphabetic datasets.

To initiate the learning process, the foremost requirement is to generate the datasets themselves. To accomplish this, we've developed a sequence generator capable of creating random datasets for both alphabetic and numeric sequences. The generator operates based on user-defined parameters, such as the number of sequences to be generated and the range of values within each sequence, specified as maximum and minimum values. Additionally, the generator creates two supplementary datasets specifically intended for evaluation and testing purposes. These evaluation and test datasets are derived by randomly selecting subsequences from the primary dataset, serving as essential tools for assessing the accuracy and performance of the model.

While the HTM model seamlessly accommodates numeric sequences, a transformation is necessary to enable its compatibility with alphabetic sequences. To bridge this gap, we devised a method leveraging ASCII encodings. The alphabet sequences are first passed through a transformer that converts them into their respective ASCII representations. Subsequently, these ASCII representations are fed into the HTM model for the learning process, facilitating the incorporation of alphabetic data into the framework. 

### Sequence Generator
The below mentioned code was used to generate the alphabetic sequence.
```
public static string GenerateAlphabetSequence(int length)
        {
            if (length <= 0)
                throw new ArgumentException("Length must be greater than zero.", nameof(length));

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] sequence = new char[length];

            for (int i = 0; i < length; i++)
            {
                var randomChar = chars[random.Next(chars.Length)];
                if (!sequence.Contains(randomChar))
                    sequence[i] = randomChar;
                else
                    i--;
            }

            Array.Sort(sequence);
            return new string(sequence.Distinct().ToArray());
        }
```
Almost similar code is used to generate the number sequence also.  

### ASCII Conversion
Below code transforms the english alphabet character into its ACII code.
```
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
```
### Sample Dataset
The following are sample datasets generated by the sequence generator.

Alphabetic sequence:
```
{"name": "S1", "data": "ACEGHKMOTXY"}
,
{"name": "S2", "data": "ACDEGHMOPRSTUV"}
,
{"name": "S3", "data": "CFHIJLNRTVYZ"}
,
{"name": "S4", "data": "BDEFHJLMNQTVZ"}
,
{"name": "S5", "data": "DEIJMQRSUW"}
.
.
.
{"name": "S50", "data": "ACEIKMOPRUW"}
```

Number sequence:
```
{"name": "S1", "data": [1,11,18,20,23,25,27,35,36,37,40,42,46,47,49]}
,
{"name": "S2", "data": [6,7,7,7,11,19,20,30,38,43,44,46,48]}
,
{"name": "S3", "data": [0,1,18,20,23,25,26,29,30,33,42,43,46,47]}
,
{"name": "S4", "data": [3,5,7,15,16,17,20,30,33,35,41,44,47]}
,
{"name": "S5", "data": [10,16,19,27,29,33,34,35,36,37,39]}
.
.
.
{"name": "S50", "data": [10,12,13,15,17,19,30,32,34,38,40]}
```
### Encoder Config
Encoder parameters for alphabetic sequence:

```
var settings = new Dictionary<string, object>
            {
                { "W", 15 },
                { "N", inputBits },
                { "Radius", -1.0 },
                { "MinVal", 97.0 },
                { "Periodic", false },
                { "Name", "scalar" },
                { "ClipInput", false },
                { "MaxVal", 122.0 }
            }
```
Encoder parameters for number sequence:
```
var settings = new Dictionary<string, object>
            {
                { "W", 15 },
                { "N", inputBits },
                { "Radius", -1.0 },
                { "MinVal", 0.0 },
                { "Periodic", false },
                { "Name", "scalar" },
                { "ClipInput", false },
                { "MaxVal", 50.0 }
            }
```
The two encoder configurations mentioned above differ solely in their maximum and minimum values. For numeric sequences, where values range between 0 and 50, we utilize a minimum value of 0 and a maximum value of 50. Conversely, alphabetic sequences encompass all English letters from 'a' to 'z', thereby necessitating a minimum value of 97 (ASCII representation of 'a') and a maximum value of 122 (ASCII representation of 'z').
## Learning Phase
**Initialization**: The experiment sets up the necessary components for the HTM model to learn. These include structures for managing connections between neurons (Connections), a classifier (HtmClassifier) for organizing learned patterns, and layers (CortexLayer) for processing input data.

HTM Configuration Parameters
```
    int inputBits = 200;
	int numColumns = 1024;
	
    return new HtmConfig(new int[] { inputBits }, new int[] { numColumns })
    {
        Random = new ThreadSafeRandom(42),
        CellsPerColumn = 25,
        GlobalInhibition = true,
        LocalAreaDensity = -1,
        NumActiveColumnsPerInhArea = 0.02 * numColumns,
        PotentialRadius = (int)(0.15 * inputBits),
        MaxBoost = 10.0,
        DutyCyclePeriod = 25,
        MinPctOverlapDutyCycles = 0.75,
        MaxSynapsesPerSegment = (int)(0.02 * numColumns),
        ActivationThreshold = 15,
        ConnectedPermanence = 0.5,
        PermanenceDecrement = 0.25,
        PermanenceIncrement = 0.15,
        PredictedSegmentDecrement = 0.1
    }
```

**Training the Spatial Pooler (SP)**: Initially, the spatial pooler is trained using input sequences. This phase aims to stabilize the spatial pooling process, ensuring it reliably represents input patterns.

**Combined Training with SP and Temporal Memory (TM)**: Once the spatial pooler is stable, the code enters a phase where both the spatial pooler and the temporal memory are trained together. This allows the system to learn sequences of patterns over time, incorporating both spatial and temporal information.

**Learning Process**: During training, the system computes outputs based on input sequences and learns from the predicted and actual inputs. It compares predicted values with actual values, counting matches to evaluate accuracy. The learning process continues until certain conditions are met, such as achieving a desired level of accuracy or completing a set number of cycles.

## Result: ##
The training accuracy for datasets consisting of random sequences of both alphabet and numbers, arranged in ascending order, with approximately 40 sequences per dataset and each sequence comprising approximately 10 to 20 elements, is observed to be approximately 90%. Furthermore, the test results are documented in the [file](https://github.com/M-Zubairr/neocortexapi-Starwars/blob/master/SEPRoject(Starwars)/Starwars%20SE%20Project/EnhanceMultisequenceLearning/Report/report_638483548536644649.txt).
For better understanding of the prediction process, see the [Flow diagram](https://drive.google.com/file/d/1gv0FduFUcPzfjmL3lDf3ajrrnPdLkT62/view?usp=sharing).
 