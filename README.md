# Equity Position Management Application

This is a web application for managing equity positions based on transaction data. It allows users to input transactions, view current positions, and track historical transactions.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [API Endpoints](#api-endpoints)
- [Getting Started](#getting-started)
- [Running the Application](#running-the-application)
- [Contributing](#contributing)
- [License](#license)
- [Asserts](#Asserts)

## Features

- Dashboard to display current equity positions in real-time.
- Transaction input form to add new transactions (Insert, Update, Cancel).
- Transaction history page to view past transactions.
- Error and validation handling for user inputs.

## Technologies Used

- **Frontend**: Angular 18 (with Reactive Forms)
- **Backend**: .NET Core Web API 8
- **Database**: SQL Server / Entity Framework Core
- **Routing**: Angular Router

## API Endpoints

### Transaction Management API

- **POST** `/api/transactions`  
  Add a new transaction.  
  **Request Body**:
  ```json
  {
      "tradeID": 1,
      "version": 1,
      "securityCode": "REL",
      "quantity": 50,
      "action": "INSERT",
      "buySell": "Buy"
  }


GET /api/transactions
Retrieve all transactions.

PUT /api/transactions/{transactionId}
Update an existing transaction by its ID.
Request Body:
{
    "version": 2,
    "quantity": 60,
    "action": "UPDATE",
    "buySell": "Buy"
}
DELETE /api/transactions/{transactionId}
Cancel a transaction by its ID.

Position Calculation API
GET /api/positions
Retrieve current positions based on processed transactions.


## Asserts
Asserts folder contails he screenshot related to database creation , table creation and insert/update scenarios showned with select statement.
