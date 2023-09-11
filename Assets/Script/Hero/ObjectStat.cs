using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ObjectStat : MonoBehaviour,iDamage
{
    private MonsterKill monsterkill;
    [SerializeField] private DamageFeedback damageFeedback;    
    public CardSO StatData;
    public bool isSpawnKill;
    [SerializeField] public int hp;
    public int maxHp;
    [SerializeField] private int mp;
    private int maxMp;
    public bool notUseSkill;
    [SerializeField] private Image hpUI;

    [SerializeField] private Image mpUI;

    private void Start()
    {
        monsterkill = FindAnyObjectByType<MonsterKill>();
    }
    private void OnEnable()
    {        
        if(StatData != null)
        {
            hp = maxHp = StatData.hp;
            maxMp = StatData.mp;
        }      
        mp = 0;
        UpdateUI(hpUI, hp, maxHp);
        UpdateUI(mpUI, mp, maxMp);
    }
  
    public void AddMp()
    {
        if (mp + 2 <= maxMp)
        {
            mp += 2;
        } else  
        {
            mp = 0;
            if(isSpawnKill)
            {
                GetComponent<SpawnSkill>().SpawnSkillToDirection(1);
            }
            else
            {
                GetComponent<UseSkill>().UsingSkill(1);
                if(StatData.HeroName == "Snail")
                {
                    hp += 4;
                }

                if (StatData.HeroName == "Slime")
                {
                    GetComponent<ObjectAI>().speed = 40;
                }
            }
        }
            UpdateUI(mpUI,mp, maxMp);
    }
    private void UpdateUI(Image UIBar, int currentVal, int maxVal)
    {
        UIBar.fillAmount = Mathf.Clamp01(currentVal * 1.0f / maxVal);
    }   

    public void TakeDamage(int damage)
    {
        if (!notUseSkill)
        {
        AddMp();
        }
        if (hp <= 0)
        {
            GetComponent<Animator>().SetTrigger("Die");
            return;
        }
              
        if (hp - damage > 0)
        {
            damageFeedback.ShowDamage(damage);          
            hp -= damage;
            if (gameObject.CompareTag("Enemy"))
            {
                GetComponent<Animator>().SetTrigger("Hit");
            }
        }
        else
        {
            damageFeedback.ShowDamage(damage);
            hp = 0;
            if (gameObject.CompareTag("Enemy"))
            {
                 monsterkill.AddPoint();
            }
            GetComponent<Animator>().SetTrigger("Die");
        }
            UpdateUI(hpUI, hp, maxHp);          
    }
     
    public void Die()
    {
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }   
   
}
