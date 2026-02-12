# Finance & Subscription Tracker

A simple C# console application to manage and track your monthly/yearly subscriptions.

## Features
* **Manage Subscriptions:** Add, remove, and list your services.
* **Monthly Burn Rate:** Calculates how much you spend per month (automatically converts yearly payments to monthly).
* **Currency Support:** Handles CZK, EUR, and USD with built-in conversion rates.
* **Data Persistence:** Automatically saves everything to `DATA.json` using `System.Text.Json`.
* **Clean UI:** Uses custom Logger for colorful feedback and clear navigation.

## Learning Goals
The main goal of this project was to:
1. Learn **Enums** for fixed data types (Categories, Currencies).
2. Learn **Object-Oriented Programming (OOP)** by structuring code into multiple managers.
3. Handle **JSON serialization** and file I/O.

## Installation
1. Clone the repository.
2. Open in Visual Studio or use `dotnet run` in your terminal.
