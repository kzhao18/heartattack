using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform cam;
    Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        newPos = cam.position;
        newPos.y = transform.position.y;
        transform.position = newPos;
        // setting rotation of camera to players rotation
        //transform.rotation = Quaternion.Euler(90f, cam.eulerAngles.y, 0f);
    }
}
