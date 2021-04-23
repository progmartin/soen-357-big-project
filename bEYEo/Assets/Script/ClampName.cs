using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ClampName : MonoBehaviour
{
    
    public TextMeshProUGUI nameLabel;
   
    //public Text nameLabel;
    // Update is called once per frame
    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        nameLabel.transform.position = namePos;
    }
}
