import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.svm import SVR
from sklearn.metrics import mean_squared_error
import numpy as np

data = pd.read_csv('manga_data.csv')

data['Approximate sales'] = data['Approximate sales'].str.split().str[0].astype(float)
data['Average sales per volume'] = data['Average sales per volume'].str.split().str[0].astype(float)
data['No. of collected volumes'] = data['No. of collected volumes'].str.split('[').str[0].astype(float)

X = data[['Approximate sales', 'Average sales per volume']]
y = data['No. of collected volumes']

X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

model = SVR(kernel='linear')
model.fit(X_train, y_train)

y_pred = model.predict(X_test)

rmse = np.sqrt(mean_squared_error(y_test, y_pred))

print(f"ცდომილება: {rmse}")

new_data_point = [[500, 5]]
predicted_volumes = model.predict(new_data_point)
print(f"Prognosis for new data point: Predicted volumes = {predicted_volumes}")
