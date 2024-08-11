using System;
using System.Threading.Tasks;

TodoList todoList = new TodoList();

todoList.AddTodo(new Assignment("Assignment 1", "CS001", "Jerome Bercero", "Tommorow"));
int selectedNumber = 0;
do
{
    selectedNumber = await HandleSelectNumber();
    switch (selectedNumber)
    {
        case 1:
            try
            {
                Console.WriteLine(todoList.GetAllTodos());
            }
            catch (ArgumentException err)
            {
                Console.WriteLine($"Error: {err.Message}");
            }
        break;

        case 2:
            HandleAddTodo();
        break;

        case 3:
            HandleRemoveTodo();
        break;

        case 4:
            await HandleMarkTodo();
        break;

        case 5:
            HandleMarkAllTodo();
        break;

        default:
            break;
    }
}
while (selectedNumber != 6);



async Task HandleMarkTodo()
{
    try
    {
        Console.WriteLine(todoList.GetAllTodos());
        Console.Write("Enter the number of todo you want to mark as done: ");
        int index = Convert.ToInt32(Console.ReadLine());

        await VirtualDelayAsync();
        todoList.MarkTodo(index);
    }
    catch (ArgumentException err)
    {
        Console.WriteLine($"Error: {err.Message}");
    }
}
void HandleRemoveTodo()
{
    try
    {
        Console.WriteLine(todoList.GetAllTodos());
        Console.Write("Enter the number of todo you want to remove: ");
        int number = Convert.ToInt32(Console.ReadLine());
        todoList.RemoveTodo(number);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
void HandleAddTodo()
{
    bool isNotValid = true;
    int number = 0;
    while (isNotValid)
    {
        Console.WriteLine("1. Assignment");
        Console.WriteLine("2. Event");
        Console.Write("Enter the number of the task you want to create: ");
        number = Convert.ToInt32(Console.ReadLine());
        if (number < 1 || number > 2)
        {
            Console.WriteLine("Please enter 1-2 numbers only: ");
            Console.WriteLine("==================");
        }
        else
        {
            isNotValid = false;
        }
    }


    Console.Write("Title: ");
    string title = Console.ReadLine() ?? string.Empty;

    if (number == 1) //If the task is an assignment
    {
        Console.Write("Subject: ");
        string subject = Console.ReadLine() ?? string.Empty;

        Console.Write("Teacher: ");
        string teacher = Console.ReadLine() ?? string.Empty;

        Console.Write("Deadline: ");
        string deadline = Console.ReadLine() ?? string.Empty;

        todoList.AddTodo(new Assignment(title, subject, teacher, deadline));
        return;
    }

    //If the todo is an Event
    Console.Write("Date: ");
    string date = Console.ReadLine() ?? string.Empty;

    Console.Write("Start Time: ");
    string startTime = Console.ReadLine() ?? string.Empty;

    Console.Write("End Time: ");
    string endTime = Console.ReadLine() ?? string.Empty;

    todoList.AddTodo(new Event(title, date, startTime, endTime));
}
async Task<int> HandleSelectNumber()
{
    bool isNotValid = true;
    int number = 0;
    while (isNotValid)
    {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("1. Show Todo List");
        Console.WriteLine("2. Add Todo");
        Console.WriteLine("3. Remove Todo");
        Console.WriteLine("4. Mark Todo");
        Console.WriteLine("5. Mark All Todo");
        Console.WriteLine("6. Exit");
        Console.Write("Enter number: ");
        number = Convert.ToInt32(Console.ReadLine());
        if (number < 1 || number > 6)
        {
            Console.WriteLine("Please enter 1-6 numbers only: ");
            Console.WriteLine("==================");
        }
        else
        {
            isNotValid = false;
            if (number == 6)
            {
                return number;
            }
        }
    }
    Console.WriteLine("==================");
    Console.WriteLine("Please wait...");
    Console.WriteLine("==================");
    await Task.Delay(2000);
    return number;
}
void HandleMarkAllTodo()
{
    try
    {
        todoList.MarkAllTodo();
    }
    catch (ArgumentException err)
    {
        Console.WriteLine($"Error: {err.Message}");
    }
}

async Task VirtualDelayAsync()
{
    Console.WriteLine("==================");
    Console.WriteLine("Please wait...");
    Console.WriteLine("==================");
    await Task.Delay(2000); //2 seconds
}