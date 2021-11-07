using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHitScript : MonoBehaviour
{
    public bool isSwitchedOn = false;

    // Update is called once per frame
    void Update()
    {
        if (isSwitchedOn)
        {
            // play switched on animation
        }
        else
        {
           // play switched off animation
        }
    }

    public void SwitchOn()
    {
        isSwitchedOn = true;
    }
}
