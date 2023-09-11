using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip sfx;
    [SerializeField] private CardSO _cardSO;
    [SerializeField] private string tagObject;
    public int damageRate = 1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int realDamage = (int)Random.Range(_cardSO.damage-2, _cardSO.damage + 2);
        if (collision.gameObject.CompareTag(tagObject))
        {
            if (sfx != null)
            {
                audiosource.PlayOneShot(sfx);
            }
            collision.GetComponent<iDamage>().TakeDamage(realDamage*damageRate);
        }
    }
}
