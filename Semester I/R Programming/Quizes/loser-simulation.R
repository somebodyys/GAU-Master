# Set the number of simulations
n_simulations <- 100000

# Game parameters
initial_budget <- 5
target <- 20
loss_count <- 0

# Simulation
for(i in 1:n_simulations) {
  budget <- initial_budget
  
  while(budget > 0 && budget < target) {
    # Simulate a coin flip (1 for heads, 0 for tails)
    flip <- sample(c(1, 0), size = 1, replace = TRUE)
    
  
    if(flip == 1) {
      budget <- budget + 1  # Win 1
    } else {
      budget <- budget - 1  # Lose 1
    }
  }
  
  # Check if the player lost all the money
  if(budget == 0) {
    loss_count <- loss_count + 1
  }
}

# Calculate the probability of losing all the money
probability_lose <- loss_count / n_simulations

# Print the probability
print(paste("The estimated probability of losing all the money is:", probability_lose))
