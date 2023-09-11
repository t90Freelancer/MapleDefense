using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private bool isLeft;
    [SerializeField] private float speed;
    [SerializeField] private float time;
    [SerializeField] private string _tag;
    [SerializeField] private int damage;

    [Header("Circle Check")]
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Vector3 pos;
    private Rigidbody2D rb;
   

    private void OnEnable()
    {
        transform.position = GetComponentInParent<Transform>().position;
        StartCoroutine(ReturnPool(time));
        rb = GetComponent<Rigidbody2D>();

        if (isLeft)
        {
            rb.velocity = Vector2.left * speed * Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector2.right * speed * Time.deltaTime;
        }
    }

    private void DetectObject()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position+pos, radius, layerMask);
        if (hit!=null)
        {
            hit.GetComponent<iDamage>().TakeDamage(damage);
            ObjectPoolManager.ReturnObjectToPool(transform.parent.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position+pos, radius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_tag))
        {
            collision.GetComponent<iDamage>().TakeDamage(damage);
            ObjectPoolManager.ReturnObjectToPool(transform.parent.gameObject);
        }
    }

    IEnumerator ReturnPool(float time)
    {
        while (true)
        {
        DetectObject();
            yield return null;
        }        

    }    
}
