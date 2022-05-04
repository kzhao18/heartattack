using System.Collections;
using UnityEngine;

public class PrimaryReactor : MonoBehaviour
{
    public PrimaryButtonWatcher watcher;
    public bool IsPressed = false; // used to display button state in the Unity Inspector window
    private Vector3 scaleChange;

    void Start()
    {
        watcher.primaryButtonPress.AddListener(onPrimaryButtonEvent);
        scaleChange = new Vector3(-1.5f, -1.125f, -0.075f);
    }

    public void onPrimaryButtonEvent(bool pressed)
    {
        IsPressed = pressed;
        if (pressed)
        {
            scaleChange = -scaleChange;
            transform.localScale += scaleChange;

        }


    }

}
