# Set the number of simulations
n_simulations <- 100000

# Define the boxes
# 9 boxes with 2 red and 2 green calculators
# 1 box with 5 red and 1 green calculator
boxes <- replicate(9, c("Red", "Red", "Green", "Green"), simplify = FALSE)
boxes <- c(boxes, list(c("Red", "Red", "Red", "Red", "Red", "Green")))

# Initialize counters
chosen_5_red_box <- 0
picked_red_calculator <- 0

# Simulation
for(i in 1:n_simulations) {
  # Randomly select a box
  selected_box <- sample(boxes, size = 1, replace = TRUE)[[1]]
  
  # Randomly select a calculator from the chosen box
  selected_calculator <- sample(selected_box, size = 1)
  
  # Check if the calculator is red
  if(selected_calculator == "Red") {
    picked_red_calculator <- picked_red_calculator + 1
    
    # Check if the selected box is the one with 5 red calculators
    if(length(selected_box) == 6 && sum(selected_box == "Red") == 5) {
      chosen_5_red_box <- chosen_5_red_box + 1
    }
  }
}

# Calculate the probability
probability <- chosen_5_red_box / picked_red_calculator

# Print the probability
print(paste("The estimated probability is:", probability))

