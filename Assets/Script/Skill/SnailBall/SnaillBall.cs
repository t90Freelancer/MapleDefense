using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnaillBall : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private CardSO _cardSO;
    public int rateDamge;
    private Rigidbody2D rb;

    private void OnEnable()
    {
        StartCoroutine(ReturnPoolAfter(1.5f));
    }

    IEnumerator ReturnPoolAfter(float time)
    {
        yield return new WaitForSeconds(time);
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }
    public void ShotIt(Vector2 dir)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = dir * speed* Time.deltaTime;      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")) {
            collision.gameObject.GetComponent<iDamage>().TakeDamage(Random.Range(_cardSO.damage-3, _cardSO.damage + 3)*rateDamge);         
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
    }
}
