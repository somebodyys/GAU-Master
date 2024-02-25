
ball_probability_counter <- function(black, white){
  set <- c(rep(0, black), rep(1, white))
  
  same_color <- 0
  different_color <- 0
  iterations <- 10000
  
  for (i in 1:iterations) {
    # 1. Sample 5 balls from the set
    single_result <- sample(set, 2, replace = FALSE)
    if(single_result[1] == single_result[2]) {
      same_color <- same_color + 1
    } else {
      different_color <- different_color + 1
    }
  }
  
  print(same_color / iterations)
  print(different_color / iterations)
}

ball_probability_counter(20, 5)
ball_probability_counter(10, 10)


