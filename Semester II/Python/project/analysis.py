import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
from sklearn.metrics import mean_absolute_error, r2_score

file_path = 'library_data_export.xlsx'
df_authors = pd.read_excel(file_path, sheet_name='Authors')
df_books = pd.read_excel(file_path, sheet_name='Books')
df_loans = pd.read_excel(file_path, sheet_name='Loans')

df_merged = pd.merge(df_books, df_loans[['book_id', 'return_date']], on='book_id', how='inner')

X = df_merged[['author_id', 'publication_year']]
y = pd.to_datetime(df_merged['return_date']).astype(int)

X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)
model = LinearRegression()
model.fit(X_train, y_train)

y_pred = model.predict(X_test)
y_pred_datetime = pd.to_datetime(y_pred.astype(int))

mae = mean_absolute_error(y_test, y_pred)
r2 = r2_score(y_test, y_pred)

print(f"ცდომილება: {mae / 86400}")
print(f"R-squared: {r2}")

new_data = pd.DataFrame({'author_id': [1], 'publication_year': [2011]})
predicted_return_date = model.predict(new_data)
predicted_return_date = pd.to_datetime(predicted_return_date.astype(int))

print(f"პრედიქცია: {predicted_return_date.strftime('%Y-%m-%d')}")
