# Function to calculate the digital root of a positive integer, Better Solution
calculate_digital_root <- function(n) {
  # Check if n is a positive integer
  if (n <= 0 | !is.integer(n)) {
    stop("n must be a positive integer")
  }
  # Calculate the digital root
  while (n > 9) {
    n <- sum(
      as.integer(
        unlist(
          strsplit(as.character(n), "")
        )
      )
    )
  }
  
  return(n)
}

# From Pseudo Code
calculate_digital_root <- function(n) {
  # Check if n is a positive integer
  if (n <= 0 | !is.integer(n)) {
    stop("n must be a positive integer")
  }
  
  d <- number_of_digits(n)
  
  while (d > 1) {
    n <- sum_of_digits(n)
    d <- number_of_digits(n)
  }
  
  return(n)
}

# Calculate the number of digits
number_of_digits <- function(n) {
  # Check if n is a positive integer
  if (n <= 0 | !is.integer(n)) {
    stop("n must be a positive integer")
  }
  
  # Calculate the number of digits
  return(nchar(as.character(n)))
}

# Calculate the sum of digits
sum_of_digits <- function(n) {
  # Check if n is a positive integer
  if (n <= 0 | !is.integer(n)) {
    stop("n must be a positive integer")
  }
  
  # Calculate the sum of digits
  return(sum(
    as.integer(
      unlist(
        strsplit(as.character(n), "")
      )
    )
  ))
}

# (a) Trace the algorithm for n = 8678
calculate_digital_root(as.integer(8678)) # result = 2

# (b) All Possible Values that the output of the algorithm can take
# 1, 2, 3, 4, 5, 6, 7, 8, 9