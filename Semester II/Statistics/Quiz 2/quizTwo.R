# დავალება 1 და 2
population_sd <- 2
sample_size <- 100
sample_mean <- 70
confidence_level <- 0.90

z_score <- qnorm(1 - (1 - confidence_level) / 2)
sem <- population_sd / sqrt(sample_size)
margin_of_error <- z_score * sem
top_margin <- sample_mean + margin_of_error

cat("შერჩევის ცდომილება = ", margin_of_error, "\n")
cat("ზედა ზღვარი = ", top_margin, "\n")

# დავალება 3
population_sd <- 10
margin_of_error <- 0.05
confidence_level <- 0.99

z_score <- qnorm(1 - (1 - confidence_level) / 2)
sample_size <- ceiling((z_score * population_sd / margin_of_error)^2)

cat("შერჩევის მოცულობა = ", sample_size, "\n")

# დავალება 4
sample_mean <- 25
population_sd <- 1
sample_size <- 100
confidence_level <- 0.80

z_score <- qnorm(1 - (1 - confidence_level) / 2)
margin_of_error <- z_score * (population_sd / sqrt(sample_size))

lower_bound <- sample_mean - margin_of_error
upper_bound <- sample_mean + margin_of_error

cat("80% ნდობის ინტერვალი:", "(" , lower_bound, ",", upper_bound, ")\n")

# დავალება 5
sample_mean <- 25
population_sd <- 4
lower_bound <- 24.43
upper_bound <- 25.57
sample_size <- 64

z_lower <- (lower_bound - sample_mean) / (population_sd / sqrt(sample_size))
z_upper <- (upper_bound - sample_mean) / (population_sd / sqrt(sample_size))

percent_interval <- pnorm(z_upper) - pnorm(z_lower)
percent_confidence <- percent_interval * 100

cat("პასუხი = ", round(percent_confidence, 2), "%\n")

# დავალება 6
sample_mean <- 10
sample_sd <- 0.2
sample_size <- 12
confidence_level <- 0.90

z_score <- qnorm(1 - (1 - confidence_level) / 2)
margin_of_error <- z_score * (sample_sd / sqrt(sample_size))

cat("შერჩევის ცდომილება = ", margin_of_error, "\n")

# დავალება 7
data <- c(2, 1, 2, 2, 7)

sample_mean <- mean(data)
sample_sd <- sd(data)
sample_size <- length(data)
confidence_level <- 0.99

z_score <- qnorm(1 - (1 - confidence_level) / 2)
margin_of_error <- z_score * (sample_sd / sqrt(sample_size))

cat("შერჩევის ცდომილება = ", margin_of_error, "\n")


# დავალება 8
total_surveyed <- 225
likes_new_system <- 90
confidence_level <- 0.90

sample_proportion <- likes_new_system / total_surveyed
z_score <- qnorm(1 - (1 - confidence_level) / 2)
standard_error <- sqrt((sample_proportion * (1 - sample_proportion)) / total_surveyed)
margin_of_error <- z_score * standard_error

lower_bound <- sample_proportion - margin_of_error
upper_bound <- sample_proportion + margin_of_error

cat("90% ნდობის ინტერვალი ", "(" , lower_bound, ",", upper_bound, ")\n")


# დავალება 9
p <- 0.92
n <- 550
alpha <- 0.01

z_score <- qnorm(1 - alpha / 2)
margin_of_error <- z_score * sqrt((p * (1 - p)) / n)

cat("შერჩევის ცდომილება = ", margin_of_error, "\n")

# დავალება 10
x_bar <- 10
sigma <- 0.2
alpha <- 0.1
margin_of_error <- 0.03

z_score <- qnorm(1 - alpha / 2)
sample_size <- ceiling((z_score * sigma / margin_of_error)^2)

cat("შერჩევის მოცულობა = ", sample_size, "\n")