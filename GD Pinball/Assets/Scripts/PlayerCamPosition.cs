using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamPosition : MonoBehaviour
{
    [SerializeField]
    Transform pposition;
    



    // Update is called once per frame
    void Update()
    {
        transform.position = pposition.position;
    }


}
