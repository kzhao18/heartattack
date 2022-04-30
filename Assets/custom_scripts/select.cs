using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select : MonoBehaviour
{
    public Material selected;
    public Material unselected;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        transform.GetComponent<Renderer>().material = selected;
    }

    void OnTriggerExit(Collider col)
    {
        transform.GetComponent<Renderer>().material = unselected;
    }
}