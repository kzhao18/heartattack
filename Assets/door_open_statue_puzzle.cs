using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_open_statue_puzzle : MonoBehaviour
{
    private bool stat1 = false;
    private bool stat2 = false;
    private bool stat3 = false;
    private bool stat4 = false;
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

        if (x1 < 0.5 && x1 > -0.5
            && y1 < 2.5 && y1 > 1.5
            && z1 > -22.9 && z1 < -21.7)
        {
            stat1 = true;
        }


        float x2 = obj1.transform.position.x;
        float y2 = obj1.transform.position.y;
        float z2 = obj1.transform.position.z;


        if (x2 < 0.5 && x2 > -0.5
            && y2 < 2.5 && y2 > 1.5
            && z2 > -21.0 && z2 < -20.0)
        {
            stat2 = true;
        }

        float x3 = obj2.transform.position.x;
        float y3 = obj2.transform.position.y;
        float z3 = obj2.transform.position.z;

        if (x3 < 0.5 && x3 > -0.5
            && y3 < 2.5 && y3 > 1.5
            && z3 > -19.3 && z3 < -18.2
        )
        {
            stat3 = true;
        }



        float x4 = obj3.transform.position.x;
        float y4 = obj3.transform.position.y;
        float z4 = obj3.transform.position.z;
        if (x4 < 0.5 && x4 > -0.5
            && y4 < 2.5 && y4 > 1.5
            && z4 > -17.6 && z4 < -16.6
        )
        {
            stat4 = true;
        }


        if (stat1 && stat2 && stat3 && stat4 && closed)
        {
            transform.Rotate(0.0f, 0.0f, 90.0f);
            audioSource.Play();
            closed = false;
        }



    }
}
