using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetEffect : MonoBehaviour
{
    [SerializeField] private Image PetImage;
    [SerializeField] private PlayerSO _playerSO;
    [SerializeField] private List<Sprite> _listSprite;

    private void Start()
    {
        UpdateUI(); 
    }

    private void UpdateUI()
    {
        if(_playerSO != null)
        switch (_playerSO.PetChoose.name)
        {
            case "Demon Metus":
                PetImage.sprite = _listSprite[0];
                break;
            case "Dino Boy":
                PetImage.sprite = _listSprite[1];
                break;
            case "Leaf Fog":
                PetImage.sprite = _listSprite[2];
                break;
            case "Levi":
                PetImage.sprite = _listSprite[3];
                break;
            case "LilDeath":
                PetImage.sprite = _listSprite[4];
                break;
            case "Pink Bunny":
                PetImage.sprite = _listSprite[4];
                break;
        }
    }
}
