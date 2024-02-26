using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Angles : MonoBehaviour
{

    [Range(0f, 360f)]
    [SerializeField] float angle;
    public GameObject point;
    public float spaceBetweenPoints;
    public int numberOfPoints;
    public float launchForce;
    [SerializeField] private Transform shotPos;
    [SerializeField] private Transform trajectoryHolder;
    private GameObject[] points;
    private Vector2 direction;
    private Rigidbody2D rb;
   
    private void Awake()
    {
        rb = gameObject.GetComponentInParent<Rigidbody2D>();
    }

    private void Start()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPos.position, Quaternion.identity, trajectoryHolder);
            points[i].gameObject.SetActive(false);
        }
            DesactivateRb();
    }

    private void Update()
    {
        Vector2 v = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = v - mousePos;
        transform.right = direction;

        if (Input.GetKey(KeyCode.Mouse1))
        {
            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i].gameObject.SetActive(true);
                points[i].transform.position = dir(i * spaceBetweenPoints);
            }

        }
        if (Input.GetMouseButtonUp(1))
        {
            foreach (var item in points)
            {
                item.gameObject.SetActive(false);
               
            }
            ActivateRb();
            Push(direction*launchForce);
        }

    }
    private Vector2 dir(float t)
    {
        Vector2 position = (Vector2)shotPos.position + (direction.normalized * t * launchForce) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }

    private void OnDrawGizmos()
    {
        Vector2 v = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        Debug.Log(v * 5);
    }
    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }
    public void ActivateRb()
    {
        rb.isKinematic = false;
    }

    public void DesactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }
}

