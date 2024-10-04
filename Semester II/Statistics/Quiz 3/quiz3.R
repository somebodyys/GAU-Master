data <- read.csv("fl_student_survey.csv", header=TRUE, sep=",", dec=".")

# Task 1
#  გამოთვალეთ P სიდიდე. μ აღნიშნავს სტუდენტების პოპულაციის
# სპორტისთვის დათმობილი დროის საშუალოს (sports ცვლადი).
mean_sports <- mean(data$sports)

mu <- 5

t_test <- t.test(data$sports, mu = mu, alternative = "greater")
p_value <- t_test$p.value
# პასუხი 0.36


# Task 2
# გამოთვალეთ P სიდიდე. π აღნიშნავს დემოკრატი სტუდენტების წილს
# სტუდენტების მთლიან პოპულაციაში(political_affiliation = d).
num_democrats <- sum(data$political_affiliation == "d")
total_students <- nrow(data)

pi_null <- 0.3

prop_test <- prop.test(x = num_democrats, n = total_students, p = pi_null, alternative = "greater")

p_value <- prop_test$p.value
# პასუხი 0.24


# Task 3
# გამოთვალეთ P სიდიდე. μ აღნიშნავს სტუდენტების პოპულაციის
# ტელევიზორის ყურებისადმი დათმობილი დროის საშუალოს ( TV ცვლადი).
mean_tv <- mean(data$TV)

mu <- 5
t_test <- t.test(data$TV, mu = mu, alternative = "greater")
p_value <- t_test$p.value
# პასუხი 0.00567 ~ 0.006


# Task 4 
# გამოთვალეთ P სიდიდე. π აღნიშნავს იმ სტუდენტების წილს სტუდენტების
# მთლიან პოპულაციაში, რომელთაც ჯერავს სიცოცხლის გარდაცვალების
# შემდეგ (life_after_death = y)
num_believe <- sum(data$life_after_death == "y")
total_students <- nrow(data)

pi_null <- 0.4
prop_test <- prop.test(num_believe, total_students, p = pi_null, alternative = "greater")
p_value <- prop_test$p.value
# პასუხი 0.043365


# Task 5 
# π აღნიშნავს იმ სტუდენტების წილს სტუდენტების მთლიან პოპულაციაში,
# რომელთაც ჯერავს სიცოცხლის გარდაცვალების შემდეგ (life_after_death = y).
# α = 0.07 -თვის უარყოფთ თუ არა ჰიპოთეზას.
num_believe <- sum(data$life_after_death == "y")
total_students <- nrow(data)

pi_null <- 0.4
alpha <- 0.07
conf_level = 1 - alpha

prop_test <- prop.test(num_believe, total_students, p = pi_null, alternative = "two.sided", conf.level = conf_level)

conf_int <- prop_test$conf.int

if (conf_int[1] <= pi_null && conf_int[2] >= pi_null) {
  print("უარყოფის საფუძველი არ გაგვაჩნია!")
} else {
  print("ჰიპოთეზა შეგვიძლია უარვყოთ!")
}
# პასუხი უარყოფის საფუძველი არ გაგვაჩნია!

