using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class nucleusScript : MonoBehaviour
{
    //cell
    public AudioSource membraneAnnouncer;
    public AudioSource thisIsTheNucleus;
    public AudioSource thisIsTheDNA;
    public static nucleusScript instance;
    public GameObject cellMembraneLetter;
    public GameObject cell;
    private Outline outline;

    //nucleus
    private Outline outlineNucleus;
    public GameObject moveIcon;
    public GameObject nucleus;
    public GameObject nucleusNametag;
    public GameObject instruction;
    static public bool nucleusInsideCell;

    //insidecell
    public GameObject stepInside;
    static public bool playerInsideCell;
    public GameObject DNA;

    //rer ser golgi
    public GameObject RER;
    public GameObject SER;
    public GameObject Golgi;

    //mito ribo
    public GameObject mito;
   // public GameObject ribo;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        cellMembraneLetter.SetActive(false);
        nucleusNametag.SetActive(false);
        instruction.SetActive(false);
        stepInside.SetActive(false);
        RER.SetActive(false);
        DNA.SetActive(false);
        SER.SetActive(false);
        Golgi.SetActive(false);
        mito.SetActive(false);
    }

    public IEnumerator nucleusStart() {

        bool notskip = false;

        if (!notskip)
        {
            //cell intro
            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = Color.white;
            outline.OutlineWidth = 1f;
            yield return new WaitForSeconds(2.5f);
            cellMembraneLetter.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            membraneAnnouncer.Play();


            //  move cell around

            yield return new WaitForSeconds(3f);
            moveIcon.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            outline.OutlineWidth = 10f;
            yield return new WaitForSeconds(0.5f);
            outline.OutlineWidth = 1f;
            yield return new WaitForSeconds(0.5f);
            outline.OutlineWidth = 10f;
            yield return new WaitForSeconds(0.5f);
            outline.OutlineWidth = 1f;
            yield return new WaitForSeconds(0.5f);
            outline.OutlineWidth = 10f;
            yield return new WaitForSeconds(0.5f);
            outline.OutlineWidth = 1f;
            yield return new WaitForSeconds(2f);
            moveIcon.SetActive(false);
        }

        //nucleus introduction
        nucleus.SetActive(true);
        nucleus.transform.position = new Vector3( cell.transform.position.x+0.7f, cell.transform.position.y, cell.transform.position.z);
        thisIsTheNucleus.Play();
        nucleusNametag.SetActive(false);
        yield return new WaitForSeconds(1f);
        instruction.SetActive(true);
        yield return new WaitForSeconds(3f);
        nucleus.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        outlineNucleus.OutlineWidth = 10f;
        yield return new WaitForSeconds(0.5f);
        outlineNucleus.OutlineWidth = 1f;
        yield return new WaitForSeconds(0.5f);
        nucleusNametag.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        
        //wait till nucleus inside cell
        yield return new WaitUntil(() => nucleusInsideCell ==true);
        instruction.SetActive(false);
        StartCoroutine(MoveOverSeconds(nucleus, new Vector3(cell.transform.position.x , cell.transform.position.y, cell.transform.position.z), 1f));
        nucleus.transform.SetParent(cell.transform);
      

        //invite user to step inside cell
        stepInside.SetActive(true);
        yield return new WaitForSeconds(1f);    
        yield return new WaitUntil(() => playerInsideCell == true);
        stepInside.SetActive(false);

        //insidecell
        yield return new WaitForSeconds(3f);
        DNA.SetActive(true);
        StartCoroutine(MoveOverSeconds(nucleus, new Vector3(cell.transform.position.x, cell.transform.position.y, cell.transform.position.z), 1f));

        //RER
        yield return new WaitForSeconds(3f);
        RER.SetActive(true);

        //SER
        yield return new WaitForSeconds(3f);
        SER.SetActive(true);


        //Golgi
        yield return new WaitForSeconds(3f);
        Golgi.SetActive(true);

        //mito
        yield return new WaitForSeconds(3f);
        mito.SetActive(true);


    }
    public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed)
    {
        // speed should be 1 unit per second
        while (objectToMove.transform.position != end)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }


    void Start()
    {
        outline = cell.AddComponent<Outline>();
        outlineNucleus = nucleus.AddComponent<Outline>();
        moveIcon.SetActive(false);
        nucleus.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
