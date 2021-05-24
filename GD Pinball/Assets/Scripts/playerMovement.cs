using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private bool isGrounded;
    private Vector3 jump;
    private Rigidbody myRigidbody;
    private bool canMove = true;
    private float jumpTimer;
    private bool timerStarted;

    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpHeight = 8f;
    [SerializeField] private float jumpOffset = 3f;
    [SerializeField] private int emergenzLvl = 1;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private ParticleSystem particles;
    
    

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 100.0f, 0.0f);
        jumpTimer = jumpOffset;
        timerStarted = false;
        isGrounded = true;
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    void OnCollisionStay()
    {
        if (jumpTimer != jumpOffset)
        {
            isGrounded = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canMove)
            return;

        if (timerStarted)
        {
            jumpTimer -= Time.deltaTime;
        }
        if (jumpTimer <= 0)
        {
            timerStarted = false;
        }

        Vector3 impulse = new Vector3(0, 0, 0);

        if(Input.GetKey(KeyCode.W))
        {
            impulse.x += -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            impulse.x += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            impulse.z += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            impulse.z += 1;
        }

        impulse.Normalize();
        impulse *= speed * Time.deltaTime;

        if (isGrounded && !timerStarted && Input.GetKey(KeyCode.Space))
        {
            timerStarted = true;
            jumpTimer = jumpOffset;
            myRigidbody.AddForce(jump * jumpHeight);
            isGrounded = false;
            
            if (emergenzLvl >= 2)
            {
                AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position);
            }
            if (emergenzLvl >= 3)
            {
                particles.Play();
            }
        }

        if (emergenzLvl >= 3 && impulse.magnitude > 0)
        {
            
        }

        transform.Translate(impulse, Space.World);
    }
}
