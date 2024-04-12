data <- read.csv("fl_student_survey.csv", header=TRUE, sep=",", dec=".")

# Task 1
not_vegetarian <- subset(data, vegetarian != 'y')
sample_proportion <- nrow(not_vegetarian) / nrow(data)

population_sd <- sqrt(sample_proportion * (1 - sample_proportion))
sample_size <- nrow(data)
standard_error <- population_sd / sqrt(sample_size)

confidence_level <- 0.95
z_score <- qnorm(1 - (1 - confidence_level) / 2)

margin_of_error <- z_score * standard_error
lower_bound <- sample_proportion - margin_of_error
upper_bound <- sample_proportion + margin_of_error

upper_bound - lower_bound

# Task 2
religiosity_1 <- subset(data, religiosity == 1)
sample_proportion <- nrow(religiosity_1) / nrow(data)

population_sd <- sqrt(sample_proportion * (1 - sample_proportion))
sample_size <- nrow(data)
standard_error <- population_sd / sqrt(sample_size)

confidence_level <- 0.70
z_score <- qnorm(1 - (1 - confidence_level) / 2)

margin_of_error <- z_score * standard_error
lower_bound <- sample_proportion - margin_of_error
lower_bound

# Task 3
male_r_students <- subset(data, gender == 'm' & political_affiliation == 'r')
sample_mean <- mean(male_r_students$college_GPA)
sample_sd <- sd(male_r_students$college_GPA)
sample_size <- nrow(male_r_students)
standard_error <- sample_sd / sqrt(sample_size)
confidence_level <- 0.99
z_score <- qnorm(1 - (1 - confidence_level) / 2)
margin_of_error <- z_score * standard_error
lower_bound <- sample_mean - margin_of_error
upper_bound <- sample_mean + margin_of_error

cat("[", lower_bound, ",", upper_bound, "]\n")

# Task 4
non_ideology_1_students <- subset(data, political_ideology != 1)
sample_mean <- mean(non_ideology_1_students$AIDS)
sample_sd <- sd(non_ideology_1_students$AIDS)
sample_size <- nrow(non_ideology_1_students)
standard_error <- sample_sd / sqrt(sample_size)
confidence_level <- 0.99
z_score <- qnorm(1 - (1 - confidence_level) / 2)

margin_of_error <- z_score * standard_error
lower_bound <- sample_mean - margin_of_error
upper_bound <- sample_mean + margin_of_error

cat("[", lower_bound, ",", upper_bound, "]\n")

# Task 5
male_r_students <- subset(data, gender == 'm' & political_affiliation == 'r')
sample_sd <- sd(male_r_students$college_GPA)
margin_of_error <- 0.01

score <- margin_of_error * sqrt(nrow(male_r_students)) / (sample_sd)
confidance <- pt(score, df = nrow(male_r_students) - 1) - pt(-score, df = nrow(male_r_students) - 1)
confidance * 100
 
  
# Task 6
religiosity_1 <- subset(data, religiosity == 1)
sample_proportion <- nrow(religiosity_1) / nrow(data)
margin_or_error <- 0.03

z_score = margin_or_error / sqrt((sample_proportion * (1 - sample_proportion)) / nrow(religiosity_1))
confidance <- pnorm(z_score) - pnorm(-z_score)
confidance * 100

# Task 7
gender = data$gender
political_affiliation = data$political_affiliation

b =table(gender,political_affiliation)

barplot(
  prop.table(b,2),
  col=c(6,7),
  legend.text=c('Male','Female'),
  args.legend=list(x="topright",cex=0.6),
  xlab = "Political Affiliation", ylab = "Gender"
)

# Task 8
ages <- subset(data, data$high_sch_GPA > 3.5)$age
hist(ages,
     breaks = seq(from = 20, to = 80, by = 10),
     col = 'blue',
     main = 'Histogram of Age',
     labels = TRUE
)




