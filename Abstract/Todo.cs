using System;

public abstract class Todo
{
    /*
        The reason why I make this `Todo` abstract base class is because both `Assignment` and `Event` derived class has the
        SAME CLASS MEMBERS AND IMPLEMENTATION (attributes and methods) such as title, isDOne, type, id for class attributes, 
        and Title, Type, IsDone, and Id for methods
    */
    private string _title;
    private bool _isDone;
    private string _type;
    private int _id;
    private static int s_idCounter = 0;

    public Todo(string title, string type)
    {
        this._title = title;
        this._type = type;
        this._isDone = false;
        this._id = s_idCounter;

        s_idCounter++;
    }

    public string Title 
    { 
        get { return this._title; } 
        set{
            this._title = value;
        }
    }

    public string Type { 
        get { return this._type; } 
        set{
            this._type = value;
        }
    }

    public bool IsDone { 
        get{ return this._isDone; } 
        set{
            this._isDone = value;
        } 
    }

    public int Id { 
        get{ return this._id; }
    }
}