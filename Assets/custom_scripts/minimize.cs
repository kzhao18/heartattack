using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class minimize : MonoBehaviour
{
    public GameObject inventory;
    public XRSocketInteractor socket;
    // Start is called before the first frame update
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer m = inventory.GetComponent<MeshRenderer>();
        var obj = socket.selectTarget.gameObject;
        Debug.Log("mesh" + m.enabled);
        Debug.Log("object" + obj.name);
        if (m.enabled == true && obj != null)
        {
            MeshRenderer o = obj.GetComponent<MeshRenderer>();
            Debug.Log("obj mesh" + o.enabled);
            o.enabled = true;
        }
        if (m.enabled == false && obj != null)
        {
            MeshRenderer o = obj.GetComponent<MeshRenderer>();
            Debug.Log("obj mesh" + o.enabled);
            o.enabled = false;
        }

    }

}
