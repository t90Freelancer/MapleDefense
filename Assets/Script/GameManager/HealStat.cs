using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealStat : MonoBehaviour,iDamage
{

    [SerializeField] private Slider _slider;
    [SerializeField] private bool isDefeat;
    [SerializeField] private GameObject DefeatPanel;


    public Action Loose;
    public int currentHp;
    public bool canHit;
    private int maxHp;


    private void Start()
    {
        canHit = true;
        maxHp = 10;
        currentHp = 10;
        UpdateUI();
    }

    private void UpdateUI()
    {        
        _slider.maxValue=maxHp;
        _slider.value = currentHp;
    }

    public void TakeDamage(int damage)
    {
        if (canHit)
        {     
            canHit = false;
            currentHp -= damage;
            if(currentHp <= 0)
            {
                if (isDefeat)
                {
                    Defeat();
                }
            }

            UpdateUI();
            StartCoroutine(BecomeVulnerable(1f));
        }
    }

    public void Defeat()
    {
        DefeatPanel.SetActive(true);
    }

    IEnumerator BecomeVulnerable(float time)
    {
        yield return new WaitForSeconds(time);
        canHit = true;
    } 

}
