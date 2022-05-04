using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.G2OM;

public class StopMonsterGaze : MonoBehaviour, IGazeFocusable
{
    public bool gazeOn;

    //The method of the "IGazeFocusable" interface, which will be called when this object receives or loses focus
    public void GazeFocusChanged(bool hasFocus)
    {
        //If this object received focus, fade the object's color to highlight color
        if (hasFocus)
        {
            gazeOn = true;
        }
        //If this object lost focus, fade the object's color to it's original color
        else
        {
            gazeOn = false;
        }
    }
}
