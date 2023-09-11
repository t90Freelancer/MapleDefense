using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    [SerializeField] private float radius;
    public LayerMask EnemyLayer;
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }
    private void CheckAttack()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, radius,EnemyLayer);
        
        if(hit.Length >0)
        {         
            GetComponentInParent<SetAnim>().state = SetAnim.HeroState.attack;
            anim.SetTrigger("Attack");
            foreach(Collider2D enemy in hit)
            {
                enemy.gameObject.GetComponent<EnemyState>().TakeDamage(2);
            }
        }
        else
        {
            GetComponentInParent<SetAnim>().state = SetAnim.HeroState.moving;
        }
    }

    private void Update()
    {
        CheckAttack();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
