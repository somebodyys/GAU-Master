import numpy as np


def sigmoid(x):
    return 1 / (1 + np.exp(-x))


def sigmoid_derivative(x):
    return sigmoid(x) * (1 - sigmoid(x))


def mse_loss(y_pred, y_true):
    return 0.5 * (y_pred - y_true) ** 2


def mse_loss_derivative(y_pred, y_true):
    return y_pred - y_true


# Parameters
x = np.array([1, -1])
y_true = 1

w1_hidden = np.array([0.5, -1.5])
b1_hidden = 0.2
w2_hidden = np.array([1, 1])
b2_hidden = -0.4

w1_output = np.array([1.5, -0.5])
b_output = 1

# Forward propagation
z1_hidden = np.dot(w1_hidden, x) + b1_hidden
z2_hidden = np.dot(w2_hidden, x) + b2_hidden

a1_hidden = sigmoid(z1_hidden)
a2_hidden = sigmoid(z2_hidden)

z_output = np.dot(w1_output, [a1_hidden, a2_hidden]) + b_output

a_output = sigmoid(z_output)

loss = mse_loss(a_output, y_true)

print(f"z1_hidden = {z1_hidden}")
print(f"a1_hidden = sigmoid(z1_hidden) = {a1_hidden}")
print(f"z2_hidden = {z2_hidden}")
print(f"a2_hidden = sigmoid(z2_hidden) = {a2_hidden}")
print(f"z_output = {z_output}")
print(f"a_output = sigmoid(z_output) = {a_output}")
print(f"loss = 0.5 * (a_output - y_true)^2 = {loss}")

# Backpropagation
dL_da_output = mse_loss_derivative(a_output, y_true)
da_output_dz_output = sigmoid_derivative(z_output)
dL_dz_output = dL_da_output * da_output_dz_output

dL_dw1_output = dL_dz_output * a1_hidden
dL_dw2_output = dL_dz_output * a2_hidden
dL_db_output = dL_dz_output

dz_output_da1_hidden = w1_output[0]
dz_output_da2_hidden = w1_output[1]

dL_da1_hidden = dL_dz_output * dz_output_da1_hidden
dL_da2_hidden = dL_dz_output * dz_output_da2_hidden

da1_hidden_dz1_hidden = sigmoid_derivative(z1_hidden)
da2_hidden_dz2_hidden = sigmoid_derivative(z2_hidden)

dL_dz1_hidden = dL_da1_hidden * da1_hidden_dz1_hidden
dL_dz2_hidden = dL_da2_hidden * da2_hidden_dz2_hidden

dL_dw1_hidden = dL_dz1_hidden * x[0]
dL_dw2_hidden = dL_dz1_hidden * x[1]
dL_db1_hidden = dL_dz1_hidden

dL_dw3_hidden = dL_dz2_hidden * x[0]
dL_dw4_hidden = dL_dz2_hidden * x[1]
dL_db2_hidden = dL_dz2_hidden

learning_rate = 0.001

w1_output[0] -= learning_rate * dL_dw1_output
w1_output[1] -= learning_rate * dL_dw2_output
b_output -= learning_rate * dL_db_output

w1_hidden[0] -= learning_rate * dL_dw1_hidden
w1_hidden[1] -= learning_rate * dL_dw2_hidden
b1_hidden -= learning_rate * dL_db1_hidden

w2_hidden[0] -= learning_rate * dL_dw3_hidden
w2_hidden[1] -= learning_rate * dL_dw4_hidden
b2_hidden -= learning_rate * dL_db2_hidden

print(f"\nBackpropagation adjustments:")
print(f"Gradient dL/da_output = {dL_da_output}")
print(f"Gradient da_output/dz_output = {da_output_dz_output}")
print(f"Gradient dL/dz_output = {dL_dz_output}")
print(f"Gradient dL/dw1_output = {dL_dw1_output}")
print(f"Gradient dL/dw2_output = {dL_dw2_output}")
print(f"Gradient dL/db_output = {dL_db_output}")

print(f"Gradient dL/dz1_hidden = {dL_dz1_hidden}")
print(f"Gradient dL/dw1_hidden = {dL_dw1_hidden}")
print(f"Gradient dL/dw2_hidden = {dL_dw2_hidden}")
print(f"Gradient dL/db1_hidden = {dL_db1_hidden}")

print(f"Gradient dL/dz2_hidden = {dL_dz2_hidden}")
print(f"Gradient dL/dw3_hidden = {dL_dw3_hidden}")
print(f"Gradient dL/dw4_hidden = {dL_dw4_hidden}")
print(f"Gradient dL/db2_hidden = {dL_db2_hidden}")

print("\nAdjusted weights and biases:")
print(f"New w1_hidden = {w1_hidden}")
print(f"New b1_hidden = {b1_hidden}")
print(f"New w2_hidden = {w2_hidden}")
print(f"New b2_hidden = {b2_hidden}")
print(f"New w1_output = {w1_output}")
print(f"New b_output = {b_output}")

print("\nSummary of old and new values:")
print("Old w1_hidden = [0.5, -1.5], New w1_hidden =", w1_hidden)
print("Old b1_hidden = 0.2, New b1_hidden =", b1_hidden)
print("Old w2_hidden = [1, 1], New w2_hidden =", w2_hidden)
print("Old b2_hidden = -0.4, New b2_hidden =", b2_hidden)
print("Old w1_output = [1.5, -0.5], New w1_output =", w1_output)
print("Old b_output = 1, New b_output =", b_output)
