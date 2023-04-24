Genetic algorithm is for create a good affected control law

Evolution algorithms based on natural selection, init with an generation of all control laws and let them compete choose the best fit or how good they optimize your objective function.

And genetic operation to get the affected generation can breed more affected control law in the next generation (replication (same), crossover (swap the different), mutation (change a portion))

---

Genetic algorithm optimize by tuning the known structure, useful for parameters identifycation when you have a fixed structure

But many other control problems, dont know what structure of the control law I want to use, so it not as simple as parameter optimization

Genetic programming is simultaneously learn the structure and pramaters of an affective control laws

Leaf nodes = constants (cx) or sensors (yx) and function operations.
