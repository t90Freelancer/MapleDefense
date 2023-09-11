using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject Panel;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Panel.SetActive(true);
        Panel.GetComponent<HoverInform>().ShowHoverInform();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Panel.SetActive(false);
    }
}


