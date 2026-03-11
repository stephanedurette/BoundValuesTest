using UnityEngine;

[CreateAssetMenu(fileName = "BoundFloatData", menuName = "Scriptable Objects/BoundFloatData")]
public class BoundFloatData : ScriptableObject
{
    [SerializeReference, SubclassSelector] public FloatValue Value;
}
