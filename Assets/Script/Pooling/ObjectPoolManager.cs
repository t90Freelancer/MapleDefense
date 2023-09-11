using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<PoolObjectInfo> ObjectPools = new List<PoolObjectInfo>();

    private GameObject _objectPoolEmptyHolder;
    private static GameObject _particleSystemEmpty;
    private static GameObject _gameObjectEmpty;
    
    public enum PoolType 
    { 
        ParticleSystem,
        GameObject,
        UI,
        None    
    }

    public static PoolType PoolingType;

    private void Awake()
    {
        SetupEmpties();
    }
     
    private void SetupEmpties()
    {
        _objectPoolEmptyHolder = new GameObject("Pooled Object");

        _particleSystemEmpty = new GameObject("Particle Effect");
        _particleSystemEmpty.transform.SetParent(_objectPoolEmptyHolder.transform);

        _gameObjectEmpty = new GameObject("GameObjects");
        _gameObjectEmpty.transform.SetParent(_objectPoolEmptyHolder.transform);

        
    }
    public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation,PoolType poolType = PoolType.None)
    {
        PoolObjectInfo pool = ObjectPools.Find(p => p.LookupString == objectToSpawn.name);


        if(pool == null) 
        {
            pool = new PoolObjectInfo() { LookupString = objectToSpawn.name };
            ObjectPools.Add(pool);
        }


        GameObject spawnableObj = pool.InactiveObjects.FirstOrDefault();
        //GameObject spawnableObject = null;
        //foreach(GameObject obj in pool.InactiveObjects)
        //{
        //    if (obj != null)
        //    {
        //        spawnableObject = obj;
        //        break;
        //    }
        //}

        if(spawnableObj == null) 
        {
            GameObject parentObject = SetParentObject(poolType);

            spawnableObj = Instantiate(objectToSpawn, spawnPosition, spawnRotation);

            if(parentObject != null)
            {
                spawnableObj.transform.SetParent(parentObject.transform);
            }
        }
        else
        {
            spawnableObj.transform.position = spawnPosition;
            spawnableObj.transform.rotation = spawnRotation;
            pool.InactiveObjects.Remove(spawnableObj);
            spawnableObj.SetActive(true);
        }

        return spawnableObj;
    }

    public static void ReturnObjectToPool(GameObject obj) 
    {
        string goname = obj.name.Substring(0, obj.name.Length - 7);
        PoolObjectInfo pool = ObjectPools.Find(p => p.LookupString == goname);

        if(pool == null)
        {
            Debug.Log("Trying to release an object that is not pooled." + obj.name);
        }
        else
        {
            obj.SetActive(false);
            pool.InactiveObjects.Add(obj);
        }

    }

    private static GameObject SetParentObject(PoolType poolType) 
    {
        switch(poolType)
        {
            case PoolType.None:
                return null;
                
            case PoolType.ParticleSystem:
                return _particleSystemEmpty;
                
            case PoolType.GameObject:
                return _gameObjectEmpty;
                
            default:
                return null;                
        }
    }


}

public class PoolObjectInfo
{
    public string LookupString;
    public List<GameObject> InactiveObjects = new List<GameObject>();

}