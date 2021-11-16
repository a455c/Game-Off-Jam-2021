using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject enemyPrefab;

    public ParticleSystem spawnSystem;

    public BugMovement bugMovement;

    float lastDelay;
    public float spawnDelay;

    // Update is called once per frame
    void Update()
    {
        if (!bugMovement.isDead)
        {
            if (Time.timeSinceLevelLoad >= lastDelay + spawnDelay)
            {
                Spawn();
                lastDelay = Time.timeSinceLevelLoad;
            }
            if (spawnDelay <= 0.2)
            {
                spawnDelay = 0.75f;
            }
        }
    }

    void Spawn()
    {
        int random = Random.Range(0, 7);

        Transform spawnT = transform.GetChild(0);

        switch (random)
        {
            case 1:
                spawnT = transform.GetChild(0);
                break;
            case 2:
                spawnT = transform.GetChild(1);
                break;
            case 3:
                spawnT = transform.GetChild(2);
                break;
            case 4:
                spawnT = transform.GetChild(3);
                break;
            case 5:
                spawnT = transform.GetChild(4);
                break;
            case 6:
                spawnT = transform.GetChild(5);
                break;

        }
        GameObject clone = Instantiate(enemyPrefab, spawnT.position, Quaternion.identity);
        clone.SetActive(true);
        ParticleSystem clone1 = Instantiate(spawnSystem, clone.transform.position, Quaternion.identity);
        clone1.Play();
        StartCoroutine(SpawnQuicker());
    }

    IEnumerator SpawnQuicker()
    {
        yield return new WaitForSeconds(5);
        spawnDelay -= 0.05f;
    }
}
