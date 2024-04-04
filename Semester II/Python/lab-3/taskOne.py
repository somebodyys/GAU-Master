import numpy as np
import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression


def generate_data(n_samples=1000):
    np.random.seed(0)
    area = np.random.randint(500, 5000, size=n_samples)
    num_rooms = np.random.randint(2, 6, size=n_samples)
    num_bedrooms = np.round(num_rooms * 0.9)
    price = 100 * area + np.random.normal(0, 1000, size=n_samples)
    return pd.DataFrame({'Area': area, 'Num_Rooms': num_rooms, 'Num_Bedrooms': num_bedrooms, 'Price': price})


def run():
    data = generate_data()

    x = data[['Area', 'Num_Rooms']]
    y = data['Price']

    x_train, x_test, y_train, y_test = train_test_split(x, y, test_size=0.2, random_state=0)

    model = LinearRegression()
    model.fit(x_train, y_train)

    inputs = pd.DataFrame({
        'Area': np.random.randint(1000, 5000, size=5),
        'Num_Rooms': np.random.randint(2, 6, size=5)
    })

    predictions = model.predict(inputs)
    inputs['Predicted_Price'] = predictions

    print("Inputs with Predicted Prices:")
    print(inputs)


