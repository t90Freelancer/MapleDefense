using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDataCardSO : MonoBehaviour
{
    [SerializeField] List<CardSO> cardList = new List<CardSO>();

    private void Start()
    {
        foreach (CardSO card in cardList)
        {
            card.level = 1;
            card.isDone = true;
            card.MoneyToLevelUp = 200;
            switch (card.HeroName)
            {
                case "Kain":
                    card.coin = 8;
                    card.hp = 40;
                    card.mp = 10;
                    card.damage = 8;
                    card.timeToSpawn = 6;
                    break;

                case "Kines":
                    card.coin = 3;
                    card.hp = 20;
                    card.mp = 6;
                    card.damage = 5;
                    card.timeToSpawn = 5;
                    break;

                case "Lumious":
                    card.coin = 6;
                    card.hp = 50;
                    card.mp = 12;
                    card.damage = 9;
                    card.timeToSpawn = 8;
                    break;

                case "Magician":
                    card.coin = 5;
                    card.hp = 15;
                    card.mp = 8;
                    card.damage = 4;
                    card.timeToSpawn = 6;
                    break;

                case "Pathfinder":
                    card.coin = 10;
                    card.hp = 30;
                    card.mp = 14;
                    card.damage = 8;
                    card.timeToSpawn = 9;
                    break;
            }
        }
                
            
    }
}
