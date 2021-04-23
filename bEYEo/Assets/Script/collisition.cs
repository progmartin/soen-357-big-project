using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisition : MonoBehaviour
{

    public GameObject cell;
    public GameObject nucleus;
    public AudioSource lightDive;
    public AudioSource bigDive;
    public AudioSource dive2;
    public AudioSource dive3;
    public AudioSource underwater;
    public AudioSource underwater2;
    private bool diveOnce = false;

    void OnCollisionEnter(Collision col)
    {
       

        if (col.gameObject.name == "nucleus" && diveOnce == false) {
            Debug.Log("nucleus defteced");
            lightDive.Play();
            diveOnce = true;
            nucleusScript.nucleusInsideCell = true;

        }

        if (col.gameObject.name == "playerHitBox")
        {

            playDive();
            playUnderwater();
            nucleusScript.playerInsideCell = true;

        }

    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "playerHitBox")
        {
            playDive();
            underwater.Stop();
            underwater2.Stop();


        }
    }

    void playDive() {

        if (!bigDive.isPlaying && !dive2.isPlaying && !dive3.isPlaying)
        {
            System.Random random = new System.Random();
            int num = random.Next(0, 3);
            List<AudioSource> list = new List<AudioSource>();
            list.Add(bigDive);
            list.Add(dive2);
            list.Add(dive3);      
            list[num].Play();

        }

    }
    void playUnderwater()
    {

        if (!underwater.isPlaying && !underwater2.isPlaying)
        {
            System.Random random = new System.Random();
            int num = random.Next(0, 2);
            List<AudioSource> list = new List<AudioSource>();
            list.Add(underwater2);
            list.Add(underwater2);      
            list[num].Play();

        }

    }

}
