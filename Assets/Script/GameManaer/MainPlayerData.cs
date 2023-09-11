using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainPlayerData : MonoBehaviour
{
    [SerializeField] private PlayerSO _PlayerDataSO;
    [SerializeField] private TextMeshProUGUI PlayerName;
    [SerializeField] private Slider ExpSlider;
    [SerializeField] private TextMeshProUGUI LevelTxt;
    [SerializeField] private TextMeshProUGUI ExpState;
    void Start()
    {
        PlayerName.text = _PlayerDataSO.PlayerName;
        ExpSlider.maxValue = _PlayerDataSO.MaxExp;
        ExpSlider.value = _PlayerDataSO.CurrentExp;
        LevelTxt.text = _PlayerDataSO.Level.ToString();
        ExpState.text = _PlayerDataSO.CurrentExp.ToString() + "/" + _PlayerDataSO.MaxExp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
