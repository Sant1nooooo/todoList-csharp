using System;

public class Event:Todo{
    private string _date;
    private string _startTime;
    private string _endTime;

    public Event(string title, string date, string startTime, string endTime) : base(title, "Event") { 
        this._date = date;
        this._startTime = startTime;
        this._endTime = endTime;
    }

    //Local Methods
    public string Date
    {
        get { return this._date;  }
        set {
            this._date = value;
        }
    }
    public string StartTime
    {
        get { return this._startTime; }
        set
        {
            this._startTime = value;
        }
    }
    public string EndTime
    {
        get { return this._endTime; }
        set
        {
            this._endTime = value;
        }
    }
}