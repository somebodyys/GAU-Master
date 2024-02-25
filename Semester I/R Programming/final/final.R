# Load Data
data <- read.csv("fl_student_survey.csv", header=TRUE, sep=",", dec=".")

# TV სვეტი დაყავით კატეგორიების მიხედვით. იმ მონაცემებს, რომლებიც
# ჩავარდებიან [0,4) ინტერვალში, მიანიჭეთ A კატეგორია. მონაცემებს,
# რომლებიც ჩავარდებიან [4,7) ინტერვალში მიანიჭეთ B კატეგორია.
# მონაცემებს, რომლებიც ჩავარდებიან [7-10) ინტერვალში მიანიჭეთ C
# კატეგორია, მონაცემებს, რომლებიც ჩავარდებიან [10-38) ინტერვალში
# მიანიჭეთ D კატეგორია.
tvIntervals <- c(0, 4, 7, 10, 38)
tvLabels <- c('A', 'B', 'C', 'D')
tvCategories <- cut(data$TV, breaks = tvIntervals, labels = tvLabels, right = FALSE)

# Sports სვეტი დაყავით კატეგორიების მიხედვით. იმ მონაცემებს, რომლებიც
# ჩავარდებიან [0,7) ინტერვალში, მიანიჭეთ k კატეგორია. მონაცემებს,
# რომლებიც ჩავარდებიან [7,9) ინტერვალში მიანიჭეთ m კატეგორია.
# მონაცემებს, რომლებიც ჩავარდებიან [9,17) ინტერვალში მიანიჭეთ n
# კატეგორია.
sportsIntervals <- c(0, 7, 9, 17)
sportsLabels <- c('k', 'm', 'n')
sportsCategories <- cut(data$sports, breaks = sportsIntervals, labels = sportsLabels, right = FALSE)

# Task 1
# გამოიტანეთ მონაცემები (მონაცემების ჩარჩო), რომლებიც ეკუთვნიან A
# კატეგორიას და n კატეგორიას. ამ მონაცემების ჩარჩოდან
# distance_residence -ის მინიმუმი ტოლია
answerOne <- min(subset(data, tvCategories == 'A' & sportsCategories == 'n')$distance_residence)

# Task 2
# k კატეგორიის მამაკაც სტუდენტებში რამდენი პროცენტია რესპუბლიკელი
totalKCategoryMaleStudents <- length(subset(data, sportsCategories == 'k' & data$gender == 'm')$gender) 
totalKCategoryRepublicanMales <- length(subset(data, sportsCategories == 'k' & data$gender == 'm' & data$political_affiliation == 'r')$gender)
answerTwo <- totalKCategoryRepublicanMales / totalKCategoryMaleStudents * 100

# Task 3
# იმ სტუდენტებში, რომელთა religiosity=0 და ეკუთვნიან m კატეგორიას, რამდენ
# პროცენტს ჯერავს სიცოცხლის გარდაცვალების შემდეგ (life_after_death =y)
nonReligiousMCategoryStudents <- length(subset(data, data$religiosity == 0 & sportsCategories == 'm')$life_after_death)
nonReligiousMCategoryLifeAfterDeath <- length(subset(data, data$religiosity == 0 & sportsCategories == 'm' & data$life_after_death == 'y')$life_after_death)
answerThree <- nonReligiousMCategoryLifeAfterDeath / nonReligiousMCategoryStudents * 
  
# Task 4
# იმ ქალ სტუდენტებში, რომლებიც ეკუთვნიან m კატეგორიას, რამდენ
# პროცენტს ჯერავს სიცოცხლის გარდაცვალების შემდეგ (life_after_death =y)
mCategoryWomen <- length(subset(data, data$gender == 'f' & sportsCategories == 'm')$gender)
mCategoryWomenLifeAfterDeath <- length(subset(data, data$gender == 'f' & sportsCategories == 'm' & data$life_after_death == 'y')$gender)
answerFour <- mCategoryWomenLifeAfterDeath / mCategoryWomen * 100

# Task 5
# რესპუბლიკელ ქალ სტუდენტებში(political_affiliation), რამდენი პროცენტი
# უჭერს აბორტის ლეგალიზებას ორსულობის პირველ სამ თვეში (abortion_legalize)
republicanWomen <- length(subset(data, data$gender == 'f' & data$political_affiliation == 'r')$gender)
republicanWomenAbortLegalize <- length(subset(data, data$gender == 'f' & data$political_affiliation == 'r' & data$abortion_legalize == 'y')$gender)
answerFive <- republicanWomenAbortLegalize / republicanWomen * 100

# Task 6
# გამოიტანეთ მონაცემები (მონაცემების ჩარჩო), რომლებიც ეკუთვნის A
# კატეგორიას და არარესპუბლიკელი მამაკაცი სტუდენტებია ან n კატეგორიის ქალებია. 
# ამ მონაცემებიდან რამდენი უჭერს აბორტის ლეგალიზებას ორსულობის პირველ სამ თვეში
taskSixSubSet <- subset(data, (tvCategories == 'A' & data$gender == 'm' & data$political_affiliation != 'r') | (sportsCategories == 'n' & data$gender == 'f'))
answerSix <- length(subset(taskSixSubSet, taskSixSubSet$abortion_legalize == 'y')$gender)

# A ყუთი შეიცავს 6 წითელ და 2 მწვანე ბურთს
# B ყუთი შეიცავს 4 წითელ და 3 მწვანე ბურთს
# აგორებენ წესიერ კამათელს.
# თუ მოვიდა ლუწი ქულა მაშინ A ყუთიდან შემთხვევით ვიღებთ 1 ბურთს, 
# ხოლო წინააღმდეგ შემთხვევაში B ყუთიდან შემთხვევით ვიღებთ 1 ბურთს. 
# იპოვეთ ალბათობა იმისა რომ:

# ა) ამოღებული ბურთი წითელია
# ბ) ბურთი ამოღებული იყო B ყუთიდან, თუ ცნობილია, რომ ამოღებული ბურთი წითელია.
initial_count_A <- c(red = 6, green = 2)
initial_count_B <- c(red = 4, green = 3)

num_simulations <- 10000

red_count <- 0
total_draws <- 0
draws_from_B <- 0

for (i in 1:num_simulations) {
  die_result <- sample(1:6, 1)
  
  if (die_result %% 2 == 0) {
    box <- "A"
    ball_color <- sample(c("red", "green"), 1, prob = initial_count_A / sum(initial_count_A))
  } else {
    box <- "B"
    ball_color <- sample(c("red", "green"), 1, prob = initial_count_B / sum(initial_count_B))
  }
  
  total_draws <- total_draws + 1

  if (ball_color == "red") {
    red_count <- red_count + 1
    if (box == "B") {
      draws_from_B <- draws_from_B + 1
    }
  }
}

probability_red <- red_count / total_draws
probability_from_B_given_red <- draws_from_B / red_count

cat("წითელი ბურთის ამოღების ალბათობა: ", probability_red, "\n")
cat("ალბათობა რომ ბურთი ამოღებული იყო B ყუთიდან: ", probability_from_B_given_red, "\n")





