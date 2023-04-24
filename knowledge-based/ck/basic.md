generic programming

6.1 intro

challenges of computer science is to get a computer to do what needs to be done, without telling it how to do it

Genetic Programming achieves this goal of automatic programming, creating a working computer program from a high-level problem statement of the problem.

Genetic Programming achieves this goal of automatic programming by genetically breeding a population of computer programs using the principles of Darwinian natural selection and bio- logically inspired operations

The operations include reproduction, crossover (sex- ual recombination), mutation, and architecture-altering operations patterned after gene duplication and gene deletion in nature.

6.2 Comparison

differences exist between GAs and GP:

Structure: GP - tree structures while GA’s evolve binary or real number strings.

Active Vs Passive: Because GP usually evolves computer programs, the solutions can be executed without post processing i.e. active structures, while GA’s typically operate on coded binary strings i.e. passive structures, which require post-processing.

Variable Vs fixed length: In traditional GAs, the length of the binary string is fixed before the solution procedure begins. However a GP parse tree can vary in length throughout the run. Although it is recognized that in more advanced GA work, variable length strings are used.

|                          | GAs                                                                             | GP                                                                           |
| ------------------------ | ------------------------------------------------------------------------------- | ---------------------------------------------------------------------------- |
| Structure                | tree structures                                                                 | binary or real number strings                                                |
| Active Vs Passive        | operate on coded binary strings require post-processing i.e. passive structures | the solutions can be executed without post processing i.e. active structures |
| Variable Vs fixed length | the length of the binary string is fixed before the solution procedure begins   | parse tree can vary in length throughout the run                             |
