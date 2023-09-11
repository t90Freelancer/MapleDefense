using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{
    [SerializeField] private List<GameObject> skillPrefap = new List<GameObject>();
    [SerializeField] private AudioSource skillAudioSource;
    [SerializeField] private AudioClip skillClip;
    
    public void UsingSkill(int index)
    {
        if(skillClip != null)
        {            
            skillAudioSource.PlayOneShot(skillClip);
        }
        Vector3 Pos = transform.position;       
        GameObject skill = ObjectPoolManager.SpawnObject(skillPrefap[index],Pos,transform.rotation,ObjectPoolManager.PoolType.GameObject);
    }
}
