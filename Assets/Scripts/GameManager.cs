using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BoundedFloatData boundFloatData;

    void Start()
    {
        BoundedFloat f = new BoundedFloat(boundFloatData);
        f.Bind(OnValueChanged, OnMaxValueChanged, OnMinValueChanged, false);

        f.Value = 999;
        f.MaxValue.Value = 999;
        f.Value = 999;
    }

    private void OnMaxValueChanged(float value)
    {
        Debug.Log($"Max Value: {value}");
    }

    private void OnMinValueChanged(float value)
    {
        Debug.Log($"Min Value: {value}");
    }

    private void OnValueChanged(float value)
    {
        Debug.Log($"Value: {value}");
    }

}
