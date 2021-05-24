using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] string player;
    [SerializeField] float force;
    [SerializeField] float range;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == player)
        {
            Rigidbody rigid = collision.rigidbody;
            rigid.AddExplosionForce(force, collision.contacts[0].point,range);
        }
    }
}
