using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PetChooseSystem : MonoBehaviour
{
    [SerializeField] public List<GameObject> ListPet = new List<GameObject>();
    [SerializeField] public List<PetSO> ListPetSO = new List<PetSO>();
    [SerializeField] public List<GameObject> ListPetShow = new List<GameObject>();
    [SerializeField] private TextMeshProUGUI NameText;
   
    private int index;

    public void PickPet(ref PetSO PetObject)
    {
        PetObject = ListPetSO[index];
        ListPetSO[index].isOwn = true;
        ListPetShow[index].SetActive(false);
    }

    private void Start()
    {
        index = 0;
        ListPetShow[index].SetActive(true);
        NameText.text = ListPet[index].name;
    }

    
    public void NextPet()
    {             
        ListPetShow[index].SetActive(false);
        if (index == 2)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        ListPetShow[index].SetActive(true);
        NameText.text = ListPet[index].name;
    }

    public void PreviousPet()
    {
        ListPetShow[index].SetActive(false);
        if (index == 0)
        {
            index = 2;
        }
        else
        {
            index--;
        }
        ListPetShow[index].SetActive(true);
        NameText.text = ListPet[index].name;
    }
}
