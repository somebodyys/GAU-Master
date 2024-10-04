data <- read.csv("fl_student_survey.csv", header=TRUE, sep=",", dec=".")

# Task 1
male_ages <- data$age[data$gender == 'm']
female_ages <- data$age[data$gender == 'f']

m1 <- mean(male_ages, na.rm = TRUE)
m2 <- mean(female_ages, na.rm = TRUE)

t_test_result <- t.test(male_ages, female_ages, var.equal = TRUE, conf.level = 0.90)

conf_int <- t_test_result$conf.int

upper_bound <- conf_int[2]
upper_bound


# Task 2
male_ages <- data$age[data$gender == 'm']
female_ages <- data$age[data$gender == 'f']

t_test_result <- t.test(male_ages, female_ages, var.equal = FALSE, alternative = "greater")

p_value <- t_test_result$p.value
p_value

# Task 3
male_high_sch_GPA <- data$high_sch_GPA[data$gender == 'm']
female_high_sch_GPA <- data$high_sch_GPA[data$gender == 'f']

t_test_result <- t.test(male_high_sch_GPA, female_high_sch_GPA, var.equal = FALSE, alternative = "less")

p_value <- t_test_result$p.value
p_value

# Task 4
male_abortion_supporters <- sum(data$abortion_legalize[data$gender == 'm'] == 'y')
female_abortion_supporters <- sum(data$abortion_legalize[data$gender == 'f'] == 'y')

total_males <- sum(data$gender == 'm')
total_females <- sum(data$gender == 'f')

px <- male_abortion_supporters / total_males
py <- female_abortion_supporters / total_females

p_hat <- (male_abortion_supporters + female_abortion_supporters) / (total_males + total_females)

se <- sqrt(p_hat * (1 - p_hat) * ((1 / total_males) + (1 / total_females)))
z <- (px - py) / se

p_value <- pnorm(z, lower.tail = TRUE)
p_value


# Task 5
male_vegetarians <- sum(data$vegetarian[data$gender == 'm'] == 'y')
female_vegetarians <- sum(data$vegetarian[data$gender == 'f'] == 'y')

total_males <- sum(data$gender == 'm')
total_females <- sum(data$gender == 'f')

px <- male_vegetarians / total_males
py <- female_vegetarians / total_females

p <- (male_vegetarians + female_vegetarians) / (total_males + total_females)

se <- sqrt(p * (1 - p) * (1 / total_males + 1 / total_females))

z <- (px - py) / se

p_value <- 2 * (1 - pnorm(abs(z)))
p_value