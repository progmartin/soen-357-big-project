using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class showScore : MonoBehaviour
{
    public TextMeshProUGUI textShowScore;
    // Start is called before the first frame update
    void Start()
    {
        if (QuizManager.takeQuizTaken == true)
        {
            textShowScore.text = QuizManager.takeQuizScore + "/10";
        }
        else {
            textShowScore.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
