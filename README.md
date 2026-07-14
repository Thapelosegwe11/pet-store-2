# pet-store-2

![NUnit](https://img.shields.io/badge/NUnit-3.13-blue) ![RestSharp](https://img.shields.io/badge/RestSharp-latest-green) ![.NET](https://img.shields.io/badge/.NET-8.0-purple) ![Docker](https://img.shields.io/badge/Docker-Compose-blue)

## Description
Automated API tests for the Swagger Petstore application using RestSharp and NUnit in C#. Extends pet-store-1 by adding HTTP POST and DELETE request testing for adding and removing pets, and placing orders.

## 🛠️ Tech Stack
- **Language:** C#
- **Testing Framework:** NUnit
- **HTTP Client:** RestSharp
- **API Definition:** Swagger/OpenAPI
- **System Under Test:** Swagger Petstore (via Docker)

## 📁 Project Structure
pet-store-2/
├── PetstoreTests/
│   ├── BaseTest.cs        # Base class with RestSharp client setup
│   ├── InventoryTests.cs  # Tests for GET /store/inventory
│   ├── PetTests.cs        # Tests for GET, POST, DELETE /pet
│   └── OrderTests.cs      # Tests for placing orders
└── .lms/
└── exercises.toml     # School submission file

## ✅ Prerequisites
- .NET 8.0
- Docker

## ⚙️ Installation
Clone the repo:
```bash
git clone git@github.com:Thapelosegwe11/pet-store-2.git
cd pet-store-2
```

## 🐳 Running the Petstore API with Docker
```bash
docker run -d -p 80:8080 -e SWAGGER_BASE_PATH=/v2 swaggerapi/petstore
```

Verify it's running at:
http://localhost:80

## 🧪 Running the Tests
```bash
cd PetstoreTests
dotnet test
```

## 📋 Test Cases
| Test Class | Test | Description |
|------------|------|-------------|
| PetTests | GetPetThatExists | Verifies GET /pet/1 returns a valid pet |
| PetTests | GetPetThatDoesNotExist | Verifies GET /pet/99 handles missing pet |
| PetTests | AddPet | Verifies POST /pet adds a new pet |
| PetTests | RemovePet | Verifies DELETE /pet removes a pet |
| OrderTests | PlaceOrder | Verifies POST /store/order places an order |

## 🔧 Troubleshooting
- **Connection refused** — Make sure Docker is running and Petstore container is up
- **.NET version error** — Make sure you have .NET 8.0 installed

## 📄 License
This project is for educational purposes at WeThinkCode_.
