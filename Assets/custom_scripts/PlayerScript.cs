using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using Sigtrap.VrTunnellingPro;

public class PlayerScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject cam;
    public GameObject start;
    public GameObject death;
    public GameObject map;
    public GameObject victory;
    public GameObject calibration;
    public ActionBasedContinuousMoveProvider mp;
    public ActionBasedContinuousTurnProvider tp;

    public float speed;

    public HeartbeatMonitor hbm;
    public GameObject continuedFloor;

    public GameObject rightHand;
    public Vector3 StartLocation;

    public StopMonsterGaze smg;
    private bool alive;

    public AudioSource monsterAudio;
    public GameObject enemy;
    private bool played;

    char prevRoom;
    bool leftRoom;

    public Tunnelling t;
    
    // Start is called before the first frame update
    void Start()
    {
        //start.enabled =true;
        //map.enabled =false;
        //death.enabled=false;
        //StartLocation = new Vector3(11,2,-40);
        //leftRoom=false;
        //prevRoom= '0';

        StartLocation = cam.transform.position;
        leftRoom = false;
        prevRoom = '0';
        alive = true;

        t.effectFeather = 0.16f;

        //new
        monsterAudio = enemy.GetComponent<AudioSource>();
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hbm.calibrated && alive)
        {
            // set calibrated screen to false
            calibration.SetActive(false);
            map.SetActive(true);
            mp.enabled = true;
            tp.enabled = true;

            // position player is hitting
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitData;
            Physics.Raycast(ray, out hitData);
            Vector3 hitPosition = hitData.point;

            // position enemy is hitting
            Ray rayEnemy = new Ray(agent.transform.position, agent.transform.forward);
            RaycastHit hitDataE;
            Physics.Raycast(rayEnemy, out hitDataE);
            Vector3 hitPositionEnemy = hitDataE.point;

            // distance between player and enemy
            float distance = (ray.origin-rayEnemy.origin).magnitude;

            // rotate enemy towards player
            agent.transform.LookAt(cam.transform);

            // if player is hitting something
            if (hitData.collider != null)
            {
                //String playerLocation = hitData.collider.gameObject.name;

                // if players location is equal to location of monster, make enemy chase player
                if (hitData.collider.gameObject.name.Contains("monsterfloor") == true && !smg.gazeOn)
                {
                    //new
                    if (!played)
                    {
                        monsterAudio.Play();
                        played = true;
                    }

                    // check if enemy has caught player
                    if (distance < 2)
                    {

                        // reset enemy to original state in room
                        agent.GetComponent<Animation>().enabled = false;
                        agent.speed = 0;
                        agent.transform.position = new Vector3(40, 0, -42);

                        // move player back to start
                        cam.transform.position = StartLocation;

                        // show player died screen
                        death.SetActive(true);
                        map.SetActive(false);

                        // disable movement
                        mp.enabled = false;
                        tp.enabled = false;
                        alive = false;

                    }
                    // if the player is in the room the monster is in, make monster chase player
                    else
                    {
                        agent.GetComponent<Animation>().enabled = true;
                        agent.speed = 4 * (Mathf.Abs(hbm.percentDifference));
                        if (agent.speed < 2.5)
                        {
                            agent.speed = 2.5f;
                        }
                        Debug.Log("Agent speed is: " + agent.speed);
                        agent.destination = transform.position;
                    }
                }
                // if player is not in the room the monster is in, monster doesn't move
                else if (hitData.collider.gameObject.tag != "monsterfloor" || smg.gazeOn)
                {
                    if (hbm.heartRateDifference > 5 || hbm.heartRateDifference < -5)
                    {
                        continuedFloor.gameObject.tag = "monsterfloor";
                    }
                    //if (smg.gazeOn)
                    //{
                    //    Debug.Log("gaze is on");
                    //}
                    agent.GetComponent<Animation>().enabled = false;
                    agent.speed = 0;
                }

                // disable the plane of the room youre currently in
                if (hitData.collider.gameObject.name.Contains("hallfloor") == true)
                {
                    //Debug.Log(hitData.collider.gameObject.name);
                    char roomNumber = hitData.collider.gameObject.name[hitData.collider.gameObject.name.Length - 1];
                    // if (prevRoom!='0' && roomNumber!=prevRoom){
                    //     string enablePrevPlane = "Plane"+prevRoom;
                    //     Debug.Log("prev room:" + enablePrevPlane);
                    //     if (GameObject.FindGameObjectWithTag(enablePrevPlane)!=null){
                    //         GameObject.FindGameObjectWithTag(enablePrevPlane).SetActive(true);
                    //     }

                    // }
                    // prevRoom = roomNumber;
                    string planeToRemove = "HallPlane" + roomNumber;
                    if (GameObject.Find(planeToRemove) != null)
                    {
                        GameObject.Find(planeToRemove).SetActive(false);
                    }

                    // enable plane of all other rooms

                }
                else if (hitData.collider.gameObject.name.Contains("floor") == true)
                {
                    // Debug.Log(hitData.collider.gameObject.name);
                    char roomNumber = hitData.collider.gameObject.name[hitData.collider.gameObject.name.Length - 1];
                    string planeToRemove = "Plane" + roomNumber;
                    if (GameObject.Find(planeToRemove) != null)
                    {
                        GameObject.Find(planeToRemove).SetActive(false);
                    }

                }


            }
        
        }   
    }

    public void StartGame(){
        map.SetActive(true);
        death.SetActive(false);
        start.SetActive(false);

        mp.enabled = false;
        tp.enabled = false;
    }
    
    public void Close(){
        death.SetActive(false);
        start.SetActive(true);
        cam.transform.position = StartLocation;
    }
}
