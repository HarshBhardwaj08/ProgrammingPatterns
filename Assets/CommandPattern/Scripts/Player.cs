using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{  
   public void Jump(float y)
    {
        transform.position += new Vector3(0, y,0);
    }
    public void undoJump(float y)
    {
        this.transform.position -= new Vector3(0, y,0);
    }
    public void move(float x , float speed)
    {
        transform.Translate(x*speed*Time.deltaTime ,0 , 0);
    }
    public void UndoMove(float  x , float speed)
    {
        transform.Translate(-x * speed * Time.deltaTime, 0, 0);
    }
    public void shoot()
    {
        Debug.Log("Pew Pew ");
    }
    public void undoShoot()
    {
        Debug.Log("Surrendered");
    }
}
