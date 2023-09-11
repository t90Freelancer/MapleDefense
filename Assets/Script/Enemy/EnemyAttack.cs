using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool isAttack = true;
    public int damage = 2;

    private void OnEnable()
    {
        isAttack = true;
    }
}
