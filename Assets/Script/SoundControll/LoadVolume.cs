using UnityEngine;

public class LoadVolume : MonoBehaviour
{
    [SerializeField] private LoadManager _loadManager;
    void Start()
    {
        _loadManager.LoadSFXVolume();
        _loadManager.LoadBackgroundVolume();
    }
}
