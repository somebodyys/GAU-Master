import numpy as np
from matplotlib import pyplot as plt


def relu(x):
    return np.maximum(0, x)


# Activation Functions
def relu_derivative(x):
    return np.where(x > 0, 1, 0)


def sigmoid(x):
    return 1 / (1 + np.exp(-x))


def sigmoid_derivative(x):
    return x * (1 - x)


class FeedForwardNeuralNetwork:
    def __init__(self, input_size, hidden_layers, output_size):
        self.layer_outputs = None
        self.layer_inputs = None
        self.input_size = input_size
        self.hidden_layers = hidden_layers
        self.output_size = output_size

        self.weights = []
        self.biases = []

        self.weights.append(np.random.randn(input_size, hidden_layers[0]))
        self.biases.append(np.zeros((1, hidden_layers[0])))

        for i in range(len(hidden_layers) - 1):
            self.weights.append(np.random.randn(hidden_layers[i], hidden_layers[i + 1]))
            self.biases.append(np.zeros((1, hidden_layers[i + 1])))

        self.weights.append(np.random.randn(hidden_layers[-1], output_size))
        self.biases.append(np.zeros((1, output_size)))

        self.losses = []
        self.accuracies = []

    def forward(self, x):
        self.layer_inputs = []
        self.layer_outputs = []

        input_layer = x
        for i in range(len(self.weights)):
            self.layer_inputs.append(input_layer)
            input_layer = relu(np.dot(input_layer, self.weights[i]) + self.biases[i]) if i < len(
                self.weights) - 1 else sigmoid(np.dot(input_layer, self.weights[i]) + self.biases[i])
            self.layer_outputs.append(input_layer)

        return self.layer_outputs[-1]

    def backward(self, x, y, learning_rate):
        m = x.shape[0]  # batch size
        output = self.layer_outputs[-1] - y  # derivative of the loss function w.r.t output
        output = output / m  # average over batch size

        for i in reversed(range(len(self.weights))):
            if i == len(self.weights) - 1:
                deactivation = output * sigmoid_derivative(self.layer_outputs[i])
            else:
                deactivation = output * relu_derivative(self.layer_outputs[i])

            dw = np.dot(self.layer_inputs[i].T, deactivation)  # Gradient of weights
            db = np.sum(deactivation, axis=0, keepdims=True)  # Gradient of biases

            # Update weights and biases
            self.weights[i] -= learning_rate * dw
            self.biases[i] -= learning_rate * db

            # Prepare for the previous layer's backpropagation
            output = np.dot(deactivation, self.weights[i].T)

    # Training the Model
    def train(self, x, y, epochs=1000, batch_size=32, learning_rate=0.01):
        for epoch in range(epochs):
            # Shuffle the data
            perm = np.random.permutation(x.shape[0])
            x_shuffled = x[perm]
            y_shuffled = y[perm]

            # Mini-batch gradient descent
            for i in range(0, x.shape[0], batch_size):
                batch_x = x_shuffled[i:i + batch_size]
                batch_y = y_shuffled[i:i + batch_size]

                # Perform a forward pass and then backpropagation
                self.forward(batch_x)
                self.backward(batch_x, batch_y, learning_rate)

            # Evaluate performance
            if epoch % 100 == 0:
                loss, accuracy = self.evaluate(x, y)
                self.losses.append(loss)
                self.accuracies.append(accuracy)
                print(f"Epoch {epoch}, Loss: {loss:.4f}, Accuracy: {accuracy:.4f}")

    # Evaluation of the model
    def evaluate(self, x, y):
        predictions = self.forward(x)
        predictions = (predictions > 0.5).astype(int)  # Threshold for classification
        accuracy = np.mean(predictions == y)
        loss = -np.mean(y * np.log(predictions + 1e-8) + (1 - y) * np.log(1 - predictions + 1e-8))
        return loss, accuracy

    # Plotting loss and accuracy
    def plot_loss_and_accuracy(self):
        plt.figure(figsize=(12, 6))

        # Loss plot
        plt.subplot(1, 2, 1)
        plt.plot(range(0, len(self.losses) * 100, 100), self.losses)
        plt.title("Loss over epochs")
        plt.xlabel("Epochs")
        plt.ylabel("Loss")

        # Accuracy plot
        plt.subplot(1, 2, 2)
        plt.plot(range(0, len(self.accuracies) * 100, 100), self.accuracies)
        plt.title("Accuracy over epochs")
        plt.xlabel("Epochs")
        plt.ylabel("Accuracy")

        plt.tight_layout()
        plt.show()
