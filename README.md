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