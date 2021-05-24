using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterEffect : MonoBehaviour
{
    public float time;
    public bool checkShake;
    [Range(0f, 1f)] public float duration;
    [Range(0f, 1f)] public float magnitude;
    // Start is called before the first frame update
    void Start()
    {
        if (checkShake)
        {
            StartCoroutine(FindObjectOfType<CamShake>().Shake(duration, magnitude));
        }
        Destroy(gameObject, time);
    }

}
