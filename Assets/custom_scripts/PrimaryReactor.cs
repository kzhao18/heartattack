using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class PrimaryReactor : MonoBehaviour
{
    public PrimaryButtonWatcher watcher;
    public bool IsPressed = false; // used to display button state in the Unity Inspector window
    private Vector3 scaleChange;
    private List<GameObject> collisions = new List<GameObject>();
    private bool visible = true;

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
            foreach (GameObject objt in collisions)
            {
                objt.transform.localScale += scaleChange;
            }

        }


    }

    public void OnCollisionEnter(Collision col)
    {

        collisions.Add(col.gameObject);

    }

    public void OnCollisionExit(Collision col)
    {

        collisions.Remove(col.gameObject);


    }

}
