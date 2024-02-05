using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    MovementStateMachine mStateMachine;
    void Start()
    {
        mStateMachine = new MovementStateMachine();
        mStateMachine.SetState(new IdleState(), transform);
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            mStateMachine.SetState(new MoveState(), transform);

        }
        else if (Input.GetKeyDown(KeyCode.I))
        { mStateMachine.SetState(new IdleState(),transform); }
        mStateMachine.Update(transform);
    }
}
