using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Serialization;

public class Deck : MonoBehaviour
{
    [SerializeField] private List<CardTemplate> objects;

    public CardTemplate GetRandom()
    {
        return objects[Random.Range(0, objects.Count)];
    }
}
