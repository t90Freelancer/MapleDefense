using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class LoadManager : MonoBehaviour
{
    public PlayerSO _playerSO;
    public PropertySO _propertySO;
    public List<CardSO> _listCardSO = new List<CardSO>();
    public List<PetSO> _listPetSO = new List<PetSO>();
    public Slider _sliderBackground;
    public Slider _sliderSFX;
    public VolumSO _backgroundVolume;
    public VolumSO _SFXVolume;

    private string saveFolderPath = "Saves";

    public void LoadPlayer()
    {
        string saveDirectory = Path.Combine(Application.persistentDataPath, saveFolderPath);
        string savePath = Path.Combine(saveDirectory, "PlayerSO.json");

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            JsonUtility.FromJsonOverwrite(json, _playerSO);
        }
        else
        {
            Debug.LogWarning("Save file not found.");
        }
    }

    public void LoadProperty()
    {
        string saveDirectory = Path.Combine(Application.persistentDataPath, saveFolderPath);
        string savePath = Path.Combine(saveDirectory, "PropertySO.json");

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            JsonUtility.FromJsonOverwrite(json, _propertySO);
        }
        else
        {
            Debug.LogWarning("Save file not found.");
        }
    }


    public void LoadListHeorCard()
    {
        foreach (CardSO cardSO in _listCardSO)
        {
            string CardNameJson = "";
            switch (cardSO.HeroName)
            {
                case "Kain":
                    CardNameJson = "Kain.json";
                    break;
                case "Kines":
                    CardNameJson = "Kines.json";
                    break;
                case "Lumious":
                    CardNameJson = "Lumious.json";
                    break;
                case "Magician":
                    CardNameJson = "Magician.json";
                    break;
                case "Pathfinder":
                    CardNameJson = "Pathfinder.json";
                    break;
            }

            string saveDirectory = Path.Combine(Application.persistentDataPath, saveFolderPath);
            string savePath = Path.Combine(saveDirectory, CardNameJson);

            if (File.Exists(savePath))
            {
                string json = File.ReadAllText(savePath);
                JsonUtility.FromJsonOverwrite(json, cardSO);
            }
            else
            {
                Debug.LogWarning("Save file not found.");
            }
        }
    }

    public void LoadListPetSO()
    {
        foreach (PetSO _petSO in _listPetSO)
        {
            string PetNameJson = "";
            switch (_petSO.PetName)
            {
                case "Demon Metus":
                    PetNameJson = "DemonMetus.json";
                    break;
                case "Dino Boy":
                    PetNameJson = "DinoBoy.json";
                    break;
                case "Leaf Fog":
                    PetNameJson = "LeafFog.json";
                    break;
                case "Levi":
                    PetNameJson = "Levi.json";
                    break;
                case "LilDeath":
                    PetNameJson = "LilDeath.json";
                    break;
                case "Pink Bunny":
                    PetNameJson = "PinkBunny.json";
                    break;
            }

            string saveDirectory = Path.Combine(Application.persistentDataPath, saveFolderPath);
            string savePath = Path.Combine(saveDirectory, PetNameJson);

            if (File.Exists(savePath))
            {
                string json = File.ReadAllText(savePath);
                JsonUtility.FromJsonOverwrite(json, _petSO);
            }
            else
            {
                Debug.LogWarning("Save file not found.");
            }
        }
    }

    public void LoadBackgroundVolume()
    {
        string saveDirectory = Path.Combine(Application.persistentDataPath, saveFolderPath);
        string savePath = Path.Combine(saveDirectory, "SliderBackground.json");

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            JsonUtility.FromJsonOverwrite(json, _backgroundVolume);
        }
        else
        {
            Debug.Log("Save file not found.");
        }
        _sliderBackground.value = _backgroundVolume.volume;
    }

    public void LoadSFXVolume()
    {
        string saveDirectory = Path.Combine(Application.persistentDataPath, saveFolderPath);
        string savePath = Path.Combine(saveDirectory, "SliderSFX.json");

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            JsonUtility.FromJsonOverwrite(json, _SFXVolume);
        }
        else
        {
            Debug.Log("Save file not found.");
        }
        _sliderSFX.value = _SFXVolume.volume;
    }
}