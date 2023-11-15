using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject
{
    private List<Observer> observers = new List<Observer>();
    private string state;

    public string GetState()
    {
        return state;
    }

    public void SetState(string state)
    {
        this.state = state;
        NotifyAllObservers();
    }

    public void Attach(Observer observer)
    {
        observers.Add(observer);
    }

    public void NotifyAllObservers()
    {
        foreach (Observer observer in observers)
        {
            observer.Update();
        }
    }
}

public abstract class Observer
{
    protected Subject subject;
    public abstract void Update();
}