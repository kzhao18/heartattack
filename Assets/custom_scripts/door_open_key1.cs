using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_open_key1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Key1")
        {
            transform.Rotate(0.0f, 0.0f, 90.0f);
        }

    }
}
