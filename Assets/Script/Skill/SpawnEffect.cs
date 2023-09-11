using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    [SerializeField] private GameObject effect;
   public void SpawnObject()
    {
        ObjectPoolManager.SpawnObject(effect,transform.position,transform.rotation,ObjectPoolManager.PoolType.GameObject);
    }

    private void ReturnToPool()
    {
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            SpawnObject();
            ReturnToPool();
        }
    }
}
