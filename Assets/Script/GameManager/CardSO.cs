using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardSO : ScriptableObject
{
    [SerializeField] public GameObject Hero;
    [SerializeField] public string HeroName;
    [TextArea(3,5)][SerializeField] public string SkillDescription;
    [SerializeField] public Sprite skilIcon;
    [SerializeField] public int coin;
    [SerializeField] public int hp;
    [SerializeField] public int mp;
    [SerializeField] public int damage;
    [SerializeField] public float timeToSpawn;
    [SerializeField] public bool isDone;
    [SerializeField] public int level =1;
    [SerializeField] public int MoneyToLevelUp;

    public void UpLevel()
    {
        if (level > 3)
        {
            return;
        }
        level++;

        switch(level) 
        {
            case 2:
                coin += 2;
                hp += 20;
                mp -= 1;
                damage += 2;
                timeToSpawn -= 0.5f;
                MoneyToLevelUp += 150;
                break;
            case 3:
                coin += 2;
                hp += 20;
                mp -= 1;
                damage += 4;
                timeToSpawn -= 0.5f;
                MoneyToLevelUp += 300;
                break;
            case 4:
                coin += 2;
                hp += 30;
                mp -= 2;
                damage += 4;
                timeToSpawn -= 1f;
                MoneyToLevelUp += 500;
                break;        
        }

        
    }
}
