using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyState : MonoBehaviour,iDamage
{
    [SerializeField] Image HpUI;
    [SerializeField] Image MpUI;
    private int hp;
    private int maxHp;
    private int mp;
    private int maxMp;
    public bool CanHit = true;

    private void UpdateUI(Image UIBar, int currentVal, int maxVal)
    {
        UIBar.fillAmount = Mathf.Clamp01(currentVal * 1.0f / maxVal);
    }

    private void OnEnable()
    {
        CanHit = true;
        hp = maxHp = 20;
        mp = 0;
        maxMp = 10;
        UpdateUI(HpUI, hp, maxHp);
        UpdateUI(MpUI, mp, maxMp);
    }

    public void TakeDamage(int damage)
    {
        if (CanHit)
        {
            if (hp - damage > 0)
            {
                CanHit = false;
                hp -= damage;
                StartCoroutine(BecomeVulnerable(0.5f));
                UpdateUI(HpUI, hp, maxHp);
            }
            else
            {
                hp = 0;
                GetComponent<Animator>().SetTrigger("Die");
            }
        }
    }

    IEnumerator BecomeVulnerable(float time)
    {
        yield return new WaitForSeconds(time);
        CanHit = true;
    }

    public void Die()
    {
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
