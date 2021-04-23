using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class results : MonoBehaviour
{
    public GameObject resultBox;
    // Start is called before the first frame update
    void Start()
    {
        resultBox.GetComponentInChildren<TextMeshProUGUI>().text = QuizManager.score+"/10";
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
