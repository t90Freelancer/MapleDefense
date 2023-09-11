using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDetect : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject Laser;
    private bool canShot;
    IEnumerator detectObject()
    {
        while (true)
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, layerMask);
            if (hit != null)
            {
                if (canShot)
                {
                    shotObject(hit.gameObject);
                    canShot = false;
                    Invoke("resetShot", 3f);
                }                
            }
            yield return null;
        }       

    }

    private void resetShot()
    {
        canShot = true;
    }

    private void shotObject(GameObject target)
    {
        GameObject laser = ObjectPoolManager.SpawnObject(Laser,transform.position,transform.rotation,ObjectPoolManager.PoolType.GameObject);
        laser.GetComponent<LaserControll>().MoveToObject(target);
    }

    public void StopDetect()
    {
        StopCoroutine(detectObject());
    }

    void Start()
    {
        canShot = true;
        StartCoroutine(detectObject()); 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, radius);  
    }

}
