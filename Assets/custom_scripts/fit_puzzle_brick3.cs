using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fit_puzzle_brick3 : MonoBehaviour
{
    public Material unselected;
    public AudioSource audio;
    private bool play = true;
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
        // Debug.Log("x: " + x);
        // Debug.Log("y: " + y);
        // Debug.Log("z: " + z);

        if (x < 14.52 && x > 14.22
            && y < 2.208 && y > 2.008
            && z > -36.12 && z < -35.92
            )
        {
           // transform.GetComponent<Renderer>().material = unselected;
            x = 14.379f;
            y = 2.108f;
            z = -36.02717f;
            transform.position = new Vector3(x, y, z);
            if (play)
            {
                audio.Play();
                play = false;
            }

        }
    }
}
