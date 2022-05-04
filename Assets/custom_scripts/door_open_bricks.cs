using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_open_bricks : MonoBehaviour
{

    private bool brick1 = false;
    private bool brick2 = false;
    private bool brick3 = false;
    private bool brick4 = false;
    public GameObject obj;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (obj.transform.position.x == 14.379
            && obj.transform.position.y == 1.795
            && obj.transform.position.z == -36.24158)
        {
            brick1 = true;
        }



        if (obj1.transform.position.x == 14.379
                    && obj1.transform.position.y == 1.777
                    && obj1.transform.position.z == -35.72192
        )
        {
            brick2 = true;
        }


        if (obj2.transform.position.x == 14.379
                    && obj2.transform.position.y == 2.108
                    && obj2.transform.position.z == -36.02717
        )
        {
            brick3 = true;
        }




        if (obj3.transform.position.x == 14.379
                    && obj3.transform.position.y == 1.507
                    && obj3.transform.position.z == -35.9768
        )
        {
            brick4 = true;
        }


        if (brick1)
        {
            transform.Rotate(0.0f, 0.0f, 90.0f);
        }






    }
}
