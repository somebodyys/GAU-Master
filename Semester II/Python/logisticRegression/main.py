import numpy as np
import matplotlib.pyplot as plt
from sklearn.linear_model import LogisticRegression

# Simulate data
np.random.seed(0)
exam_scores = np.random.normal(50, 15, 100).reshape(-1, 1)
acceptance_prob = 1 / (1 + np.exp(-(0.1 * exam_scores - 5)))
accepted = np.random.binomial(1, acceptance_prob).reshape(-1)  # Reshaping here

# Fit logistic regression model
model = LogisticRegression()
model.fit(exam_scores, accepted)

# Plotting the data
plt.scatter(exam_scores, accepted, color='black', label='Data')

# Plot logistic regression curve
x_values = np.linspace(0, 100, 100)
y_values = model.predict_proba(x_values.reshape(-1, 1))[:, 1]
plt.plot(x_values, y_values, color='blue', label='Logistic Regression Curve')

plt.xlabel('Exam Score')
plt.ylabel('Probability of Acceptance')
plt.title('Logistic Regression for University Acceptance Prediction')
plt.legend()
plt.grid(True)
plt.show()
