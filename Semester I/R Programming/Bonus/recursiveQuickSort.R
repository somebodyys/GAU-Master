# Recursive Quick-Sort function
quickSort <- function(array) {
  if (length(array) <= 1) {
    return(array)
  }
  
  pivot <- array[1]
  array <- array[-1]
  left <- array[array < pivot]
  right <- array[array >= pivot]
  
  return(
    c( quickSort(left), pivot, quickSort(right) )
  )
}

# Example
array <- c(5, 3, 1, 2, 4)
quickSort(array)