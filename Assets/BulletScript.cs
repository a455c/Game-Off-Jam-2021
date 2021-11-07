using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float shootSpeed;

    public ParticleSystem bulletHitSystem;

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position += transform.up * shootSpeed * Time.deltaTime;    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ParticleSystem clone = Instantiate(bulletHitSystem, transform.position, Quaternion.identity);
        clone.Play();
        Destroy(gameObject);
    }
}
