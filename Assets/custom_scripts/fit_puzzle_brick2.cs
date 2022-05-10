using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fit_puzzle_brick2 : MonoBehaviour
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
            && y < 1.87 && y > 1.67
            && z > -35.82 && z < -35.62
            )
        {
           // transform.GetComponent<Renderer>().material = unselected;
            x = 14.379f;
            y = 1.777f;
            z = -35.72192f;
            transform.position = new Vector3(x, y, z);
            if (play)
            {
                audio.Play();
                play = false;
            }

        }
    }
}
