using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] string player;
    [SerializeField] float force;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == player)
        {
            Rigidbody rigid = collision.rigidbody;
            rigid.AddExplosionForce(force, collision.contacts[0].point,100);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
