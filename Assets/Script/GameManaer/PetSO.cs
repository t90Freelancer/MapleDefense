using UnityEngine;
[CreateAssetMenu]
public class PetSO : ScriptableObject
{
    [SerializeField] public string PetName;
    [SerializeField] public int diamond;
    [TextArea(3,5)]
    [SerializeField] public string Description;
    [SerializeField] public bool isOwn;
    [TextArea(3, 5)]
    [SerializeField] public string Effect;
}
