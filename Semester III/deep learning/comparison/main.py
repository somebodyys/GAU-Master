import tensorflow as tf
from tensorflow.keras.models import Sequential
from tensorflow.keras.layers import Dense, Flatten, Conv2D, MaxPooling2D
from tensorflow.keras.optimizers import Adam
from tensorflow.keras.utils import to_categorical
import matplotlib.pyplot as plt


def load_and_preprocess_mnist():
    (x_train, y_train), (x_test, y_test) = tf.keras.datasets.mnist.load_data()

    x_train = x_train / 255.0
    x_test = x_test / 255.0

    x_train = x_train.reshape(-1, 28, 28, 1)
    x_test = x_test.reshape(-1, 28, 28, 1)

    y_train = to_categorical(y_train, 10)
    y_test = to_categorical(y_test, 10)

    return (x_train, y_train), (x_test, y_test)


def build_fcnn_model():
    model = Sequential([
        Flatten(input_shape=(28, 28, 1)),
        Dense(128, activation='relu'),
        Dense(10, activation='softmax')
    ])
    model.compile(optimizer=Adam(), loss='categorical_crossentropy', metrics=['accuracy'])
    return model


def build_cnn_model():
    model = Sequential([
        Conv2D(32, kernel_size=(3, 3), activation='relu', input_shape=(28, 28, 1)),
        MaxPooling2D(pool_size=(2, 2)),
        Flatten(),
        Dense(128, activation='relu'),
        Dense(10, activation='softmax')
    ])
    model.compile(optimizer=Adam(), loss='categorical_crossentropy', metrics=['accuracy'])
    return model


def train_and_evaluate_models(fcnn_model, cnn_model, x_train, y_train, x_test, y_test, epochs=5):
    fcnn_history = fcnn_model.fit(x_train, y_train, epochs=epochs, validation_data=(x_test, y_test), verbose=1)
    fcnn_eval = fcnn_model.evaluate(x_test, y_test, verbose=0)

    cnn_history = cnn_model.fit(x_train, y_train, epochs=epochs, validation_data=(x_test, y_test), verbose=1)
    cnn_eval = cnn_model.evaluate(x_test, y_test, verbose=0)

    return fcnn_history, cnn_history, fcnn_eval, cnn_eval


def plot_comparison(fcnn_history, cnn_history):
    plt.figure(figsize=(14, 6))
    plt.subplot(1, 2, 1)
    plt.plot(fcnn_history.history['accuracy'], label='FCNN Train Accuracy', color='blue')
    plt.plot(fcnn_history.history['val_accuracy'], label='FCNN Val Accuracy', color='cyan')
    plt.plot(cnn_history.history['accuracy'], label='CNN Train Accuracy', color='green')
    plt.plot(cnn_history.history['val_accuracy'], label='CNN Val Accuracy', color='lime')
    plt.xlabel('Epoch')
    plt.ylabel('Accuracy')
    plt.title('Model Accuracy Comparison')
    plt.legend()
    plt.grid(True)

    plt.subplot(1, 2, 2)
    plt.plot(fcnn_history.history['loss'], label='FCNN Train Loss', color='blue')
    plt.plot(fcnn_history.history['val_loss'], label='FCNN Val Loss', color='cyan')
    plt.plot(cnn_history.history['loss'], label='CNN Train Loss', color='green')
    plt.plot(cnn_history.history['val_loss'], label='CNN Val Loss', color='lime')
    plt.xlabel('Epoch')
    plt.ylabel('Loss')
    plt.title('Model Loss Comparison')
    plt.legend()
    plt.grid(True)

    plt.tight_layout()
    plt.show()


if __name__ == "__main__":
    (x_train, y_train), (x_test, y_test) = load_and_preprocess_mnist()

    fcnn_model = build_fcnn_model()
    cnn_model = build_cnn_model()

    fcnn_history, cnn_history, fcnn_eval, cnn_eval = train_and_evaluate_models(fcnn_model, cnn_model, x_train, y_train,
                                                                               x_test, y_test, epochs=5)

    print(f"FCNN Model: Accuracy={fcnn_eval[1]:.4f}, Loss={fcnn_eval[0]:.4f}")
    print(f"CNN Model: Accuracy={cnn_eval[1]:.4f}, Loss={cnn_eval[0]:.4f}")

    plot_comparison(fcnn_history, cnn_history)
