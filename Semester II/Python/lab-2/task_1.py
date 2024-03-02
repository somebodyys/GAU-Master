products = {
    "001": ("Smartphone", 599.99, 100, "2023-05-15"),
    "002": ("Laptop", 899.99, 50, "2023-07-20"),
    "003": ("Headphones", 149.99, 200, "2023-09-10"),
    "004": ("Smartwatch", 249.99, 75, "2023-08-05"),
    "005": ("Tablet", 399.99, 30, "2023-06-25")
}


def display_product(product_id, product):
    print(f"Product ID: {product_id}\n"
          f"Product Name: {product[0]}\n"
          f"Price: ${product[1]}\n"
          f"Quantity: {product[2]}\n"
          f"Expiry Date: {product[3]}\n\n")


def display_products():
    for product_id, product in products.items():
        display_product(product_id, product)


def get_product(product_id):
    product = products.get(product_id)
    display_product(product_id, product)


def add_product(product_id, product):
    products[product_id] = product


def update_quantity(product_id, quantity):
    product = products.get(product_id)
    if product:
        product = list(product)
        product[2] = quantity
        products[product_id] = tuple(product)
        print(f"Quantity updated to {quantity}")
    else:
        print("Product not found")


def delete_product(product_id):
    product = products.pop(product_id, None)
    if product:
        print(f"Product {product_id} deleted")
    else:
        print("Product not found")
