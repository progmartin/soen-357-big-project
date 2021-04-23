using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceCell : MonoBehaviour
{

    public GameObject cell;
    public GameObject placeCellButton;
    private PlacementIndicator placementIndicator;
    public AudioSource move1;
    public nucleusScript nucleusScript;
    public TextMeshProUGUI moveScreen;
    

    private Camera cam;
    public static PlaceCell instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        cell.SetActive(false);
        moveScreen.enabled = true;
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void placeCell()
    {
        cell.SetActive(true);
        //cell.transform.position = placementIndicator.transform.position;
        moveScreen.enabled = false;
        cell.transform.position = new Vector3(placementIndicator.transform.position.x, placementIndicator.transform.position.y+1f, placementIndicator.transform.position.z + 0.4f);
        placementIndicator.gameObject.SetActive(false);
        placeCellButton.SetActive(false);
        
        move1.Play();

       
        StartCoroutine(nucleusScript.instance.nucleusStart());
        
    }
}
