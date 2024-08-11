using System;

public interface ITodoList {
    Todo GetTodo(int index);
    void AddTodo<T>(T todo) where T : Todo;
    void RemoveTodo(int index);
    void MarkTodo(int index);
    void MarkAllTodo();
}