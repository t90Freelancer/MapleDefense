using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerStat : MonoBehaviour, iDamage
{
    [SerializeField] private DamageFeedback _damagefb;
    [SerializeField] private Slider fillHP;
    [SerializeField] private int maxHealth;
    private Animator animator;
    private int currentHealth;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        fillHP.maxValue = maxHealth;
        UpdateUISlider();
    }

    private void UpdateUISlider()
    {
        fillHP.maxValue = maxHealth;
        fillHP.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        if(currentHealth <= 0)
        {
            return;
        }
        if(currentHealth - damage > 0)
        {
            currentHealth -= damage;
        }
        else
        {
            GetComponent<TowerDetect>().StopDetect();
            currentHealth = 0;
            animator.SetTrigger("Die");
        }
        _damagefb.ShowDamage(damage);
        UpdateUISlider();
    }   

    public void Die()
    {
        Destroy(gameObject);
    }
}
