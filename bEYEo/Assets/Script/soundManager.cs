using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource lightDive;
    public AudioSource medDive;
    public AudioSource underwater;
   static public SoundManager instance;

   
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
