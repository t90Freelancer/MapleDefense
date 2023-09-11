using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageFeedback : MonoBehaviour
{
    [SerializeField] private GameObject damageFeedback;

    public void ShowDamage(int damage)
    {
        Vector3 pos = new Vector3(Random.Range(transform.position.x-0.5f, transform.position.x + 0.5f), transform.position.y + 0.5f, 0);
        GameObject damefb = ObjectPoolManager.SpawnObject(damageFeedback,pos,transform.rotation,ObjectPoolManager.PoolType.GameObject); 
        damefb.GetComponentInChildren<TextMeshPro>().text = damage.ToString();
        if(damage>0 && damage < 3)
        {
            damefb.transform.localScale = Vector3.one;
        }else if(damage <6) {
            damefb.transform.localScale = new Vector3(1.3f,1.3f,1.3f);
        }
        else 
        {
            damefb.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
        }
    }
}
