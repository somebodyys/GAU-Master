# a task 1
a <- matrix(c(4.3, 3.1, 8.2, 8.2, 3.2, 0.9, 1.6, 6.5), nrow = 4, byrow = TRUE)

# b task 2
b <- a[-1, ]
print(b)

# c task 3
a[, 2] <- sort(a[, 2])
c <- a

# d task 4
d <- c[-4, -1, drop = FALSE]
print(d)

# e task 5
e <- c[3:4, ]
print(e)

# f task 6
diagonal_of_new_matrix <- diag(e)
print(diagonal_of_new_matrix)

c[4, 2] <- -1/2 * diagonal_of_new_matrix[1]
c[1, 2] <- -1/2 * diagonal_of_new_matrix[1]
c[4, 1] <- -1/2 * diagonal_of_new_matrix[2]
c[1, 1] <- -1/2 * diagonal_of_new_matrix[2]
