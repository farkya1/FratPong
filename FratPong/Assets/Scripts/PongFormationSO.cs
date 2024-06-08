
using UnityEngine;


[CreateAssetMenu(fileName = "PongFormation", menuName = "ScriptableObjects/PongFormation", order = 1)]
public class PongFormationSO :ScriptableObject
{
    public string formationName;

    public GameObject formationGO;


    public Sprite formationImage;

}
