# Load Data
data <- read.csv("fl_student_survey.csv", header=TRUE, sep=",", dec=".")

# Question 1 : 
# age სვეტი დაყავით კატეგორიების მიხედვით. იმ მონაცემებს, რომლებიც
# ჩავარდებიან [20,25) ინტერვალში, მიანიჭეთ A კატეგორია. მონაცემებს,
# რომლებიც ჩავარდებიან [25,30) ინტერვალში მიანიჭეთ B კატეგორია.
# მონაცემებს, რომლებიც ჩავარდებიან [30-39) ინტერვალში მიანიჭეთ C
# კატეგორია, მონაცემებს, რომლებიც ჩავარდებიან [39-72) ინტერვალში
# მიანიჭეთ D კატეგორია. B კატეგორიის სტუდენტების distance_residence-ს
# საშუალოს გამოაკელით A კატეგორიის სტუდენტების distance_residence-ს საშუალო.
# Create intervals and corresponding labels
intervals <- c(20, 25, 30, 39, 72)
labels <- c('A', 'B', 'C', 'D')

categories <- cut(data$age, breaks = intervals, labels = labels, right = FALSE)
categoryBAvarage <- mean(subset(data, categories == 'B')$distance_residence)
categoryAAvarage <- mean(subset(data, categories == 'A')$distance_residence)
answerOne <- categoryBAvarage - categoryAAvarage # 0.55

# Question 2 : B კატეგორიის მამაკაცი სტუდენტების college_GPA-ს საშუალოს გამოაკელით A კატეგორიის ქალი სტუდენტების college_GPA-ს საშუალო.
maleBcategoryGpaAvarage <- mean(subset(data, categories == 'B' & data$gender == 'm')$college_GPA)
femaleBcategoryGpaAvarage <- mean(subset(data, categories == 'A' & data$gender == 'f')$college_GPA)
answerTwo <- maleBcategoryGpaAvarage - femaleBcategoryGpaAvarage # -0.145

# Question 3 : A კატეგორიის მამაკაც სტუდენტებში რამდენი პროცენტია რესპუბლიკელი
totalAcategoryMaleStudents <- length(subset(data, categories == 'A' & data$gender == 'm')$gender)
totalAcategoryMaleRespublicanStudents <- length(subset(data, categories == 'A' & data$gender == 'm' & data$political_affiliation == 'r')$gender)
answerThree <- totalAcategoryMaleRespublicanStudents / totalAcategoryMaleStudents * 100 # 50%

# Question 4 : იმ სტუდენტებში, რომელთა religiosity=0, რამდენ პროცენტს ჯერავს სიცოცხლის გარდაცვალების შემდეგ (life_after_death =y)
totalStudentsWithZeroReligion <- length(subset(data, data$religiosity == 0)$religiosity)
totalStudentsWithZeroReligionAndBelieveInAfterLife <- length(subset(data, data$religiosity == 0 & data$life_after_death == 'y')$religiosity)
answerFour <- totalStudentsWithZeroReligionAndBelieveInAfterLife / totalStudentsWithZeroReligion * 100 # 26.7%

# Question 5 : იმ ქალ სტუდენტებში, რომელთა religiosity=0, რამდენ პროცენტს ჯერავს სიცოცხლის გარდაცვალების შემდეგ (life_after_death =y) 
femaleStudentsWithZeroReligion <- length(subset(data, data$religiosity == 0 & data$gender == 'f')$religiosity)
femaleStudentsWithZeroReligionAndBelieveInAfterLife <- length(subset(data, data$religiosity == 0 & data$life_after_death == 'y' & data$gender == 'f')$religiosity)
answerFive <- femaleStudentsWithZeroReligionAndBelieveInAfterLife / femaleStudentsWithZeroReligion * 100 # 40%

# Question 6 : არარესპუბლიკელ ქალ სტუდენტებში(political_affiliation), რამდენი პროცენტი უჭერს აბორტის ლეგალიზებას ორსულობის პირველ სამ თვეში (abortion_legalize):
nonRespublicanFemaleStudents <- length(subset(data, data$political_affiliation != 'r' & data$gender == 'f')$political_affiliation)
nonRespublicanFemaleStudentsSupportingAbortion <- length(subset(data, data$political_affiliation != 'r' & data$gender == 'f' & data$abortion_legalize == 'y')$political_affiliation)
answerSix <- nonRespublicanFemaleStudentsSupportingAbortion / nonRespublicanFemaleStudents * 100 # 92%

# Question 7 : აბორტის ლეგალიზების მომხრეებში, რამდენი პროცენტია რესპუბლიკელი ქალი სტუდენტი:
studentsSupportingAbortion <- length(subset(data, data$abortion_legalize == 'y')$abortion_legalize)
studentsSupportingAbortionAndRespublicanWomen <- length(subset(data, data$abortion_legalize == 'y' & data$political_affiliation == 'r' & data$gender == 'f')$abortion_legalize)
answerSeven <- studentsSupportingAbortionAndRespublicanWomen / studentsSupportingAbortion * 100 # 6.4%

# Question 8 : 
# ყუთში 5 ფორთოხალი და 4 ვაშლია. ყუთიდან შემთხვევით იღებენ 3 ხილს. 
# რისი ტოლია ალბათობა იმისა, რომ სამივე ხილი ფორთოხალია? პასუხი
# ახლოს უნდა იყოს 0.12-თან. დაწერეთ კოდი(სიმულაციების რაოდენობა აიღეთ 100000-ის ტოლი).

box <- c(rep('Orange', 5), rep('Apple', 4))
iterations <- 100000
count <- 0

for (i in 1:iterations) {
  sample <- sample(box, 3)
  if (length(subset(sample, sample == 'Orange')) == 3) {
    count <- count + 1
  }
}

answerEight <- count / iterations # 0.119

# Question 9 :
# ცირკის წარმოდგენის დროს სამ მაყურებელს თავაზობენ ჩაიფიქრონ 1-დან 10-ის 
# ჩათვლით ნებისმიერი ერთი მთელი რიცხვი.იპოვეთ ალბათობა იმისა, რომ
# სამი მაყურებლის მიერ ჩაფიქრებული ციფრებიდან, ორი მაყურებლის მიერ
# ჩაფიქრებული ციფრი მაინც დაემთხვევა. პასუხი ახლოს უნდა იყოს 0.28-თან.
# დაწერეთ კოდი(სიმულაციების რაოდენობა აიღეთ 100000-ის ტოლი).
choises <- c(1:10)
iterations <- 100000
count <- 0

for (i in 1:iterations) {
  sample <- sample(choises, 3, replace = TRUE)
  if(length(unique(sample)) < 3) {
    count <- count + 1
  }
}

answerNine <- count / iterations # 0.28















