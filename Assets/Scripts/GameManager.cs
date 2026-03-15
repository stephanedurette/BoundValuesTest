using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BoundedFloatData boundFloatData;

    void Start()
    {
        BoundedFloat f = new BoundedFloat(boundFloatData);
        Debug.Log(f.Value);
    }

}
