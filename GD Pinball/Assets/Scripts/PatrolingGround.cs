using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolingGround : MonoBehaviour
{
    public Transform[] walkPoint;
    public float speed;

    private int wpIdx;
    private float dist;

    private void Start()
    {
        wpIdx = 0;
        transform.LookAt(walkPoint[wpIdx].position);
    }

    private void Update()
    {
        dist = Vector3.Distance(transform.position, walkPoint[wpIdx].position);
        if (dist < 1f)
        {
            IncreaseIndex();
        }
        Patrol();
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        wpIdx++;
        if(wpIdx>= walkPoint.Length)
        {
            wpIdx = 0;
        }
        transform.LookAt(walkPoint[wpIdx].position);
    }
}
