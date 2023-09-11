using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> Enemys;
    [SerializeField] private int numberToSpawn;
    [SerializeField] private float spawnTime;
    [SerializeField] private int index;
    [SerializeField] private int waveAmount;
    
    private void SpawnAuto(int number) 
    {          
           StartCoroutine( SpawnByTime(spawnTime,number));       
    }

    IEnumerator SpawnByTime(float time,int numberToSpawn)
    {
        int count = 0;
        while (true)
        {
            if (count < waveAmount)
            {
                count++;
               GameObject enemy = ObjectPoolManager.SpawnObject(Enemys[index], transform.position, transform.rotation, ObjectPoolManager.PoolType.GameObject);
            }
            else
            {
                waveAmount = (int)Random.Range(3, 7);
                index++;
                if(index==Enemys.Count) {
                    index = 0;
                }
                count = 0;
            }
            
            yield return new WaitForSeconds(time);
        }        
    }
    private void Start()
    {
        index = 0;    
        StartCoroutine(SpawnByTime(spawnTime, waveAmount));
    }
    
}
