using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public BugMovement player;

    private void Start()
    {
        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.currentHealth == 4)
        {
            transform.GetChild(4).gameObject.SetActive(false);
        }
        else if (player.currentHealth == 3)
        {
            transform.GetChild(3).gameObject.SetActive(false);
        }
        else if (player.currentHealth == 2)
        {
            transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (player.currentHealth == 1)
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (player.currentHealth == 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
