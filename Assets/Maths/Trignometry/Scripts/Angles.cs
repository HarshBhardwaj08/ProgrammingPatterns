using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angles : MonoBehaviour
{
    [Range(0f, 360f)]
    [SerializeField] float angle;
    private void OnDrawGizmos()
    {
        Vector2 v = new Vector2 ( Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad) );
        Debug.Log(v*5);
        Gizmos.DrawWireSphere(transform.position, 5.0f);
        Gizmos.DrawLine(default, v*5.0f);
    }
}

