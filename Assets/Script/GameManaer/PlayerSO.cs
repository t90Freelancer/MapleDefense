using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class PlayerSO : ScriptableObject
{
    [SerializeField] public string PlayerName;
    [SerializeField] public int CurrentExp;
    [SerializeField] public int MaxExp;
    [SerializeField] public int Level;
    [SerializeField] public PetSO PetChoose;

    public void AddExp(int exp)
    {
        if(CurrentExp + exp > MaxExp)
        {
            Level++;
            exp= exp-MaxExp;
            MaxExp += MaxExp;
            CurrentExp = 0;
            //if(exp>0)
            //{
            //AddExp(exp);
            //}
            //else
            //{
            //    return;
            //}
        }
        else
        {
            CurrentExp += exp;
        }
    }
}
