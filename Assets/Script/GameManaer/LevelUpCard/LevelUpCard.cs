using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpCard : MonoBehaviour
{
    [SerializeField] private PropertySO _propertySO;
    [SerializeField] private CardSO _cardSO;
    [SerializeField] private PropertyControll _propertyControll;
    [SerializeField] private TextMeshProUGUI _leveltext;
    [SerializeField] private TextMeshProUGUI _MoneyToUpText;
    [SerializeField] private TextMeshProUGUI _chatacterName;

    private void Start()
    {
        _MoneyToUpText.text = _cardSO.MoneyToLevelUp.ToString("C0");
        if (_cardSO.level == 4)
        {
            _chatacterName.color = Color.yellow;
            Destroy(gameObject);
        }
    }

    public void CardUp()
    {
        if(_cardSO.level > 3)
        {
            return;
        }
        if(_propertySO.Gold >= _cardSO.MoneyToLevelUp)
        {
            _cardSO.UpLevel();
            _propertySO.Gold -= _cardSO.MoneyToLevelUp;
            _propertyControll.UpdateProperty();
            _leveltext.text = "Lv."+_cardSO.level.ToString();
            GetComponent<SpawnParticle>().ParticleSpawn();
            _MoneyToUpText.text = _cardSO.MoneyToLevelUp.ToString("C0");

            if(_cardSO.level == 4)
            {
                _chatacterName.color = Color.yellow;
                Destroy(gameObject);
            }
        }
    }
}
