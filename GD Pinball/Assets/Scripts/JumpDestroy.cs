using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDestroy : MonoBehaviour
{
    public ParticleSystem deathPart;
    public AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sound.Play();
            Destroy(transform.parent.gameObject);
            Instantiate(deathPart, transform.position, Quaternion.identity);
            
        }
    }
}
