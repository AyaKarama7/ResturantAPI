# Restaurant API

This is a comprehensive RESTful API for a restaurant management system, built with .NET 8 and following the principles of Clean Architecture. The API allows for managing restaurants, their dishes, and user roles, with a secure authorization system.

## Features

* **Restaurant Management**: Endpoints for creating, retrieving, updating, and deleting restaurants.
* **Dish Management**: Endpoints to manage dishes specific to each restaurant.
* **Role-Based Access Control**: Secure endpoints based on user roles (Admin, Owner, User).
* **Identity Management**: Assign and unassign roles to users.
* **CI/CD Pipeline**: Automated build and test pipeline using GitHub Actions, with deployment configured for Microsoft Azure.
* **Azure Deployment**: The application is deployed on Azure 

## API Endpoints

Here is a summary of the available API endpoints:

### Restaurant

| Method | Endpoint | Access | Description |
| --- | --- | --- | --- |
| `GET` | `/api/Resturant` | Anonymous | Retrieves a list of all restaurants. |
| `GET` | `/api/Resturant/{id}` | Anonymous | Retrieves a specific restaurant by its ID. |
| `POST` | `/api/Resturant` | **Owner** | Creates a new restaurant. |
| `PATCH` | `/api/Resturant/{id}` | **Owner** | Updates an existing restaurant's details. |
| `DELETE` | `/api/Resturant/{id}` | **Admin** | Deletes a restaurant. |

### Dishes

| Method | Endpoint | Access | Description |
| --- | --- | --- | --- |
| `GET` | `/api/resturant/{resturantId}/dishes` | **Owner**, **User** | Retrieves all dishes for a specific restaurant. |
| `GET` | `/api/resturant/{resturantId}/dishes/get-dish-by-id` | **Owner**, **User** | Retrieves a specific dish by its ID for a given restaurant. |
| `POST` | `/api/resturant/{resturantId}/dishes` | **Owner** | Creates a new dish for a restaurant. |
| `PATCH` | `/api/resturant/{resturantId}/dishes` | **Owner** | Updates a dish in a restaurant. |
| `DELETE` | `/api/resturant/{resturantId}/dishes` | **Owner** | Deletes a dish from a restaurant. |

### Identity

| Method | Endpoint | Access | Description |
| --- | --- | --- | --- |
| `POST` | `/api/Identity/user-role` | **Admin** | Assigns a role to a user. |
| `DELETE` | `/api/Identity/user-role-remove` | **Admin** | Removes a role from a user. |

## Technologies & Architecture

* **.NET 8**: The project is built on the latest version of the .NET platform.
* **ASP.NET Core**: For building the RESTful API.
* **Entity Framework Core**: For data access and management.
* **MediatR**: To implement the CQRS (Command Query Responsibility Segregation) pattern, promoting a clean and decoupled architecture.
* **Clean Architecture**: The solution is structured into `Domain`, `Application`, `Infrastructure`, and `API` layers, ensuring separation of concerns and maintainability.

## Setup and Installation

To run this project locally, follow these steps:

1.  **Clone the repository:**
    ```bash
    git clone <your-repository-url>
    cd resturantapi
    ```

2.  **Restore dependencies:**
    ```bash
    dotnet restore
    ```

3.  **Update Database Connection:**
    Make sure to update the connection string in `src/Resturant.API/appsettings.json` to point to your local database.

4.  **Apply Migrations:**
    ```bash
    dotnet ef database update --project src/Resturant.Infrastructure
    ```

5.  **Run the application:**
    ```bash
    dotnet run --project src/Resturant.API
    ```

6.  **Run tests:**
    ```bash
    dotnet test
    ```

## CI/CD Pipeline

This project is configured with a Continuous Integration (CI) pipeline using **GitHub Actions**. The workflow is defined in the `.github/workflows/main.yml` file and includes the following steps:

* **Trigger**: The workflow is triggered on every `pull_request` to the `main` branch.
* **Build**: The .NET 8 project is built to ensure there are no compilation errors.
* **Test**: The associated test suite is run automatically to validate the functionality.

Following a successful CI process, the application is set up for Continuous Deployment (CD) to **Microsoft Azure**, ensuring seamless and automated deployments.
