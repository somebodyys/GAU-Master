# This is from a pseudo-code for the algorithm
my_algorithm <- function(n){
  # Check if n is a positive integer
  if (n <= 0 | !is.integer(n)) {
    stop("n must be a positive integer")
  }
  
  a <- rep(0, n) # Create a vector of length n with all zeros
  
  for (i in 1:n){
    for (j in 1:n){
      if (j %% i == 0) {
        a[j] <- 1 - a[j]
      }
    }
  }
  
  return(a)
}

# (a) Trace the algorithm for n = 10
my_algorithm(as.integer(10))

# (b) Given any value of n, 
# can you predict the final value of each of the ais without tracing through the algorithm? Justify your answer
# Answer: Yes, the final value of each of the ais is 1 if i is a perfect square, and 0 otherwise.
# Justification: If i is a perfect square, then the number of divisors of i is odd, and thus the final value of ai is 1.
# If i is not a perfect square, then the number of divisors of i is even, and thus the final value of ai is 0.

