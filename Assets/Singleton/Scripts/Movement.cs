using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
     Rigidbody2D rb2d;
    public int scoreCheck;
    public Text text;
    //bool HasScaled;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
   
    private void FixedUpdate()
    {
        float XInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        rb2d.velocity = new Vector2(XInput, yInput) * speed*Time.deltaTime;
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        scoreCheck = Gems.Instance.scorePoints;
        if (scoreCheck >= 3)
        {
            scoreCheck = 0;
            transform.localScale += new Vector3(1, 1, 1);

           
           
        }
        text.text = "Score : " + Gems.Instance.scorePoints.ToString();
    }
}
