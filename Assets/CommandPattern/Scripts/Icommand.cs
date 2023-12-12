using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand 
{
    void Execute();
    void undo();
}
public class jumpCommand : ICommand
{   
    Player player;
    float y;

    public jumpCommand(Player player , float y)
    {
        this.player = player;
        this.y = y;
    }

    public void Execute()
    {
        player.Jump(y);
    }

    public void undo()
    {
        player.undoJump(y);
    }
}

public class MoveCommand : ICommand
{  
    Player player;
    float x;
    float y;

    public MoveCommand(Player player, float x, float y)
    {
        this.player = player;
        this.x = x;
        this.y = y;
    }

    public void Execute()
    {
        player.move(x, y);
    }

    public void undo()
    {
        player.UndoMove(x, y);
    }
}

public class ShootCommand : ICommand
{  
    Player player;

    public ShootCommand(Player player)
    {
        this.player = player;
        
    }

    public void Execute()
    {
        player.shoot();
    }

    public void undo()
    {
        player.undoShoot();
    }
}
