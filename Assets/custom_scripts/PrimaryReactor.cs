using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class PrimaryReactor : MonoBehaviour
{
    public PrimaryButtonWatcher watcher;
    public bool IsPressed = false; // used to display button state in the Unity Inspector window
    private Vector3 scaleChange;
    private bool visible = true;

    void Start()
    {
        watcher.primaryButtonPress.AddListener(onPrimaryButtonEvent);
        scaleChange = new Vector3(1.5f, 1.125f, 0.075f);
    }

    public void onPrimaryButtonEvent(bool pressed)
    {
        IsPressed = pressed;
        if (pressed)
        {
            scaleChange = -scaleChange;
            transform.localScale += scaleChange;
            MeshRenderer m = gameObject.GetComponent<MeshRenderer>();
            if (visible)
            {
                m.enabled = false;
            }
            if (!visible)
            {
                m.enabled = true;
            }  
            visible = !visible;


        }


    }


}
