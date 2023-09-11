using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private PlayerSO _PlayerSO;
    [SerializeField] private TextMeshProUGUI _username;
    [SerializeField] private GameObject PanelError;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private PetChooseSystem _petChooseSystem;

    private void Start()
    {
        _PlayerSO.CurrentExp = 0;
        _PlayerSO.MaxExp = 20;
        _PlayerSO.Level = 1;
    }

    public void EnterUsername()
    {
        
        if(_username.text.Length==1)
        {
            PanelError.SetActive(true);
        }
        else
        {
            StartCoroutine(StartData());
            
        }
    }

    IEnumerator StartData()
    {
        yield return new WaitForSeconds(3f);
        _PlayerSO.PlayerName = _username.text;
        _petChooseSystem.PickPet(ref _PlayerSO.PetChoose);
        _levelLoader.LoadLevel(4);
    }
}
