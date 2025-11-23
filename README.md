🚗 Stand Management System

The Stand Management System is an application developed to efficiently manage a car dealership, allowing the registration, consultation and updating of information related to vehicles, clients and employees, while applying solid Object-Oriented Programming principles.

Academic Context
This project was developed as part of the Object-Oriented Programming course in the 2nd year of the Computer Systems Engineering degree (IPCA).

🎯 Project Goals

Develop a modular and extensible application using Object-Oriented Programming principles (inheritance, encapsulation, interfaces, abstract classes).

Apply good practices in data persistence, error handling and logging.

Structure the solution using a layered architecture, ensuring a clear separation between domain, business rules and interface.

Build a functional system for dealership management with a focus on organization, clarity and security.

📌 Main Features
🚘 Vehicle Management

Register new vehicles.

View and list existing vehicles.

Update vehicle information.

👤 Client Management

Create, edit and view client information.

🧑‍💼 Employee Management

Employee creation.

Employee association within the system.

🏗️ Application Architecture

The solution follows a multi-layered architecture to ensure organization, extensibility and clear responsibility separation:

ObjetosNegocio (Business Objects)
Contains the main domain classes: Carro, Cliente, Funcionario, Stand, Log.

RegrasNegocio (Business Rules)
Implements business logic, validations and system operations.

Interface
Handles user interaction through menus and options.

Dados (Data Layer)
Responsible for reading and writing binary files used for persistence.

Main
Entry point of the application, initializing services and menus.

Testes (Tests)
Includes test cases to validate the correct behaviour of the modules.

💾 Persistence & Security

All data is stored in binary files, ensuring consistency and privacy.

The system implements logging, enabling monitoring and error detection.

Exception handling is applied to prevent failures and protect data integrity.

🧪 Tests

Includes unit and functional tests in the Testes folder.

Validates object creation, CRUD operations and business rules.