# 🌦️ WeatherStation
> A full-stack learning project: React (Vite) + .NET Core Web API.

This repository documents a ground-up journey into building enterprise-grade .NET applications. Unlike standard tutorials, this documentation explains the "Why" behind every command and architectural decision, written for developers coming from a generic web background.

---

## 🏗️ 1. Architecture: The Monorepo
We are using a **Monorepo Solution** structure. This keeps the Backend and Frontend in a single repository but logically separated.

    weather-app/
    ├── 📄 WeatherStation.sln        # The "Manager" (Builds the backend)
    │
    ├── 📂 WeatherStation.Server/    # The Brains (.NET Web API)
    │   └── (Handles Data, Logic, Auth, Database)
    │
    └── 📂 weather-client/           # The Face (React + Vite)
        └── (Handles UI, User Interaction)

---

## 🚀 2. Setup Log (Step-by-Step)

### Step A: The Solution File (.sln)
In .NET, we don't just have "folders". We have **Solutions**. A Solution is a container that groups multiple related projects (like an Auth API, a Payment API, and a Weather API) so they can be built together.

**Command:**
`dotnet new sln -n WeatherStation`

* `dotnet new`: The standard command to create something.
* `sln`: Tells .NET we want a "Solution File".
* `-n WeatherStation`: Names the file `WeatherStation.sln`.

### Step B: The Backend (.NET Web API)
We created the server project using the Web API template.

**Command:**
`dotnet new webapi -n WeatherStation.Server --use-controllers`

* `webapi`: A template pre-configured for REST APIs (comes with HTTP listeners, JSON parsing, etc.).
* `--use-controllers`: Explicitly tells .NET to use the classic **Controller-based architecture** (Classes) instead of the newer "Minimal API" (Functions). This is better for organized, enterprise apps.

### Step C: The Frontend (React + Vite)
We used Vite to generate a fast, modern React environment.

**Command:**
`npm create vite@latest weather-client -- --template react-ts`

* `weather-client`: The name of the folder to create.
* `--` (The Barrier): Everything after this double-dash is passed directly to the Vite tool, not npm.
* `--template react-ts`: Tells Vite to set up React with **TypeScript** immediately.

### Step D: Linking Backend to Solution
We need to tell the `.sln` file that the Server project exists.

**Command:**
`dotnet sln add WeatherStation.Server`

* **Why only the server?** The `.sln` file is a **.NET Build Tool**. It knows how to compile C# code. It does not know how to compile React (that is Node's job). So, the frontend lives *physically* inside the folder, but *logically* outside the .NET Solution.

---

## 🧹 3. "Tabula Rasa" (The Cleanup)
To understand the code, we deleted the default templates provided by Microsoft.

**Deleted Files:**
1.  `WeatherStation.Server/WeatherForecast.cs` (The default data model).
2.  `WeatherStation.Server/Controllers/WeatherForecastController.cs` (The default API endpoint).

**Result:**
We now have a clean, compiling backend with 0 endpoints.

---

## 📚 4. Concept Glossary

| Term | Definition |
| :--- | :--- |
| **.sln (Solution)** | A text file that acts as a "Table of Contents" for .NET projects. It helps Visual Studio build complex apps with multiple parts. |
| **.csproj** | The configuration file for a *single* project (e.g., just the Server). It lists dependencies (NuGet packages). |
| **NuGet** | The package manager for .NET (Equivalent to **npm** in Node.js). |
| **Program.cs** | The entry point of the backend. It sets up the server, dependency injection, and security pipeline before the app starts. |
| **Controller** | A class that listens for HTTP requests (like `GET /api/weather`) and decides what code to run. |

### 5. Creating the First Endpoint (The "Hello World")
We manually created a Data Model and a Controller to establish a working API.

**1. The Model (`WeatherForecast.cs`)**
Defined the shape of our data.
* **Key Concept:** We used `DateOnly` (a modern .NET type) instead of `DateTime` to strictly represent calendar dates without time components.
* **Key Concept:** We used `string?` (Nullable String) to explicitly allow the Summary to be empty, enforcing strict Null Safety.

**2. The Controller (`Controllers/WeatherController.cs`)**
Created the endpoint that listens for requests.
* **`[ApiController]`**: An attribute that upgrades a standard class into an API handler with built-in validation.
* **`[Route("api/[controller]")]`**: A dynamic route template. It automatically maps the URL to the class name (e.g., `WeatherController` becomes `/api/weather`).
* **Automatic Serialization**: We returned a C# `List<WeatherForecast>`, and .NET automatically converted it to JSON for the browser.

## 🧠 6. Deep Dive: Key Technical Concepts (Q&A)

### The Model (WeatherForecast.cs)
* **Namespaces**: Act as "Surnames" for code to prevent naming collisions (e.g., `MyApp.User` vs `Google.User`).
* **Auto-Properties (`{ get; set; }`)**: A C# shorthand that creates a private field and public access methods automatically.
* **Nullable Types (`?`)**:
    * **Value Types (`int`)**: Cannot be null by default. Must use `int?`.
    * **Reference Types (`string`)**: Can physically be null, but modern .NET enforces explicit `string?` to prevent crashes.

**Q: Fields vs. Properties (`{ get; set; }`)**
* **Field (`public int X;`)**: A raw variable. **Warning:** default JSON serializers often ignore fields.
* **Property (`public int X { get; set; }`)**: A wrapper method. Serializers look for these to generate JSON. Always use Properties for API models.

**Q: Nullable Types (`int?` vs `int`)**
* The `?` acts as a toggle for "Optional Data".
* We used `int` (no `?`) for Temperature because a weather report *must* have a temperature.
* We used `string?` (with `?`) for Summary because a text description is optional.

**Q: Method Naming (`Get()` vs `GetWeather()`)**
* In APIs, the `[HttpGet]` attribute controls the URL, not the method name.
* Naming the method `Get()` is a standard convention to match the HTTP Verb, though descriptive names are also valid.

**Q: Using Directives**
* If the IDE says a `using` is unnecessary, it means the class is already visible in the current scope (either they share the same namespace, or it is globally imported).

### The Controller (WeatherController.cs)
* **`[ApiController]`**: An attribute that enforces strict HTTP rules (Automatic 400 errors, attribute routing).
* **`ControllerBase`**: The parent class we inherit from. It provides built-in helper methods like `Ok()`, `NotFound()`, and access to `User` data.
* **`IEnumerable`**: A generic interface for any collection (List, Array) that can be looped over.
* **Route `[controller]`**: A dynamic token that is replaced by the class name (minus "Controller"). `WeatherController` -> `/weather`.

### The Entry Point (Program.cs)
* **The Builder**: Prepares the tools (Services) the app needs.
* **The App**: The running instance that handles requests.
* **`MapControllers`**: Scans the project for `[Route]` attributes and creates the URL map.

---

## 🛠️ 7. Code Corrections
**Fix for WeatherController.cs:**
The controller needs to import the Model's namespace to see `WeatherForecast`.