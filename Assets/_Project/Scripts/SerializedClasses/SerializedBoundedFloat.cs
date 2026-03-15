using System;
using UnityEngine;

[Serializable]
public class SerializedBoundedFloat : SerializedFloat
{
    [SerializeReference, SubclassSelector] public SerializedFloat Min;
    [SerializeReference, SubclassSelector] public SerializedFloat Max;
    public bool StartsAtMin;
    public bool StartsAtMax;
}
