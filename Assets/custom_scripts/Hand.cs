using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Hand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        XRRayInteractor r = gameObject.AddComponent<XRRayInteractor>() as XRRayInteractor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
