using UnityEngine;

[CreateAssetMenu(fileName = "BoundedFloatData", menuName = "Scriptable Objects/BoundedFloatData")]
public class BoundedFloatData : ScriptableObject
{
    [SerializeReference, SubclassSelector] public SerializedFloat Value;
}
