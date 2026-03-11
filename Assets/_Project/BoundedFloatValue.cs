using System;
using UnityEngine;

[Serializable]
public class BoundedFloatValue : FloatValue
{
    [SerializeReference, SubclassSelector] public FloatValue Min;
    [SerializeReference, SubclassSelector] public FloatValue Max;
    public bool StartsAtMin;
    public bool StartsAtMax;
}
