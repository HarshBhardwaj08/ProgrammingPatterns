using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFactory 
{
  public  PCINputs pcINputs;
  public  MObileInputs MObileInputs;
    public Consoles consoles;
    
   public InputFactory(string name,Rigidbody2D rigidbody2D) 
    {
      switch (name)
        {

            case ("PcInputs"):
                pcINputs = new PCINputs(rigidbody2D);
                break;
            case ("MobileInputs"):
                MObileInputs = new MObileInputs(rigidbody2D);
                break;
            case ("Consoles"):
                consoles = new Consoles(rigidbody2D);
                break;

        }
    
    }
 
}
