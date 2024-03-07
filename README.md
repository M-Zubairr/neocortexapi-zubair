**Project Description**

*Objective:*
The objective of this task is to analyze the previously impletemented sequence learing algoithm ans further improve the efficiency of the current implementation (for e.g, accuracy).
The previous implementation was about learning the sequence of numbers, alphabets and images.In acse of numbers and alphabets, we provided a set of alphabets/numbers and it predicts the upcoming number or alphabet in the sequence whereas for image input, it tries to predict the object pedict in the image.

# Flow Diagram #

![alt text](<Flow diagram-1.png>)


### Sequence Generator
We have created a sequence generator that will help us to compose training and testing data set for the model. This sequence generator produce random sequences of uppercase letters and saves them into a text file. It utilizes a Random object to generate random numbers for selecting characters. The GenerateSequence method constructs a random sequence of uppercase letters of a specified length, while the GenerateMultiSequenceDataset method generates multiple sequences of random lengths within a given range. These methods use a StringBuilder to efficiently construct sequences and store them in an array. The SaveDatasetToFile method writes the generated dataset into a text file, labeling each sequence with an index.

# References

HTM School:
https://www.youtube.com/playlist?list=PL3yXMgtrZmDqhsFQzwUC9V8MeeVOQ7eZ9&app=desktop

HTM Overview:
https://en.wikipedia.org/wiki/Hierarchical_temporal_memory

A Machine Learning Guide to HTM:
https://numenta.com/blog/2019/10/24/machine-learning-guide-to-htm

Numenta on Github:
https://github.com/numenta

HTM Community:
https://numenta.org/

A deep dive in HTM Temporal Memory algorithm:
https://numenta.com/assets/pdf/temporal-memory-algorithm/Temporal-Memory-Algorithm-Details.pdf

Continious Online Sequence Learning with HTM:
https://www.mitpressjournals.org/doi/full/10.1162/NECO_a_00893#.WMBBGBLytE6

# Papers and conference proceedings

#### International Journal of Artificial Intelligence and Applications
Scaling the HTM Spatial Pooler

Dobric, Pech, Ghita, Wennekers 2020. 2020 International Journal of Artificial Intelligence and Applications. Scaling the HTM Spatial Pooler. doi:10.5121/ijaia .2020.11407

#### AIS 2020 - 6th International Conference on Artificial Intelligence and Soft Computing (AIS 2020), Helsinki
The Parallel HTM Spatial Pooler with Actor Model

Dobric, Pech, Ghita, Wennekers 2020. 2020 AIS 2020 - 6th International Conference on Artificial Intelligence and Soft Computing, Helsinki. The Parallel HTM Spatial Pooler with Actor Model. https://aircconline.com/csit/csit1006.pdf, doi:10.5121/csit.2020.100606

#### Symposium on Pattern Recognition and Applications - Rome, Italy
On the Relationship Between Input Sparsity and Noise Robustness in Hierarchical Temporal Memory Spatial Pooler 

Dobric, Pech, Ghita, Wennekers 2020. 2020 Symposium on Pattern Recognition and Applications. On the Relationship Between Input Sparsity and Noise Robustness in Hierarchical Temporal Memory Spatial Pooler. https://dl.acm.org/doi/10.1145/3393822.3432317. doi:10.1145/3393822.3432317

#### International Conference on Pattern Recognition Applications and Methods - ICPRAM 2021
Improved HTM Spatial Pooler with Homeostatic Plasticity Control (Awarded with: *Best Industrial Paper*)

Dobric, Pech, Ghita, Wennekers 2021. ICPRAM Vienna Improved HTM Spatial Pooler with Homeostatic Plasticity control. doi:10.5220/0010314200980106

#### Springer Nature - Computer Sciences
On the Importance of the Newborn Stage When Learning Patterns with the Spatial Pooler

Dobric, Pech, Ghita, Wennekers 2022. Springer Nature Computer Science Journal
On the Importance of the Newborn Stage When Learning Patterns with the Spatial Pooler. https://rdcu.be/cIcoc. doi:10.1007/s42979-022-01066-4

# Contribute
If your want to contribute on this project please contact us by opening an issue. 


