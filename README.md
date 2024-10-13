# PolyglotAPI - Backend

## Overview
PolyglotAPI is an API designed to manage and provide data for a language courses website. It interacts with a MySQL database containing information about students (alunos), professors, enrollments (matricula), and courses (cursos). This API is used to retrieve, create, update, and delete records related to language courses, allowing a frontend web application to display and manage the data.

## Features
- **Student Management**: Perform CRUD operations on students (alunos) in the system.
- **Professor Management**: Handle professor data, including their courses and personal details.
- **Enrollment Management**: Manage student enrollments (matricula) to various courses.
- **Course Management**: CRUD operations for courses offered by the language school.

## Technologies Used
- **C# & .NET 6**: Backend development with ASP.NET Core.
- **MySQL**: Database to store all data related to students, professors, courses, and enrollments.
- **Entity Framework Core**: ORM for database operations, migrations, and schema management.
- **Swagger**: For API documentation and testing.

## Database Entities
- **Aluno (Student)**: Contains details such as name, email, birthdate, and contact information.
- **Professor**: Manages information about course instructors, including name, expertise level, and contact details.
- **Matricula (Enrollment)**: Tracks student enrollments in different courses.
- **Curso (Course)**: Describes the language courses available, including name, duration, and difficulty level.

## API Endpoints
Here is the continuation of the README file:

---

### Aluno (Student) Endpoints
- **GET /api/alunos**: Retrieves a list of all students.
- **GET /api/alunos/{id}**: Retrieves a specific student by ID.
- **POST /api/alunos**: Adds a new student to the system.
- **PUT /api/alunos/{id}**: Updates an existing student's information.
- **DELETE /api/alunos/{id}**: Deletes a student from the system.

### Professor Endpoints
- **GET /api/professores**: Retrieves a list of all professors.
- **GET /api/professores/{id}**: Retrieves a specific professor by ID.
- **POST /api/professores**: Adds a new professor.
- **PUT /api/professores/{id}**: Updates an existing professor's details.
- **DELETE /api/professores/{id}**: Deletes a professor from the system.

### Matricula (Enrollment) Endpoints
- **GET /api/matriculas**: Retrieves a list of all enrollments.
- **GET /api/matriculas/{id}**: Retrieves a specific enrollment by ID.
- **POST /api/matriculas**: Enrolls a student in a course.
- **DELETE /api/matriculas/{id}**: Deletes an enrollment.

### Curso (Course) Endpoints
- **GET /api/cursos**: Retrieves a list of all courses.
- **GET /api/cursos/{id}**: Retrieves a specific course by ID.
- **POST /api/cursos**: Adds a new course to the system.
- **PUT /api/cursos/{id}**: Updates an existing course's details.
- **DELETE /api/cursos/{id}**: Deletes a course from the system.

## Setup and Installation

### Prerequisites
- .NET 6 SDK
- MySQL server (or any compatible database)
- Visual Studio or any IDE that supports .NET development
```
