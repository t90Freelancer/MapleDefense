using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverOnPetCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private PetSO petSO;
    [SerializeField] private GameObject Panel;
    [SerializeField] private TextMeshProUGUI diamondTxt;

    private void Start()
    {
        if (!petSO.isOwn)
        {
            diamondTxt.text = petSO.diamond.ToString();
        }
        else
        {
            diamondTxt.text = "Owned";
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Panel.SetActive(true);
        Panel.GetComponent<PetInfor>().updateContent(petSO.name, petSO.Description,petSO.Effect);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Panel.SetActive(false);
    }  

    // Update is called once per frame
    void Update()
    {
        if (Panel.activeSelf)
        {
            Panel.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition;
        }
    }
}
