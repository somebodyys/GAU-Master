import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
from datetime import datetime

# Step 1: მონაცემების წაკითხვა
data = pd.read_csv('GlobalTemperatures.csv')

# Step 2: მონახემების გაწმენდა და მომზადება
data['dt'] = pd.to_datetime(data['dt'])
data.dropna(inplace=True)  # ცარიელი ტრქიონებისაგან გაწმენდა
data.set_index('dt', inplace=True)

# Step 3: პირველადი ვიზუალიზაცია
plt.figure(figsize=(12, 6))
plt.plot(data.index, data['LandAverageTemperature'], label='Land Average Temperature')
plt.plot(data.index, data['LandAverageTemperatureUncertainty'], label='Temperature Uncertainty')
plt.xlabel('Date')
plt.ylabel('Temperature')
plt.title('Historical Land Average Temperature and Uncertainty')
plt.legend()
plt.show()

# Step 4: მონაცემების გაყოფა დასატრენინგებელ და დასატესტ მონაცემებად
X = data.index.astype(int).values.reshape(-1, 1)
y_temp = data['LandAverageTemperature'].values
y_uncertainty = data['LandAverageTemperatureUncertainty'].values

X_train_temp, X_test_temp, y_train_temp, y_test_temp = train_test_split(X, y_temp, test_size=0.2, random_state=42)
X_train_uncertainty, X_test_uncertainty, y_train_uncertainty, y_test_uncertainty = train_test_split(X, y_uncertainty,
                                                                                                    test_size=0.2,
                                                                                                    random_state=42)

# Step 5: წრფივი რეგრესიული მოდელების აწყობა
model_temp = LinearRegression()
model_uncertainty = LinearRegression()

# Step 6: მოდელის დატრენინგება
model_temp.fit(X_train_temp, y_train_temp)
model_uncertainty.fit(X_train_uncertainty, y_train_uncertainty)

# Step 7: სატესტო მონაცემების შეფასება
score_temp = model_temp.score(X_test_temp, y_test_temp)
score_uncertainty = model_uncertainty.score(X_test_uncertainty, y_test_uncertainty)
print("Model Accuracy - Temperature:", score_temp)
print("Model Accuracy - Uncertainty:", score_uncertainty)

# Step 8 : მომდევნო 20 წლის პრედიქციების გაკეთება
future_dates_20_years = pd.date_range(start=data.index[-1], periods=240, freq='ME')
future_dates_numeric_20_years = future_dates_20_years.astype(int).values.reshape(-1, 1)
future_temp_predictions_20_years = model_temp.predict(future_dates_numeric_20_years)
future_uncertainty_predictions_20_years = model_uncertainty.predict(future_dates_numeric_20_years)

# Step 9 : წარსული და მომავალი პრედიქციის ვიზუალიზაცია
plt.figure(figsize=(12, 6))
plt.plot(data.index, data['LandAverageTemperature'], label='Historical Temperature')
plt.plot(future_dates_20_years, future_temp_predictions_20_years, label='Predicted Temperature', linestyle='dashed')
plt.xlabel('Date')
plt.ylabel('Temperature')
plt.title('Historical and Predicted Land Average Temperature with Trend Line (20 Years)')
plt.legend()

# ტრენდის მიახლოებითი წრფის ვიზუალიზაცია საშუალო ტემპერატურისათვის
z_temp_20_years = np.polyfit(data.index.astype(int), data['LandAverageTemperature'], 1)
p_temp_20_years = np.poly1d(z_temp_20_years)
plt.plot(data.index, p_temp_20_years(data.index.astype(int)), color='red', label='Trend Line')

plt.legend()
plt.show()

plt.figure(figsize=(12, 6))
plt.plot(data.index, data['LandAverageTemperatureUncertainty'], label='Historical Uncertainty')
plt.plot(future_dates_20_years, future_uncertainty_predictions_20_years, label='Predicted Uncertainty',
         linestyle='dashed')
plt.xlabel('Date')
plt.ylabel('Uncertainty')
plt.title('Historical and Predicted Temperature Uncertainty with Trend Line (20 Years)')
plt.legend()

# ტრენდის მიახლოებითი წრფის ვიზუალიზაცია ცდომილებისათვის
z_uncertainty_20_years = np.polyfit(data.index.astype(int), data['LandAverageTemperatureUncertainty'], 1)
p_uncertainty_20_years = np.poly1d(z_uncertainty_20_years)
plt.plot(data.index, p_uncertainty_20_years(data.index.astype(int)), color='red', label='Trend Line')

plt.legend()
plt.show()


# Step 10: სამომავლო პრედიქციები
def predict_temperature_and_uncertainty(date):
    date_numeric = datetime.strptime(date, '%Y-%m-%d').date()
    date_numeric = date_numeric.toordinal()
    temp_prediction = model_temp.predict([[date_numeric]])[0]
    uncertainty_prediction = model_uncertainty.predict([[date_numeric]])[0]
    return temp_prediction, uncertainty_prediction


# მაგალითი:
predicted_temp, predicted_uncertainty = predict_temperature_and_uncertainty('2045-01-01')
print("Predicted Temperature for 2045-01-01:", predicted_temp)
print("Predicted Uncertainty for 2045-01-01:", predicted_uncertainty)
