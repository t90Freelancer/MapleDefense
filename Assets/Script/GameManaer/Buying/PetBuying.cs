using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PetBuying : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _StateOwn;
    [SerializeField] private List<GameObject> listImageDiamond;
    [SerializeField] private List<Image> listBackground;
    [SerializeField] private List<PetSO> _petSO;
    [SerializeField] private Sprite OwnStateBackground;
    [SerializeField] private PropertySO _propertySO;
    [SerializeField] private TextMeshProUGUI _DiamonTxt;
    [SerializeField] private GameObject InformUI;
    [SerializeField] private PlayerSO _playerSO;
    

    private void Start()
    {
        CheckState();
    }

    private void CheckState()
    {
        for(int i = 0; i < listImageDiamond.Count; i++)
        {
            checkIsOwn(i);
        }
    }

    private void checkIsOwn(int index)
    {        
            if (_petSO[index].isOwn)
            {
                listImageDiamond[index].SetActive(false);
                listBackground[index].sprite = OwnStateBackground;
            }       
    }
    public void BuyPet(int index)
    {
        if (!_petSO[index].isOwn)
        {
            if (_petSO[index].diamond <= _propertySO.Diamond)
            {
                _petSO[index].isOwn = true;
                _propertySO.Diamond -= _petSO[index].diamond;
                _StateOwn[index].text = "Owned";
            
                InformUI.GetComponent<Animator>().SetTrigger("Show");
                InformUI.GetComponentInChildren<TextMeshProUGUI>().text = "<color=green>Successful!</color>";
                checkIsOwn(index);
                _DiamonTxt.text = _propertySO.Diamond.ToString();
            }
            else
            {
            
                InformUI.GetComponent<Animator>().SetTrigger("Show");
                InformUI.GetComponentInChildren<TextMeshProUGUI>().text = "<color=red>Fail!!</color>";
            }
        }
        else
        {
            InformUI.GetComponent<Animator>().SetTrigger("Show");
            InformUI.GetComponentInChildren<TextMeshProUGUI>().text = "<color=yellow>Equip Successful!</color>";
            _playerSO.PetChoose = _petSO[index];
        }
        
    }
}
