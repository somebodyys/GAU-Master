import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.cluster import KMeans

data = pd.read_csv('manga_data.csv')

data['Approximate sales'] = data['Approximate sales'].str.split().str[0].astype(float)
data['Average sales per volume'] = data['Average sales per volume'].str.split().str[0].astype(float)

X = data[['Approximate sales', 'Average sales per volume']]

X_train, X_test = train_test_split(X, test_size=0.2, random_state=42)

k = 3
model = KMeans(n_clusters=k, random_state=42)

model.fit(X_train)
labels = model.predict(X_test)

X_test_with_labels = X_test.copy()
X_test_with_labels['Cluster'] = labels

print("კლასტერების ცენტრები: ")
print("0: ", model.cluster_centers_[0])
print("1: ", model.cluster_centers_[1])
print("2: ", model.cluster_centers_[2])
print("პრედიქციის კლასტერები: ", labels[:10])

new_data_point = [[500, 5]]
predicted_cluster = model.predict(new_data_point)
print(f"პროგნოზირებული კლასტერი = {predicted_cluster}")
