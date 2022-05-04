using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject cam;
    public Canvas start;
    private float speed;
    public Canvas death;
    public Canvas map;
    Vector3 StartLocation;
    char prevRoom;
    bool leftRoom; 
    
    // Start is called before the first frame update
    void Start()
    {
        start.enabled =true;
        map.enabled =false;
        death.enabled=false;
        StartLocation = new Vector3(11,2,-40);
        leftRoom=false;
        prevRoom= '0';
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (hitData.collider!=null){
            //String playerLocation = hitData.collider.gameObject.name;

            // if players location is equal to location of monster, make enemy chase player
            if (hitData.collider.gameObject.name.Contains("monsterfloor")==true){
                // check if enemy has caught player
                if (distance<2){

                    // reset enemy to original state in room
                    agent.GetComponent<Animator>().enabled = false;
                    agent.speed = 0;
                    agent.transform.position = new Vector3(40, 0, -42);

                    // move player back to start
                    cam.transform.position = new Vector3(11, 1, -42);

                    // show player died screen
                    death.enabled=true;
                    
                }
                // if the player is in the room the monster is in, make monster chase player
                else {
                    agent.GetComponent<Animator>().enabled = true;
                    agent.speed = 4;
                    agent.destination = transform.position;
                }
            }
            // if player is not in the room the monster is in, monster doesn't move
            else if (hitData.collider.gameObject.name!="floor"){
                agent.GetComponent<Animator>().enabled = false;
                agent.speed = 0;
            }
            
            // disable the plane of the room youre currently in
            if (hitData.collider.gameObject.name.Contains("hallfloor")==true){
                Debug.Log(hitData.collider.gameObject.name);
                char roomNumber = hitData.collider.gameObject.name[hitData.collider.gameObject.name.Length-1];
                // if (prevRoom!='0' && roomNumber!=prevRoom){
                //     string enablePrevPlane = "Plane"+prevRoom;
                //     Debug.Log("prev room:" + enablePrevPlane);
                //     if (GameObject.FindGameObjectWithTag(enablePrevPlane)!=null){
                //         GameObject.FindGameObjectWithTag(enablePrevPlane).SetActive(true);
                //     }
                    
                // }
                // prevRoom = roomNumber;
                string planeToRemove = "HallPlane"+roomNumber;
                if (GameObject.Find(planeToRemove)!=null){
                        GameObject.Find(planeToRemove).SetActive(false);
                }

                // enable plane of all other rooms

            }
            else if (hitData.collider.gameObject.name.Contains("floor")==true){
                Debug.Log(hitData.collider.gameObject.name);
                char roomNumber = hitData.collider.gameObject.name[hitData.collider.gameObject.name.Length-1];
                string planeToRemove = "Plane"+roomNumber;
                if (GameObject.Find(planeToRemove)!=null){
                        GameObject.Find(planeToRemove).SetActive(false);
                }

            }
            

            
        
        }   
    }

    public void StartGame(){
        map.enabled=true;
        death.enabled=false;
        start.enabled=false;
    }
    
    public void Close(){
        map.enabled=false;
        start.enabled=true;
        death.enabled=false;
        cam.transform.position = StartLocation;
    }
}
