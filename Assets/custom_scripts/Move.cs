using UnityEngine;
using UnityEngine.AI;
    
public class Move : MonoBehaviour {
       
    public Transform goal;
       
    void Start () {
          NavMeshAgent agent = GetComponent<NavMeshAgent>();
          agent.GetComponent<Animator>().enabled = false; 
    }

    void Update () {

    }

}
