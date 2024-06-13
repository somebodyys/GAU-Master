import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
from sklearn.metrics import mean_squared_error

# შესაძლებელია!

file_path = 'intern.xlsx'
df_hr = pd.read_excel(file_path, sheet_name='Sheet1')
df_it = pd.read_excel(file_path, sheet_name='Sheet2')

hr_scores = df_hr.iloc[:, 1:]
it_scores = df_it.iloc[:, 1:]

avg_hr_scores = hr_scores.mean(axis=1)
avg_it_scores = it_scores.mean(axis=1)

df_analysis = pd.DataFrame({'HR_Scores': avg_hr_scores, 'IT_Scores': avg_it_scores})

X = df_analysis[['HR_Scores']]
y = df_analysis['IT_Scores']

X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=0)

model = LinearRegression()

model.fit(X_train, y_train)

y_pred = model.predict(X_test)

mse = mean_squared_error(y_test, y_pred)
print(f'ცდომილება: {mse}')

coefficients = model.coef_
intercept = model.intercept_

print('y =', coefficients[0], '* x +', intercept)
