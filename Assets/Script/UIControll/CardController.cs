using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    [SerializeField] private GameObject Hero;
    [SerializeField] private GoldControll _goldControl;
    [SerializeField] private List<CardSO> HeroList = new List<CardSO>();
    [SerializeField] private List<TextMeshProUGUI> _coinHeroText = new List<TextMeshProUGUI>();
    [SerializeField] private List<Image> timeCountdown;
    [SerializeField] private TextMeshProUGUI heroNumnerTxt;
    [SerializeField] public int maxHero;
    [SerializeField] private TextMeshProUGUI moneyToUpSlotTxt;
     private int moneyToUpSlot;


    private int waitHero;
    private int countHero;
    private void Start()
    {
        moneyToUpSlot = 25;
        moneyToUpSlotTxt.text = moneyToUpSlot.ToString();
        waitHero = 0;
        maxHero = 5;
        UpdateCoinHero();
        prepareCard();
    }

    public void UpSlotHero()
    {
        if(_goldControl.gold - moneyToUpSlot > 0)
        {
            maxHero++;
            _goldControl.gold -= moneyToUpSlot;
            moneyToUpSlot += 5;
            moneyToUpSlotTxt.text = moneyToUpSlot.ToString();
            heroNumnerTxt.text = "Hero On Lobby:" + countHero.ToString() + "/" + maxHero.ToString();
        }
    }

    private void HeroNumber()
    {
        countHero = GameObject.FindGameObjectsWithTag("Hero").Count()-2;
        heroNumnerTxt.text ="Hero On Lobby:"+ countHero.ToString() + "/" + maxHero.ToString();
    }
    private void Update()
    {
        HeroNumber();
    }

    private void prepareCard()
    {
        foreach(var hero in HeroList)
        {
            hero.isDone = true;
        }
    }
    private void UpdateCoinHero()
    {
        for (int i = 0; i < _coinHeroText.Count; i++)
        {

            _coinHeroText[i].text = HeroList[i].coin.ToString();
        }
        
    }
    public void SpawnHero(int i)
    {
        if (!HeroList[i].isDone || countHero + waitHero >= maxHero)
        {
            return;
        }

        if(_goldControl.gold >= HeroList[i].coin)
        {
            waitHero++;
            HeroList[i].isDone = false;
            StartCoroutine(CountDown(HeroList[i].timeToSpawn, timeCountdown[i], i));                       
        }
        else
        {
            Debug.Log("Not enough money");
        }
       
    }

    IEnumerator CountDown(float time,Image UITime,int index)
    {        
        float timerRemain = time;
        _goldControl.TakeHero(HeroList[index].coin);
        while (timerRemain > 0)
        {
            timerRemain-= Time.deltaTime;
            UITime.fillAmount = Mathf.Clamp01(timerRemain / time);
            yield return null;      
        }
            waitHero--;
            HeroList[index].isDone = true;            
            GameObject hero = ObjectPoolManager.SpawnObject(HeroList[index].Hero, transform.position, transform.rotation, ObjectPoolManager.PoolType.GameObject);
            hero.transform.position = GameObject.Find("House").transform.position;                
    }   
}
