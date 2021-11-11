using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform playerT;
    public Transform gunTip;

    public ParticleSystem muzzleShoot;


    public GameObject enemyBulletPrefab;

    public float moveSpeed;

    public float shootDelay;
    private float lastDelay;

    private void Start()
    {
        transform.up = playerT.position - transform.position;
        lastDelay = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.timeSinceLevelLoad >= lastDelay + shootDelay)
        {
            Shoot();
            lastDelay = Time.timeSinceLevelLoad;
        }
        transform.up = playerT.position - transform.position;

        transform.position = Vector3.MoveTowards(transform.position, playerT.position, moveSpeed * Time.deltaTime);
    }

    public void Kill()
    {
        // instantiate and play a particle effect
        // play animation
        Destroy(gameObject);
    }

    private void Shoot()
    {
        // spawn bulletprefab
        //play sound effect
        GameObject clone = Instantiate(enemyBulletPrefab, gunTip.position, gunTip.rotation);
        clone.SetActive(true);
        /*ParticleSystem clone1 = Instantiate(muzzleShoot, gunTip.position, gunTip.rotation);
        clone1.Play();*/
        muzzleShoot.Play();
    }
}
