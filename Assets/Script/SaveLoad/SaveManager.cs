using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private PlayerSO _playerSO;
    [SerializeField] private PropertySO _propertySO;
    [SerializeField] private VolumSO backgroundVolume;
    [SerializeField] private VolumSO SFXVolume;

    public List<CardSO> _listCardSO = new List<CardSO>();
    public List<PetSO> _listPetSO = new List<PetSO>();
    public Slider _sliderBackground;
    public Slider _sliderSFX;


    private string saveFolderPath = "Saves";

    public void SavePlayerSO()
    {
        string saveDirectory = Path.Combine(Application.persistentDataPath, saveFolderPath);

        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }

        Debug.Log(saveDirectory);
        string json = JsonUtility.ToJson(_playerSO);
        string savePath = Path.Combine(saveDirectory,"PlayerSO.json");
        File.WriteAllText(savePath, json);
    }    

    public void SavePropertySO()
    {
        string saveDirectory = Path.Combine(Application.persistentDataPath, saveFolderPath);

        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }

        Debug.Log(saveDirectory);
        string json = JsonUtility.ToJson(_propertySO);
        string savePath = Path.Combine(saveDirectory, "PropertySO.json");
        File.WriteAllText(savePath, json);
    }

    public void SaveHeroCard()
    {
        foreach (CardSO _cardSO in _listCardSO)
        {
            string saveDirectory = Path.Combine(Application.persistentDataPath, saveFolderPath);

            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            string CardNameJson = "";
            switch (_cardSO.HeroName)
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


            Debug.Log(saveDirectory);
            string json = JsonUtility.ToJson(_cardSO);
            string savePath = Path.Combine(saveDirectory, CardNameJson);
            File.WriteAllText(savePath, json);
        }
    }

    public void SavePetSO()
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

            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            Debug.Log(saveDirectory);
            string json = JsonUtility.ToJson(_petSO);
            string savePath = Path.Combine(saveDirectory, PetNameJson);
            File.WriteAllText(savePath, json);

        }
        }

    public void SaveBackgroundVolume()
    {
        backgroundVolume.volume = _sliderBackground.value;
        string saveDirectory = Path.Combine(Application.persistentDataPath, saveFolderPath);

        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }

        Debug.Log(saveDirectory);
        string json = JsonUtility.ToJson(backgroundVolume);
        string savePath = Path.Combine(saveDirectory, "SliderBackground.json");
        File.WriteAllText(savePath, json);
    }
    public void SaveSFXVolume()
    {
        SFXVolume.volume = _sliderSFX.value;
        string saveDirectory = Path.Combine(Application.persistentDataPath, saveFolderPath);

        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }

        Debug.Log(saveDirectory);
        string json = JsonUtility.ToJson(SFXVolume);
        string savePath = Path.Combine(saveDirectory, "SliderSFX.json");
        File.WriteAllText(savePath, json);
    }
}
