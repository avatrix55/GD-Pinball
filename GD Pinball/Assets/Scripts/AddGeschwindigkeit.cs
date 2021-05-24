using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGeschwindigkeit : MonoBehaviour
{
    [SerializeField]
    Vector3 player;

    [SerializeField]
    KeyCode positif;

    [SerializeField]
    KeyCode negatif;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(positif))
            GetComponent<Rigidbody>().velocity += player;
        if (Input.GetKey(negatif))
            GetComponent<Rigidbody>().velocity -= player;
    }

}
