# 🧪 SampleDTO (.NET 8 Minimal API)

This project is a clean, modular implementation of a **Minimal API** in **.NET 8**, demonstrating how to use **DTOs**, **repositories**, and **extension methods** for a scalable and maintainable API structure.

## 🗂️ Project Structure

```bash
SampleDTO/
├── DTO/
│   ├── Requests/
│   │   ├── CreateProductRequest.cs
│   │   └── UpdateProductRequest.cs
│   └── Responses/
│       └── ProductResponse.cs
├── Endpoints/
│   └── ProductEndpoints.cs
├── Entities/
│   └── Product.cs
├── Extensions/
│   └── ProductDtoExtensions.cs
├── Middleware/
│   └── ErrorHandlingMiddleware.cs
├── Repositories/
│   ├── IProductRepository.cs
│   └── ProductRepository.cs
├── Program.cs
├── appsettings.json
└── SampleDTO.http

```
## 🚀 Features

✅ Minimal API using MapGroup for clean route organization

✅ DTO pattern for clear separation between API and domain models

✅ Repository pattern for in-memory product data

✅ Extension methods for entity-DTO transformation

✅ Custom error handling middleware with global exception capture

✅ Scalar UI support via MapScalarApiReference

✅ Well-organized folder structure for scalability

## 🛠 Technologies Used

- .NET 8
- Minimal APIs
- DTOs & Records
- Dependency Injection
- Custom Middleware
- Scalar (OpenAPI UI)
- LINQ & In-Memory Data
- C# 12 (File-scoped types, etc.)

## 📦 Setup

### Prerequisites
- .NET 8 SDK

### Running the API

```bash
dotnet run
```
The API will be available at:

```URL
https://localhost:{port}
```
Visit ```/scalar/v1``` for the Scalar-based interactive API UI.

## 🧪 API Endpoints

| Method | Endpoint             | Description            |
| ------ | -------------------- | ---------------------- |
| GET    | `/api/products`      | Get all products       |
| GET    | `/api/products/{id}` | Get product by ID      |
| POST   | `/api/products`      | Create a new product   |
| PATCH  | `/api/products/{id}` | Update an existing one |
| DELETE | `/api/products/{id}` | Delete a product       |

## 🧰 Future Improvements
- Add persistent storage (EF Core / database)
- Add validation (using MiniValidation or FluentValidation)
- Implement API versioning when needed
- Unit tests with xUnit / NUnit
- Pagination and filtering

## 🤝 Contributing
Contributions welcome! Fork the repo, open an issue, or submit a PR.

## 📄 License
MIT — free to use and modify

## 👨‍💻 Author
**Elanchezhiyan P**  
📧 elanche97@gmail.com