using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkill : MonoBehaviour
{
    [SerializeField] CardSO HeroSO;
    [SerializeField] private List<GameObject> _skillList;
    [SerializeField] private bool isLeft;
    [SerializeField] private AudioSource _Audiosouce;
    [SerializeField] private AudioClip sfx;
    private Vector2 dir;
    private Vector3 pos;
    public void SpawnSkillToDirection(int index)
    {
        if(sfx!=null)
        {
            _Audiosouce.PlayOneShot(sfx);
        }
        if(isLeft )
        {
            dir = Vector2.left;
            pos = transform.position + new Vector3(-0.2f, 0.3f, 0);
        }
        else
        {
            dir = Vector2.right;
            pos = transform.position + new Vector3(0.2f, 0.3f, 0);
        }
        GameObject _skill = ObjectPoolManager.SpawnObject(_skillList[index], pos, transform.rotation, ObjectPoolManager.PoolType.GameObject);
        _skill.GetComponent<SnaillBall>().ShotIt(dir);
    }
}
