using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PetInfor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI petNameTxt;
    [SerializeField] private TextMeshProUGUI descriptionTxt;
    [SerializeField] private TextMeshProUGUI effectTxt;


    public void updateContent(string name, string description,string effect)
    {
        petNameTxt.text = name;
        descriptionTxt.text = description;
        effectTxt.text = "<color=yellow>Effect: </color>"+effect;
    }  
}
