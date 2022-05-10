using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.G2OM;

public class disable_on_gaze : MonoBehaviour, IGazeFocusable
{
    public bool lookedAtOnce = false;
    public GameObject monster;

    //The method of the "IGazeFocusable" interface, which will be called when this object receives or loses focus
    public void GazeFocusChanged(bool hasFocus)
    {
        //If this object received focus, fade the object's color to highlight color
        if (hasFocus)
        {
            lookedAtOnce = true;
        }
        //If this object lost focus, fade the object's color to it's original color
        else
        {
            if (lookedAtOnce)
            {
                StartCoroutine(ExecuteAfterTime(1));
            }
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        lookedAtOnce = false;
        GetComponent<AudioSource>().Play();
        monster.SetActive(false);
    }
}
