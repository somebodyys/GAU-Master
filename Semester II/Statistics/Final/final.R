# Task 1
sample_size <- 750
number_likes <- 500
lower_limit <- 0.6
upper_limit <- 0.73

p_hat <- number_likes / sample_size
ME <- (upper_limit - lower_limit) / 2
SE <- sqrt(p_hat * (1 - p_hat) / sample_size)
z_value <- ME / SE
confidence_level <- 2 * (pnorm(z_value) - 0.5)
confidence_percentage <- confidence_level * 100

# Task 2
data <- read.csv("fl_student_survey.csv", header=TRUE, sep=",", dec=".")
ages_male <- data$age[data$gender == "m"]
ages_female <- data$age[data$gender == "f"]

t_test_result <- t.test(ages_male, ages_female, var.equal = TRUE)
p_value <- t_test_result$p.value

# Task 3
high_sch_GPA_male <- data$high_sch_GPA[data$gender == "m"]
high_sch_GPA_female <- data$high_sch_GPA[data$gender == "f"]
t_test_result <- t.test(high_sch_GPA_male, high_sch_GPA_female, var.equal = TRUE, alternative = "less")
p_value <- t_test_result$p.value

# Task 4
high_sch_GPA_male <- data$high_sch_GPA[data$gender == "m"]
high_sch_GPA_female <- data$high_sch_GPA[data$gender == "f"]

t_test_result <- t.test(high_sch_GPA_male, high_sch_GPA_female, var.equal = TRUE, conf.level = 0.99)
conf_interval <- t_test_result$conf.int

# Task 5
px <- mean(data$abortion_legalize[data$gender == "m"] == "y")
py <- mean(data$abortion_legalize[data$gender == "f"] == "y")
prop_test_result <- prop.test(
  x = c(sum(data$abortion_legalize[data$gender == "m"] == "y"), 
  sum(data$abortion_legalize[data$gender == "f"] == "y")),
  n = c(length(data$abortion_legalize[data$gender == "m"]), 
  length(data$abortion_legalize[data$gender == "f"])),
  alternative = "less")

p_value <- prop_test_result$p.value

# Task 6
px <- mean(data$abortion_legalize[data$gender == "m"] == "y")
py <- mean(data$abortion_legalize[data$gender == "f"] == "y")

n1 <- sum(data$gender == "m")
n2 <- sum(data$gender == "f")

pooled_prop <- (sum(data$abortion_legalize == "y")) / (n1 + n2)
se <- sqrt(pooled_prop * (1 - pooled_prop) * (1/n1 + 1/n2))

t_critical <- qt(0.975, df = n1 + n2 - 2)

margin_of_error <- t_critical * se
conf_interval <- c((px - py) - margin_of_error, (px - py) + margin_of_error)

# Task 7
p1_hat <- 0.28 
n1 <- 500
p2_hat <- 0.25
n2 <- 600   

lower_bound <- 0.01
upper_bound <- 0.05

p_diff_hat <- p1_hat - p2_hat
se <- sqrt((p1_hat * (1 - p1_hat)) / n1 + (p2_hat * (1 - p2_hat)) / n2)

z_upper <- qnorm(1 - (upper_bound / 2))
z_lower <- qnorm(lower_bound / 2)
confidence_level <- 1 - (2 * pnorm(-abs(p_diff_hat / se)))
confidence_level_percent <- confidence_level * 100

# Task 8 
n1 <- 4
n2 <- 9       
x1_bar <- 25
x2_bar <- 26
s1 <- 2       
s2 <- 5        
lower_bound <- 0.97
upper_bound <- 1.03

s_pool <- sqrt(((n1 - 1) * s1^2 + (n2 - 1) * s2^2) / (n1 + n2 - 2))
se <- s_pool * sqrt(1/n1 + 1/n2)
t_upper <- qt(upper_bound, df = n1 + n2 - 2)
t_lower <- qt(lower_bound, df = n1 + n2 - 2)

confidence_level <- (1 - (2 * pt(-abs((x1_bar - x2_bar) / se), df = n1 + n2 - 2))) * 100