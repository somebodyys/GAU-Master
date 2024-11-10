import numpy as np


def sigmoid(x):
    return 1 / (1 + np.exp(-x))


def sigmoid_derivative(x):
    return sigmoid(x) * (1 - sigmoid(x))


def mse_loss(y_pred, y_true):
    return 0.5 * np.mean((y_pred - y_true) ** 2)


def mse_loss_derivative(y_pred, y_true):
    return y_pred - y_true


class NeuralNetwork:
    def __init__(self, input_size, hidden_size, output_size, learning_rate=0.1):
        self.w_hidden = np.random.randn(hidden_size, input_size)
        self.b_hidden = np.random.randn(hidden_size)

        self.w_output = np.random.randn(output_size, hidden_size)
        self.b_output = np.random.randn(output_size)

        self.learning_rate = learning_rate

    def forward(self, x):
        self.z_hidden = np.dot(self.w_hidden, x) + self.b_hidden
        self.a_hidden = sigmoid(self.z_hidden)

        self.z_output = np.dot(self.w_output, self.a_hidden) + self.b_output
        self.a_output = sigmoid(self.z_output)

        return self.a_output

    def backward(self, x, y_true):
        dL_da_output = mse_loss_derivative(self.a_output, y_true)
        da_output_dz_output = sigmoid_derivative(self.z_output)
        dL_dz_output = dL_da_output * da_output_dz_output

        dL_dw_output = np.outer(dL_dz_output, self.a_hidden)
        dL_db_output = dL_dz_output

        dL_da_hidden = np.dot(self.w_output.T, dL_dz_output)
        da_hidden_dz_hidden = sigmoid_derivative(self.z_hidden)
        dL_dz_hidden = dL_da_hidden * da_hidden_dz_hidden

        dL_dw_hidden = np.outer(dL_dz_hidden, x)
        dL_db_hidden = dL_dz_hidden

        self.w_output -= self.learning_rate * dL_dw_output
        self.b_output -= self.learning_rate * dL_db_output
        self.w_hidden -= self.learning_rate * dL_dw_hidden
        self.b_hidden -= self.learning_rate * dL_db_hidden

    def train(self, x, y_true, error_margin=0.001, max_iterations=10000):
        iteration = 0
        while True:
            y_pred = self.forward(x)

            loss = mse_loss(y_pred, y_true)

            if loss < error_margin or iteration >= max_iterations:
                print(f"Training complete. Final loss: {loss}")
                break

            self.backward(x, y_true)

            if iteration % 1000 == 0:
                print(f"Iteration {iteration}: Loss = {loss}")

            iteration += 1


input_size = 2
hidden_size = 3
output_size = 1

nn = NeuralNetwork(input_size, hidden_size, output_size, learning_rate=0.1)

x = np.array([1, -1])
y_true = np.array([1])

nn.train(x, y_true, error_margin=0.001)
