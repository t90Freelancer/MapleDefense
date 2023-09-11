using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PropertyControll : MonoBehaviour
{
    [SerializeField] private PropertySO _propertySO;
    [SerializeField] private List<TextMeshProUGUI> _goldText;
    [SerializeField] private List<TextMeshProUGUI> _diamondText;

    private void Start()
    {
        UpdateProperty();
    }
    public void UpdateProperty()
    {
        _goldText[0].text = _propertySO.Gold.ToString("C0");
        _diamondText[0].text = _propertySO.Diamond.ToString("C0");
        if(_goldText.Count > 1 ) {
            foreach (var item in _goldText)
            {
                item.text = _propertySO.Gold.ToString("C0");
            }
            foreach (var item in _diamondText)
            {
                item.text = _propertySO.Diamond.ToString("C0");
            }                  
        }
    }
}
