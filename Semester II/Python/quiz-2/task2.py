import pandas as pd
import numpy as np
from sklearn.linear_model import LinearRegression

file_path = 'intern.xlsx'
df_hr = pd.read_excel(file_path, sheet_name='Sheet1')
df_it = pd.read_excel(file_path, sheet_name='Sheet2')

random_intern_index = np.random.randint(0, len(df_hr))
random_intern_id = df_hr.iloc[random_intern_index, 0]

print(f'შერჩეული კანდიდატი: {random_intern_id}')

hr_scores = df_hr.iloc[random_intern_index, 1:].astype(float)
it_scores = df_it.iloc[random_intern_index, 1:].astype(float)

valid_indices = ~np.isnan(hr_scores) & ~np.isnan(it_scores)
hr_scores_clean = hr_scores[valid_indices]
it_scores_clean = it_scores[valid_indices]

X = hr_scores_clean.values.reshape(-1, 1)
y = it_scores_clean.values

model = LinearRegression()
model.fit(X, y)

print(f'y = {model.intercept_} + {model.coef_[0]} * x')
