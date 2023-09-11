using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormaAttack : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private bool isLeft;
    [SerializeField] LayerMask layerMask;
    private Vector3 pos;
    public void AttackNormal()
    {
       
        if(isLeft)
        {
            pos = transform.position - new Vector3(1f,0f,0f);
        }
        else
        {
            pos = transform.position + new Vector3(1f, 0f, 0f);
        }

        Collider2D hit = Physics2D.OverlapArea(pos, transform.forward,layerMask);
        if(hit != null) {
            hit.GetComponent<iDamage>().TakeDamage(5);
            Debug.Log("It collide with " + hit.gameObject.name +" "+ hit.GetInstanceID().ToString());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(pos, radius);
    }
}
