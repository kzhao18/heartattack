using UnityEngine;
using UnityEngine.AI;
    
public class Move : MonoBehaviour {
       
    public Transform goal;
       
    void Start () {
          NavMeshAgent agent = GetComponent<NavMeshAgent>();
          agent.GetComponent<Animation>().enabled = false;
    }

    void Update () {

    }

}
