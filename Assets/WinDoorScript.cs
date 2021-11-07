using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDoorScript : MonoBehaviour
{
    public ButtonHitScript buttonSwitch;

    bool isWon = false;

    // Update is called once per frame
    void Update()
    {
        if (buttonSwitch.isSwitchedOn)
        {
            isWon = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isWon)
        {
            // play win animation

            // display any needed ui

            // send to the next level

            print("Won");
        }
    }
}
