# Lọc cộng tác (collaborative filtering)

# Naive Bayes Classifier

## Why Naive Bayes ? Why not KNN (𝑘-nearest neighbors) in recommeded systems?

1. Naive Bayes is a linear classifier while K-NN is not; It tends to be faster when applied to big data. In comparison, k-nn is usually slower for large amounts of data, because of the calculations required for each new step in the process. Because speed is important, choose Naive Bayes over K-NN.

2. In general, Naive Bayes is highly accurate when applied to big data. Don't discount K-NN when it comes to accuracy though; as the value of k in K-NN increases, the error rate decreases until it reaches that of the ideal Bayes (for k→∞).

3. Naive Bayes offers you two hyperparameters to tune for smoothing: alpha and beta. A hyperparameter is a prior parameter that are tuned on the training set to optimize it. In comparison, K-NN only has one option for tuning: the “k”, or number of neighbors.

# Tóm tắt Matrix Factorization Collaborative Filtering

[mlcoban_matrixfactorization_short](./mlcoban_matrixfactorization_short.md)

# Tóm tắt paper

nbmf.pptx

# Notebook ALS recommend system

https://colab.research.google.com/drive/1hciAtW8UeV89PN1z_9ZruPcyG5WGeUJ3?usp=sharing
