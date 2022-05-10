using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sigtrap.VrTunnellingPro;

public class trigger_crawler : MonoBehaviour
{
    // Start is called before the first frame update
    public Tunnelling T;
    public GameObject monster;
    public float FOVIncrease;
    private bool triggeredOnce = false;
    public float timeWait;
    public bool playAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!triggeredOnce)
            {
                // play audio
                if (playAudio)
                {
                    GetComponent<AudioSource>().Play();
                }

                // spawn monster
                monster.SetActive(true);

                // increase heart rate FOV
                T.effectFeather = FOVIncrease;

                StartCoroutine(ExecuteAfterTime(timeWait));

                triggeredOnce = true;
            }
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        monster.SetActive(false);
    }
}
