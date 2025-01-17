import matplotlib
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import StandardScaler, LabelEncoder

from ffnn_model import FeedForwardNeuralNetwork
from rnn_model import RecurrentNeuralNetwork

matplotlib.use('TkAgg')


# Load datasets
def load_data():
    train = pd.read_csv("./dataset/train.csv")
    test = pd.read_csv("./dataset/test.csv")
    return train, test


# Normalize and preprocess datasets
def preprocess_data(train, test):
    # Fill missing values for Age
    train['Age'] = train['Age'].fillna(train['Age'].median())
    test['Age'] = test['Age'].fillna(test['Age'].median())

    # Fill missing values for Embarked
    train['Embarked'] = train['Embarked'].fillna(train['Embarked'].mode()[0])
    test['Embarked'] = test['Embarked'].fillna(test['Embarked'].mode()[0])

    # Fill missing values for Fare
    test['Fare'] = test['Fare'].fillna(test['Fare'].median())

    # Convert categorical variables to numeric
    le = LabelEncoder()
    train['Sex'] = le.fit_transform(train['Sex'])
    test['Sex'] = le.transform(test['Sex'])

    train['Embarked'] = le.fit_transform(train['Embarked'])
    test['Embarked'] = le.transform(test['Embarked'])

    # Normalize numerical features
    scaler = StandardScaler()
    numerical_features = ['Age', 'Fare']
    train[numerical_features] = scaler.fit_transform(train[numerical_features])
    test[numerical_features] = scaler.transform(test[numerical_features])

    # Drop unnecessary columns for the model
    drop_columns = ['PassengerId', 'Name', 'Ticket', 'Cabin']
    train = train.drop(columns=drop_columns)
    test = test.drop(columns=drop_columns)

    return train, test


if __name__ == "__main__":
    # Load and preprocess data
    train, test = load_data()
    train, test = preprocess_data(train, test)

    # Split the dataset into features (X) and labels (y)
    X_train = train.drop(columns='Survived').values
    y_train = train['Survived'].values.reshape(-1, 1)  # Reshape to make it 2D column vector

    # Split training data into training and validation sets
    X_train_split, X_val_split, y_train_split, y_val_split = train_test_split(X_train, y_train, test_size=0.2,
                                                                              random_state=42)

    # Initialize and train the FFNN model
    input_size = X_train_split.shape[1]  # Number of features
    hidden_layers = [32, 16]  # Architecture: two hidden layers with 32 and 16 neurons
    output_size = 1  # Binary classification output size

    model = FeedForwardNeuralNetwork(input_size, hidden_layers, output_size)
    print("Training the model...")
    model.train(X_train_split, y_train_split, epochs=1000, batch_size=32, learning_rate=0.01)

    # Evaluate the model on the validation set
    print("\nEvaluating on the validation set...")
    loss, accuracy = model.evaluate(X_val_split, y_val_split)
    print(f"Validation Loss: {loss:.4f}, Validation Accuracy: {accuracy:.4f}")

    # Optionally, plot the loss and accuracy over epochs
    model.plot_loss_and_accuracy()

    # Initialize and train the RNN model
    input_size = X_train_split.shape[1]  # Number of features
    hidden_units = 32  # Number of hidden units for RNN layer
    output_size = 1  # Binary output size for classification

    rnn_model = RecurrentNeuralNetwork(input_size, hidden_units, output_size)
    print("Training the RNN model...")
    rnn_model.train(X_train_split, y_train_split, epochs=1000, batch_size=32, learning_rate=0.01)

    # Evaluate the model on the validation set
    print("\nEvaluating the model on the validation set...")
    loss, accuracy = rnn_model.evaluate(X_val_split, y_val_split)
    print(f"Validation Loss: {loss:.4f}, Validation Accuracy: {accuracy:.4f}")

    # Plot the loss and accuracy over epochs
    rnn_model.plot_loss_and_accuracy()


def visualize_age_and_fate_distribution(train):
    # Set Seaborn Style
    sns.set(style="whitegrid")

    # Plotting distribution of numerical columns
    fig, axes = plt.subplots(1, 2, figsize=(14, 5))

    # Distribution of Age
    sns.histplot(train['Age'], kde=True, ax=axes[0], color='blue', bins=20)
    axes[0].set_title('Distribution of Age')

    # Distribution of Fare
    sns.histplot(train['Fare'], kde=True, ax=axes[1], color='green', bins=20)
    axes[1].set_title('Distribution of Fare')

    plt.tight_layout()
    plt.show()


def visualize_gender_and_survival_distribution(train):
    # Plot Pie/Donut charts for categorical features: Sex and Survived
    fig, axes = plt.subplots(1, 2, figsize=(14, 5))

    # Pie chart for Sex distribution
    sex_counts = train['Sex'].value_counts()
    axes[0].pie(sex_counts, labels=sex_counts.index, autopct='%1.1f%%', startangle=90, colors=['#66b3ff', '#ff99cc'],
                wedgeprops={'width': 0.3})
    axes[0].set_title('Distribution of Gender')

    # Pie chart for Survival distribution
    survival_counts = train['Survived'].value_counts()
    axes[1].pie(survival_counts, labels=survival_counts.index.map({0: 'Did not Survive', 1: 'Survived'}),
                autopct='%1.1f%%', startangle=90, colors=['#ff6666', '#66ff66'], wedgeprops={'width': 0.3})
    axes[1].set_title('Survival Distribution')

    plt.tight_layout()
    plt.show()


def visualize_correlation_heatmap(train):
    # Plot Correlation Heatmap
    correlation_matrix = train.corr()
    plt.figure(figsize=(8, 6))
    sns.heatmap(correlation_matrix, annot=True, cmap='coolwarm', fmt=".2f", linewidths=0.5)
    plt.title("Correlation Matrix")
    plt.show()
