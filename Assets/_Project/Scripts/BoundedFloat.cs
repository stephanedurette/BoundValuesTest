using System;

public class BoundedFloat
{
    private float _value;
    private BoundedFloat _minValue;
    private BoundedFloat _maxValue;

    public Action<float> OnValueChanged;
    public Action<float> OnMaxValueChanged;
    public Action<float> OnMinValueChanged;

    public BoundedFloat(BoundedFloatData data)
    {
        Initialize(data.Value);
    }

    public BoundedFloat(SerializedFloat serializedFloat)
    {
        Initialize(serializedFloat);
    }

    public BoundedFloat(float value)
    {
        _value = value;
    }

    private void Initialize(SerializedFloat serializedFloat)
    {
        switch (serializedFloat)
        {
            case SerializedUnboundedFloat uF:
                _value = uF.Value;
                _minValue = new BoundedFloat(float.MinValue);
                _maxValue = new BoundedFloat(float.MaxValue);
                break;
            case SerializedBoundedFloat bF:
                //_value =
                break;
            default:
                break;
        }

        //listen for min and max value changes
    }

    public void Bind(Action<float> OnValueChanged, Action<float> OnMaxValueChanged = null, Action<float> OnMinValueChanged = null)
    {
        this.OnValueChanged += OnValueChanged;
        if (OnMaxValueChanged != null) this.OnMaxValueChanged += OnMaxValueChanged;
        if (OnMinValueChanged != null) this.OnMinValueChanged += OnMinValueChanged;
    }
    public void Unbind(Action<float> OnValueChanged, Action<float> OnMaxValueChanged = null, Action<float> OnMinValueChanged = null)
    {
        this.OnValueChanged -= OnValueChanged;
        if (OnMaxValueChanged != null) this.OnMaxValueChanged -= OnMaxValueChanged;
        if (OnMinValueChanged != null) this.OnMinValueChanged -= OnMinValueChanged;
    }


}
