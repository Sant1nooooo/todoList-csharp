using System;

public class Assignment : Todo
{
    /*
        I created this derived class to be and inherit the `Todo` abstract base class to create a new entity that promotesthe concept of polymorphism.
        And the reason why this derived has its own class members is because this dervied class is unique on its own which makes it a new entity. And the common attributes
        such as `Title` and `Type` are being passed to its base class using the `base()` method.
    */
    private string _subject;
    private string _teacher;
    private int _grade;
    private string _deadline;

    public Assignment(string title, string subject, string teacher, string deadline) : base(title, "Assignment")
    {
        this._subject = subject;
        this._teacher = teacher;
        this._grade = 0;
        this._deadline = deadline;
    }

    //Local Methods
    public string Subject
    {
        get { return this._subject; }
        set
        {
            this._subject = value;
        }
    }
    public string Teacher
    {
        get { return this._teacher; }
        set
        {
            this._teacher = value;
        }
    }
    public int Grade
    {
        get { return this._grade; }
        set
        {
            this._grade = value;
        }
    }
    public string Deadline
    {
        get { return this._deadline; }
        set
        {
            this._deadline = value;
        }
    }

} 