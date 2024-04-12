acid_rain_data <- read_xls("Data/acid_rain.xls")
bird_species_data <- read_xls("Data/birds_species.xls")
emails_data <- read_xls("Data/emails.xls")
horsepower_data <- read_xls("Data/horsepower.xls")
hurricanes_data <- read_xls("Data/hurricanes.xls")
marijuana_data <- read_xls("Data/marijuana.xls")
math_scores_data <- read_xls("Data/math_scores.xls")



hist(acid_rain_data$`pH Level`, col = "red")
hist(bird_species_data$`228`, breaks = 15)
hist(emails_data$`Number of e-mails`, prob = TRUE)
hist(horsepower_data$Horsepower)
hist(hurricanes_data$Hurricanes)
hist(
  marijuana_data$Percent, breaks = seq(0, 60, by = 5),
  col = rainbow(length(marijuana_data$Country)),
  main = "Distribution of Percentage by Country",
  xlab = "Percentage",
  ylab = "Frequency",
  xlim = c(0, 60),
  ylim = c(0, 7),
  axes = FALSE
)
hist(math_scores_data$`Math Scores`)