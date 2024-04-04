import numpy as np
import pandas as pd


def generate_car_data(n_samples=500):
    np.random.seed(0)
    volume = np.random.uniform(1.0, 5.0, size=n_samples)
    max_speed = np.random.randint(120, 300, size=n_samples)
    release_year = np.random.randint(2000, 2023, size=n_samples)
    price = 10000 * volume + 2000 * max_speed - 1000 * (2023 - release_year) + np.random.normal(0, 10000, size=n_samples)
    return pd.DataFrame({'Engine_Volume': volume, 'Max_Speed': max_speed, 'Release_Year': release_year, 'Price': price})


def run():
    car_data = generate_car_data()

    correlation_matrix = car_data.corr()
    correlation_coefficients = correlation_matrix['Price']

    print("Correlation coefficients:")
    print(correlation_coefficients)

