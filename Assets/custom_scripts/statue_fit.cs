using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statue_fit : MonoBehaviour
{
    // Start is called before the first frame update
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

        if (x < 0.5 && x > -0.5
            && y < 2.5 && y > 1.5
            && z > -17.6 && z < -16.6
            )
        {
           
            if (play)
            {
                audio.Play();
                play = false;
            }


        }
    }
}
