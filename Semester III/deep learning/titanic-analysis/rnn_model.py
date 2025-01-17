import numpy as np
from matplotlib import pyplot as plt


# Sigmoid function and its derivative (used for output layer)
def sigmoid(x):
    x = np.clip(x, -500, 500)
    return 1 / (1 + np.exp(-x))


def sigmoid_derivative(x):
    return x * (1 - x)


class RecurrentNeuralNetwork:
    def __init__(self, input_size, hidden_units, output_size):
        self.hidden_state = None
        self.input_size = input_size
        self.hidden_units = hidden_units
        self.output_size = output_size

        # Initializing weights for RNN layer and output layer
        self.W_xh = np.random.randn(input_size, hidden_units)  # Weight from input to hidden
        self.W_hh = np.random.randn(hidden_units, hidden_units)  # Weight from hidden to hidden (recurrence)
        self.W_hy = np.random.randn(hidden_units, output_size)  # Weight from hidden to output

        # Initializing biases
        self.b_h = np.zeros((1, hidden_units))
        self.b_y = np.zeros((1, output_size))

        # Loss tracking
        self.losses = []
        self.accuracies = []

    def forward(self, x):
        # Now, x is a 2D array (batch_size, input_size)
        h = np.zeros((x.shape[0], self.hidden_units))  # Initial hidden state (zeros)
        self.hidden_state = []  # To store hidden states at each time step
        output = np.zeros((x.shape[0], self.output_size))  # To store the output

        # Forward pass
        # No time steps, just feed-forward through hidden to output
        h = sigmoid(np.dot(x, self.W_xh) + self.b_h)  # Hidden state
        self.hidden_state.append(h)  # Track hidden state
        output = sigmoid(np.dot(h, self.W_hy) + self.b_y)  # Final output

        return output

    def backward(self, x, y, learning_rate):
        m = x.shape[0]  # Number of samples
        output = self.forward(x)
        error = output - y

        # Backpropagation through the network
        d_w_hy = np.dot(self.hidden_state[-1].T, error)
        db_y = np.sum(error, axis=0, keepdims=True)

        # Backward through RNN states
        d_w_xh = np.dot(x.T, error)

        # Update weights and biases
        self.W_hy -= learning_rate * d_w_hy
        self.b_y -= learning_rate * db_y
        self.W_xh -= learning_rate * d_w_xh

    # Training the Model
    def train(self, x, y, epochs=1000, batch_size=32, learning_rate=0.01):
        for epoch in range(epochs):
            perm = np.random.permutation(x.shape[0])
            x_shuffled = x[perm]
            y_shuffled = y[perm]

            for i in range(0, x.shape[0], batch_size):
                batch_x = x_shuffled[i:i + batch_size]
                batch_y = y_shuffled[i:i + batch_size]

                # Perform a forward pass and backpropagation
                self.forward(batch_x)
                self.backward(batch_x, batch_y, learning_rate)

            if epoch % 100 == 0:
                loss, accuracy = self.evaluate(x, y)
                self.losses.append(loss)
                self.accuracies.append(accuracy)
                print(f"Epoch {epoch}, Loss: {loss:.4f}, Accuracy: {accuracy:.4f}")

    # Evaluation of the model
    def evaluate(self, x, y):
        predictions = self.forward(x)
        predictions = (predictions > 0.5).astype(int)  # Apply threshold for classification
        accuracy = np.mean(predictions == y)
        loss = -np.mean(y * np.log(predictions + 1e-8) + (1 - y) * np.log(1 - predictions + 1e-8))
        return loss, accuracy

    # Plotting loss and accuracy
    def plot_loss_and_accuracy(self):
        plt.figure(figsize=(12, 6))

        plt.subplot(1, 2, 1)
        plt.plot(range(0, len(self.losses) * 100, 100), self.losses)
        plt.title("Loss over epochs")
        plt.xlabel("Epochs")
        plt.ylabel("Loss")

        plt.subplot(1, 2, 2)
        plt.plot(range(0, len(self.accuracies) * 100, 100), self.accuracies)
        plt.title("Accuracy over epochs")
        plt.xlabel("Epochs")
        plt.ylabel("Accuracy")

        plt.tight_layout()
        plt.show()
