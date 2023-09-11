using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTutorial : MonoBehaviour
{
    [SerializeField] LevelLoader _levelLoader;
    void Start()
    {
        _levelLoader.LoadLevel(2);
    }    
}
