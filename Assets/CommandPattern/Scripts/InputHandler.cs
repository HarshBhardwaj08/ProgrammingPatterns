using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
   public Stack<ICommand> commandStack = new Stack<ICommand>();
    Stack<ICommand> historyStack = new Stack<ICommand>();  // New stack for undo

    public Player player;
    public float speed;
    float jump = 5;
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (x != 0)
        {
            ICommand moveCommand = new MoveCommand(player, x, speed);
            ExecuteCommand(moveCommand);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ICommand JumpCommand = new  jumpCommand(player ,jump);
            ExecuteCommand(JumpCommand);
        }

        if (Input.GetMouseButtonDown(0))
        {
            ICommand fireCommand = new ShootCommand(player);
            ExecuteCommand(fireCommand);
        }

        if (Input.GetKey(KeyCode.R))
        {
            Undo();
        }
    }

    void ExecuteCommand(ICommand command)
    {
        command.Execute();
        commandStack.Push(command);
        historyStack.Clear();  
    }

    void Undo()
    {
        if (commandStack.Count > 0)
        {
            ICommand lastCommand = commandStack.Pop();
            lastCommand.undo();
            historyStack.Push(lastCommand);
        }
    }
}
