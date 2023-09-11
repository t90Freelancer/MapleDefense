using TMPro;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    [SerializeField] PropertySO _propertySO;
    [SerializeField] private TextMeshProUGUI GoldText;
    [SerializeField] private TextMeshProUGUI DiamondText;
    public void AddGold()
    {
        _propertySO.Gold += 999999;
        GoldText.text = _propertySO.Gold.ToString();
    }

    public void AddDiamond()
    {
        _propertySO.Diamond += 999999;
        DiamondText.text = _propertySO.Diamond.ToString();
    }
}
