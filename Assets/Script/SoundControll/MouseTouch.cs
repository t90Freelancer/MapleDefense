using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseTouch : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SoundControl _soundControl;

    public void OnPointerClick(PointerEventData eventData)
    {
        _soundControl.Playsound_effect(0);
    } 
}
