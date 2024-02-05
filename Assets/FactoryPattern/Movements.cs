using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class Movements : MonoBehaviour
{
    KeyCode anycode;
    Iinputs iinputs;
    InputFactory factory;   
    Rigidbody2D rb;
  public float speed;
    private void Awake()
    {   
        rb = GetComponent<Rigidbody2D>();
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            factory = new InputFactory("PcInputs", rb);
              iinputs = factory.pcINputs;
        }
       else if (Application.platform == RuntimePlatform.Android)
        {
            factory = new InputFactory("MobileInputs",rb);
            iinputs = factory.MObileInputs;
        }
       else if (Application.platform == RuntimePlatform.GameCoreXboxSeries)
        {
            factory = new InputFactory("Consoles", rb);
            iinputs = factory.consoles;
        }
    }
    void Update()
    {
        iinputs.HandleInput();
    }
    
}
