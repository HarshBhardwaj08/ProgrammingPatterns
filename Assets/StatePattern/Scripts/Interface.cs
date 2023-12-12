using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Imovements
{
    public void startState(Transform transform);
    public void stop();
    public void update(Transform transform);
}

public class IdleState : Imovements
{
    public void startState(Transform transform)
    {
       
    }

    public void stop()
    {
       
    }

    public void update(Transform transform)
    {
        
    }
}
public class MoveState : Imovements
{
    public void startState(Transform transform)
    {
       
    }

    public void stop()
    {
       
    }

    public void update(Transform transform)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        
        Vector2 movement = new Vector2(horizontalInput,  verticalInput);
        transform.Translate(movement * Time.deltaTime);
    }
}
public class MovementStateMachine
{
    private Imovements currentState;

    public void SetState(Imovements newState, Transform transform)
    {
        if (currentState != null)
            currentState.stop();

        currentState = newState;
        currentState.startState(transform);
    }

    public void Update(Transform transform)
    {
        currentState.update(transform);
    }
}