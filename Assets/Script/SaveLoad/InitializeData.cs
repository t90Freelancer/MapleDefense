using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeData : MonoBehaviour
{
    [SerializeField] private PropertySO _propertySO;
    [SerializeField] private List<PetSO> _listPetSO;

    public void PropertyInitialize()
    {
        _propertySO.Gold = 0;
        _propertySO.Diamond = 0;
    }

    public void PetSOInitialize()
    {
        foreach (PetSO _petSO in _listPetSO)
        {
            _petSO.isOwn = false;
        }
    }
}
