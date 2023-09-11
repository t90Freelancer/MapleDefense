using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnParentToPool : MonoBehaviour
{
    public void ReturnObjectParentToPool()
    {
        ObjectPoolManager.ReturnObjectToPool(gameObject.transform.parent.gameObject);
    }
}
