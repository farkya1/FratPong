using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using UnityEngine;




public class PongCupManager : MonoBehaviour
{
    [SerializeField]
    SerializedDictionary<int,List<GameObject>> dictionaryPongNumToOrder = new SerializedDictionary<int,List<GameObject>>();
    
}
