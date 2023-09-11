using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldControll : MonoBehaviour
{
    [SerializeField] public int gold;
    [SerializeField] private TextMeshProUGUI goldText;

    private void Start()
    {
        goldText.text = gold.ToString();
        StartCoroutine(AddGoldByTime(5, 1f));
    }

    IEnumerator AddGoldByTime(int gold, float time)
    {
        while (true)
        {
        AddGold(gold);

        yield return new WaitForSeconds(time);
        }
    }

    public void AddGold(int goldToADD)
    {
        if (gold+goldToADD<100) { 
        gold += goldToADD;
        }
        else
        {
            gold = 100;
        }
        goldText.text = gold.ToString();
    }

    public void TakeHero(int goldToSubtract)
    {
        gold -= goldToSubtract;
        goldText.text = gold.ToString();
    }
}
