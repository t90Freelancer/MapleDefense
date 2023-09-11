using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClickChange : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel;
    
    public void ClickOnIt()
    {
        if (Panel.activeSelf)
        {
            Panel.SetActive(false);
        }
        else
        {
            Panel.SetActive(true);  
        }
    }
}
