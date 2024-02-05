
using UnityEngine;


public class Gems : MonoBehaviour
{   
    public static Gems Instance;

    public int scorePoints;

    private void Awake()
    {  
        if(Instance == null)
        {
            Instance = this;
        }else
        {
            Destroy(this);
        }
      
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject .tag == "Player")
        {
            scorePoints++;

        }
    }
}
