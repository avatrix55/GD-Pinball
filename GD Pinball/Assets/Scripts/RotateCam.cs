using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    public Vector3 prev;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;


    // Update is called once per frame
    void Update()
    {
        //using left button of the mouse
        if (Input.GetMouseButtonDown(0))
        {
            prev = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 dir = prev - cam.ScreenToViewportPoint(Input.mousePosition);

            cam.transform.position = target.position;// new Vector3();
            cam.transform.Rotate(new Vector3(1, 0, 0), dir.y * 180);
            //cam.transform.Rotate(new Vector3(0, 1, 0), -dir.x * 180, Space.World);
            cam.transform.Rotate(new Vector3(0, 0, 1));

            prev = cam.ScreenToViewportPoint(Input.mousePosition);

        }
    }

}
