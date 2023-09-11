using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HoverInform : MonoBehaviour
{
    [SerializeField] private CardSO _cardSO;
    [SerializeField] private TextMeshProUGUI heroNameText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI mpText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI Description;
    [SerializeField] private Image SkillIcon;

    public void ShowHoverInform()
    {
        heroNameText.text =_cardSO.HeroName;
        hpText.text = "<color=yellow>Hp: </color><color=red>" + _cardSO.hp.ToString() + "</color>";
        mpText.text = "<color=yellow>Mp: </color><color=blue>" + _cardSO.mp.ToString() + "</color>";
        damageText.text = "<color=yellow>Damage: </color><color=orange>" + _cardSO.damage.ToString() + "</color>";
        coinText.text = "<color=yellow>Coin: </color>" + _cardSO.coin.ToString();
        Description.text = "<color=yellow>Skill: </color>" + _cardSO.SkillDescription.ToString();
        SkillIcon.sprite = _cardSO.skilIcon;
    }
}
