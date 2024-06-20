from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.common.by import By
import csv

service = Service('/usr/local/bin/chromedriver')

source_url = "https://en.wikipedia.org/wiki/List_of_best-selling_manga"


def scrape_manga_data(url):
    driver = webdriver.Chrome(service=service)
    driver.get(url)

    tables = driver.find_elements(By.XPATH,
                                  '/html/body/div[2]/div/div[3]/main/div[3]/div[3]/div[1]/table[position() >= 2 and '
                                  'position() <= 5]')

    csv_filename = 'manga_data.csv'
    with open(csv_filename, 'w', newline='', encoding='utf-8') as csvfile:
        csv_writer = csv.writer(csvfile)

        headers = ['Manga series', 'Author(s)', 'Publisher', 'Demographic', 'No. of collected volumes', 'Serialized',
                   'Approximate sales', 'Average sales per volume']
        csv_writer.writerow(headers)

        for table in tables:
            rows = table.find_elements(By.TAG_NAME, 'tr')

            for row in rows:

                data = []
                cells = row.find_elements(By.TAG_NAME, 'td')

                for cell in cells:
                    data.append(cell.text.strip())

                csv_writer.writerow(data)

    driver.quit()
    print(f"Scraping finished. Data saved to {csv_filename}")


scrape_manga_data(source_url)
