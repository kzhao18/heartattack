using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_open_bricks : MonoBehaviour
{

    private bool brick1 = false;
    private bool brick2 = false;
    private bool brick3 = false;
    private bool brick4 = false;
    private bool closed = true;
    public GameObject obj;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x1 = obj.transform.position.x;
        float y1 = obj.transform.position.y;
        float z1 = obj.transform.position.z;

        if (x1 < 14.52 && x1 > 14.22
            && y1 < 1.85 && y1 > 1.74
            && z1 > -36.29 && z1 < -36.19)
        {
            brick1 = true;
        }


        float x2 = obj1.transform.position.x;
        float y2 = obj1.transform.position.y;
        float z2 = obj1.transform.position.z;


        if (x2 < 14.52 && x2 > 14.22
            && y2 < 1.87 && y2 > 1.67
            && z2 > -35.82 && z2 < -35.62)
        {
            brick2 = true;
        }

        float x3 = obj2.transform.position.x;
        float y3 = obj2.transform.position.y;
        float z3 = obj2.transform.position.z;
        if (x3 < 14.52 && x3 > 14.22
            && y3 < 2.208 && y3 > 2.008
            && z3 > -36.12 && z3 < -35.92
        )
        {
            brick3 = true;
        }



        float x4 = obj3.transform.position.x;
        float y4 = obj3.transform.position.y;
        float z4 = obj3.transform.position.z;
        if (x4 < 14.52 && x4 > 14.22
            && y4 < 1.607 && y4 > 1.407
            && z4 > -36.07 && z4 < -35.87
        )
        {
            brick4 = true;
        }


        if (brick1 && brick2 && brick3 && brick4 && closed)
        {
            transform.Rotate(0.0f, 0.0f, 90.0f);
            audioSource.Play();
            closed = false;
        }



    }
}
