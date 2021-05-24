using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] string bump;
    [SerializeField] float speed = 1.0f;
    //public ParticleSystem deathPart;
    Renderer myObj;
    public Material[] material;
    float startTime=1.0f;
    public AudioClip sound;

    private void Start()
    {
        myObj = GetComponent<Renderer>();
        myObj.enabled = true;
        myObj.sharedMaterial = material[0];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == bump)
        {
            AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
            myObj.sharedMaterial = material[1];
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        float t = (Time.time - startTime) * speed;
        Color a = material[1].color;
        Color b = material[0].color;
        myObj.material.color = Color.Lerp(a, b, 2.0f);
    }
}
