using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystemScript : MonoBehaviour
{
    public bool isPlaying = false;

    ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (particleSystem.isPlaying)
        {
            isPlaying = true;
        }
        if (isPlaying)
        {
            if (!particleSystem.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
