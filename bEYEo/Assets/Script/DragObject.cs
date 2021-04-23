using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZcoord;
    public AudioSource move1;
    public AudioSource move2;
    public AudioSource move3;

    private void OnMouseDown()//clicking
    {
        mZcoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPosition();


       // playSound();

    }


   
    private void OnMouseDrag()// letting go
    {
        transform.position = GetMouseWorldPosition() + mOffset;
        //playSound();

    }


    public Vector3 GetMouseWorldPosition() {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZcoord;
        if (!soundPlaying())
        {
            playSound();
        }
        return Camera.main.ScreenToViewportPoint(mousePoint);
        

    }


    public void playSound() {
        System.Random random = new System.Random();
        int num = random.Next(0, 3);
        List<AudioSource> list = new List<AudioSource>();
        list.Add(move1);
        list.Add(move2);
        list.Add(move3);
        list[num].Play();
    }

    public bool soundPlaying()
    {
        System.Random random = new System.Random();
        int num = random.Next(0, 3);
        List<AudioSource> list = new List<AudioSource>();
        list.Add(move1);
        list.Add(move2);
        list.Add(move3);   

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].isPlaying==true)
            {
                return true;
            }
            
        }
        return false;
    }
}
