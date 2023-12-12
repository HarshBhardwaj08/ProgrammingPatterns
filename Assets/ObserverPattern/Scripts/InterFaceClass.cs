using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObservable
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

// IObserver interface
public interface IObserver
{
    void Update();
}

// ConcreteObservable class  
public class ConcreteObservable : IObservable
{
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update();
        }
    }

    // Method that triggers an event
    public void DoSomething()
    {
       Debug.Log("ConcreteObservable is doing something.");
        NotifyObservers();
    }
}

// ConcreteObserver class
public class ConcreteObserver : IObserver
{
    GameObject name;

    public ConcreteObserver(GameObject name)
    {
        this.name = name;
    }

    public void Update()
    {
       name.SetActive(false);
    }
}