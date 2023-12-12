using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updater : MonoBehaviour
{
    ConcreteObservable observable = new ConcreteObservable();
    ConcreteObserver observer1;
    ConcreteObserver observer2;
    public GameObject Object1;
    public GameObject Object2;
    void Start()
    {
      

        observer1 = new ConcreteObserver(Object1);
        observer2 = new ConcreteObserver(Object2);

        observable.AddObserver(observer1);
        observable.AddObserver(observer2);

        // Trigger the event
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        observable.DoSomething();
    }

}
