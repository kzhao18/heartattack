using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fit_puzzle : MonoBehaviour
{
    public Material unselected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        Debug.Log("x: " + x);
        Debug.Log("y: " + y);
        Debug.Log("z: " + z);

        if (x < 14.52 && x > 14.22
            && y < 1.85 && y > 1.74
            && z > -36.29 && z < -36.19
            ) {
            transform.GetComponent<Renderer>().material = unselected;
            x = 14.379f;
            y = 1.795f;
            z = -36.24158f;
            transform.position = new Vector3(x, y, z);

        }
    }
}
