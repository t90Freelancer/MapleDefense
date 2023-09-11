using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelWin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _diamondTxt;
    [SerializeField] private TextMeshProUGUI _goldTxt;
    [SerializeField] private TextMeshProUGUI _expTxt;
    [SerializeField] private TextMeshProUGUI _diamondBonusTxt;
    [SerializeField] private TextMeshProUGUI _goldBonusTxt;
    [SerializeField] private PropertySO propertySO;
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private TextMeshProUGUI _LevelTxt;
    [SerializeField] private TextMeshProUGUI _ExpTxt;
    [SerializeField] private Slider _expSlider;
    [SerializeField] private GameObject DiamondBonusPanel;
    [SerializeField] private GameObject GoldBonusPanel;

    public int goldClaim;
    public int diamondClaim;
    public int expClaim;

    public int bonusGold;
    public int bonusDiamond;

    private void Start()
    {
        UpdateBonusFromPet();
        UpdateUI();
    }

    private void UpdateBonusFromPet()
    {
        switch(playerSO.PetChoose.name)
        {
            case "Pink Bunny":
            case "Dino Boy":
            case "Leaf Fog":
                GoldBonusPanel.SetActive(true);
                bonusGold = goldClaim * 2;
                break;
            case "Demon Metus":
                GoldBonusPanel.SetActive(true);
                DiamondBonusPanel.SetActive(true);
                bonusGold = goldClaim * 5;
                bonusDiamond = diamondClaim * 3;
                break;
            case "Levi":
            case "LilDeath":
                GoldBonusPanel.SetActive(true);
                DiamondBonusPanel.SetActive(true);
                bonusGold = goldClaim* 10;
                bonusDiamond = diamondClaim*10;
                break;
        }
    }
    private void UpdateUI()
    {
        _expSlider.maxValue = playerSO.MaxExp;
        _expSlider.value = playerSO.CurrentExp;
        _diamondTxt.text =diamondClaim.ToString();
        _goldTxt.text =goldClaim.ToString();
        _expTxt.text =expClaim.ToString();
        _diamondBonusTxt.text = bonusDiamond.ToString();
        _goldBonusTxt.text = bonusGold.ToString();
        _LevelTxt.text = playerSO.Level.ToString();
        _ExpTxt.text = playerSO.CurrentExp.ToString() +"/" + playerSO.MaxExp.ToString(); 
    }

    public void ClaimReward()
    {
        propertySO.Gold += goldClaim + bonusGold;
        propertySO.Diamond += diamondClaim + bonusDiamond;
        
        playerSO.AddExp(expClaim);
    }
}
