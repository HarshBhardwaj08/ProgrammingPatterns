using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public interface Iinputs
{
    void HandleInput();

}

public class PCINputs : Iinputs
{
    private Rigidbody2D rigidbody2D;

   public PCINputs(Rigidbody2D rigidbody2D)
    {
        this.rigidbody2D = rigidbody2D;
    }
    public void HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        MovePlayer(horizontalInput,VerticalInput);
        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }
        void jump()
        {
            rigidbody2D.velocity = new Vector2(0, 5);
            
        }
    }

    private void MovePlayer(float horizontalInput, float y)
    {
       
      rigidbody2D .velocity = new Vector2(horizontalInput * 5f,y*5);
    }
}
public class MObileInputs : Iinputs
{
    private Rigidbody2D rigidbody2D;

  public   MObileInputs (Rigidbody2D rigidbody2D)
    {
        this.rigidbody2D = rigidbody2D;
    }

  public void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width / 2)
            {
                Move(Vector2.right);
            }
            else
            {
                Move(Vector2.left);
            }
        }else 
        {
            Move(Vector2.zero);
        }
    }

    void Move(Vector2 direction)
    {
      
        direction.Normalize();

       
        rigidbody2D.velocity = new Vector2(direction.x * 5, rigidbody2D.velocity.y);
    }
}
public class Consoles : Iinputs
{
    private Rigidbody2D rigidbody2D;
   
    public Consoles (Rigidbody2D rigidbody2D)
    {
         this.rigidbody2D=rigidbody2D;
    }
    public void HandleInput()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
         Move(horizontalInput, VerticalInput);
      
        if(Input.GetButtonDown("JumpButton") )
        {
            rigidbody2D.velocity = Vector3.up * 5;
        }
      
    }
   
    void Move(float x,float y)
    {
        rigidbody2D.velocity = new Vector2 (x,y);
    }
    void jump ()
    {
        rigidbody2D.velocity = new Vector2(0,5);
        Debug.Log("Jump button pressed");
    }
}