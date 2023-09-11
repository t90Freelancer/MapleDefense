using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterKill : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _monsterKill;
    private int counter;

    private void Start()
    {
        counter = 0;
        UpdateText();
    }

    public void AddPoint()
    {
        counter++;
        UpdateText();
    }

    private void UpdateText()
    {
        _monsterKill.text = counter.ToString();
    }

}
