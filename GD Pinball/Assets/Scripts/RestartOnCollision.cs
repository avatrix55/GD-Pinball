using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnCollision : MonoBehaviour
{
    [SerializeField]
    string bump;

    public AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == bump)
        {
            sound.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }            
    }
}
