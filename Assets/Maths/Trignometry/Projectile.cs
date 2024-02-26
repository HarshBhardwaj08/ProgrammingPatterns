using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float angle;
    [SerializeField] private float intialVelocity;
    private Vector3 instialPos;

    private void Start()
    {
        instialPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float angles = angle * Mathf.Deg2Rad;
            StopAllCoroutines();
            StartCoroutine(ProjectilePath(intialVelocity,angles));
        }
    }
    IEnumerator ProjectilePath(float v0, float angle)
    {
        float t = 0;
        while (t < 100)
        {   
            float x = v0 * t * Mathf.Cos(angle);
            float y = v0 * t * Mathf.Sin(angle) - (1.0f / 2.0f) * -Physics2D.gravity.y * Mathf.Pow(t, 2);
            transform.position = instialPos + new Vector3(x, y, 0);
            Debug.Log(x + ", " + y);
            t += Time.deltaTime;
            yield return null;
        }
    }
}
