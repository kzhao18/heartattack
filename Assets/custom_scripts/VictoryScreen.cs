using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VictoryScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject victory;
    public ActionBasedContinuousMoveProvider mp;
    public ActionBasedContinuousTurnProvider tp;
    public PlayerScript ps;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        // open victory screen
        if (col.gameObject.tag == "Player")
        {
            transform.Rotate(0.0f, 0.0f, 90.0f);

            // set victory to true
            victory.SetActive(true);

            // disable movement and turn
            mp.enabled = false;
            tp.enabled = false;
            // ps.cam.transform.position = ps.StartLocation;
        }
    }
}
