# Task Manager Application

Task Manager is a console-based application built with .NET 9.0. It allows users to manage tasks by adding, viewing, deleting, and marking tasks as completed. The application provides an interactive interface for navigating and managing tasks.

## Features

- Add new tasks with a title and description.
- View a list of tasks with details such as title, description, completion status, and due date.
- Navigate through tasks using keyboard controls.
- Mark tasks as completed.
- Delete tasks.

### Key Components

- **`Task.cs`**: Represents a task with properties like title, description, completion status, and due date.
- **`TaskService.cs`**: Provides methods to manage tasks, such as adding, removing, and marking tasks as completed.
- **`TasksView.cs`**: Handles the user interface for displaying and interacting with tasks.
- **`Program.cs`**: Entry point of the application.

## How to Run

1. Ensure you have the .NET 9.0 SDK installed on your system.
2. Clone this repository or download the source code.
3. Open a terminal in the project directory and run the following command to build and run the application:

   ```bash
   dotnet run --project TaskManager.csproj
   ```

## Usage

- Start the application: Run the program to launch the Task Manager.
- Navigate tasks: Use the ↑/↓ arrow keys or K/J to navigate through the task list.
- Add a new task: Press N to add a new task by entering its title and description.
- Mark a task as completed: Press R to mark the selected task as completed.
- Delete a task: Press Delete to remove the selected task.
- Exit selection mode: Press ESC to exit the task selection mode.

## Requirements

.NET 9.0 SDK or later.

-## License
This project is licensed under the MIT License. See the LICENSE file for details.
