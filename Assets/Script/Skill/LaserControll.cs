using UnityEngine;


public class LaserControll : MonoBehaviour
{
    [SerializeField] private string tagText;
    private int damage;
    private GameObject target;
    private Rigidbody2D rb;

    public void MoveToObject(GameObject target1)
    {
        rb = GetComponent<Rigidbody2D>();
        target = target1;
        Invoke(nameof(ReturnToPool), 3F);
    }

    private void ReturnToPool()
    {
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }
    private void Update()
    {
        if(target==null) ReturnToPool();

        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        rb.velocity = dir * 500 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagText))
        {
            damage = (int)(collision.GetComponent<ObjectStat>().maxHp*1.0f / 3);
            collision.GetComponent<iDamage>().TakeDamage(damage);
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
    }
}
