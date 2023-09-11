using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateLevelCard : MonoBehaviour
{
    [SerializeField] private CardSO _cardSO;
    [SerializeField] private TextMeshProUGUI _nameCard;
    [SerializeField] private TextMeshProUGUI _levelText;

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        _levelText.text ="Lv."+ _cardSO.level.ToString();
        if (_cardSO.level == 4)
        {
            _nameCard.color = Color.yellow;
        }
    }
}
