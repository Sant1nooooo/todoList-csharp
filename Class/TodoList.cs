using System;
using System.Collections.Generic;
public class TodoList : ITodoList
{
  private List<Todo> _todoList = new List<Todo>();

  public TodoList() { }
  public Todo GetTodo(int index)
  {
      foreach (Todo eachTodo in _todoList) {
          if (eachTodo.Id == index) return eachTodo;
      }
      throw new ArgumentException("Todo does not exist on the index you entered!");
  }

  public void AddTodo<T>(T todo) where T : Todo
  {
    _todoList.Add(todo);
  }


  public void RemoveTodo(int index) {
    if (index > 0 && index <= _todoList.Count) {
      _todoList.RemoveAt(index-1);
    }
    else
    {
      throw new ArgumentException("THE NUMBER YOU ENTERED DOES NOT EXIST ON THE LIST! (Remove Todo)");
    }
  }

  public void MarkTodo(int index)
  {

    if (index > 0 && index <= _todoList.Count)
    {
        _todoList[index-1].IsDone = true;
    }
    else
    {
      throw new ArgumentException("THE NUMBER YOU ENTERED DOES NOT EXIST ON THE LIST! (Mark Todo)");
    }
  }
  public void MarkAllTodo()
  {
    if(_todoList.Count <= 0)
    {
      throw new ArgumentException("Todo List is empty, please create a new todo! (Mark All Todo)");
    }
    foreach (Todo eachTodo in _todoList)
    {
        eachTodo.IsDone = true;
    }
  }

  public string GetAllTodos() {
    if(_todoList.Count > 0)
    {
      var doneTask = "\n\nDONE TASK:\nINDEX\t\tTitle\t\t\tType\t\t\tOther(s)\n";
      var onGoingTask = "ONGOING TASK:\nINDEX\t\tTitle\t\t\tType\t\t\tOther(s)\n";
      var numbering = 1;
      foreach(Todo todo in _todoList){
        if(todo.IsDone)
        {
          if(todo is Assignment assignment)
          {
            doneTask += $"{numbering}\t\t{todo.Title}\t\t{todo.Type}\t\t{assignment.Subject}\t{assignment.Teacher}\t{assignment.Grade}\t{assignment.Deadline}\n";
          }
          else if(todo is Event eventTodo)
          {
            doneTask += $"{numbering}\t\t{todo.Title}\t\t{todo.Type}\t\t{eventTodo.Date}\t{eventTodo.StartTime}\t{eventTodo.EndTime}\n";
          }
        }
        else
        {
          if(todo is Assignment assignment)
          {
            onGoingTask += $"{numbering}\t\t{todo.Title}\t\t{todo.Type}\t\t{assignment.Subject}\t{assignment.Teacher}\t{assignment.Grade}\t{assignment.Deadline}\n";
          }
          else if(todo is Event eventTodo)
          {
            onGoingTask += $"{numbering}\t\t{todo.Title}\t\t{todo.Type}\t\t{eventTodo.Date}\t{eventTodo.StartTime}\t{eventTodo.EndTime}\n";
          }
        }
        numbering++;
      }
      return $"{onGoingTask}{doneTask}";
    }

    throw new ArgumentException("Todo List is empty, please create a new todo! (Get All Todo)");
  }
}