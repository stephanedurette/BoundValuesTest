using System;
using UnityEngine;

public class BoundedFloat
{
    public float Value { 
        get { return _value; } 
        set { 
            float clampedValue = Mathf.Clamp(value, _minValue.Value, _maxValue.Value);
            if (clampedValue == _value) return;
            _value = clampedValue; 
            OnValueChanged?.Invoke(_value);
        } 
    }

    public BoundedFloat MaxValue => _maxValue;

    public BoundedFloat MinValue => _minValue;

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
                _minValue = new BoundedFloat(bF.Min);
                _maxValue = new BoundedFloat(bF.Max);
                _value = bF.StartsAtMax ? _maxValue.Value : _minValue.Value;
                break;
            default:
                break;
        }

        _minValue.OnValueChanged += (newValue) => OnMinValueChanged?.Invoke(newValue);
        _maxValue.OnValueChanged += (newValue) => OnMaxValueChanged?.Invoke(newValue);
    }

    public void Bind(Action<float> OnValueChanged, Action<float> OnMaxValueChanged = null, Action<float> OnMinValueChanged = null, bool invokeAfterBind = true)
    {
        this.OnValueChanged += OnValueChanged;
        if (OnMaxValueChanged != null) this.OnMaxValueChanged += OnMaxValueChanged;
        if (OnMinValueChanged != null) this.OnMinValueChanged += OnMinValueChanged;

        if (invokeAfterBind)
        {
            this.OnValueChanged?.Invoke(_value);
            this.OnMinValueChanged?.Invoke(_minValue.Value);
            this.OnMaxValueChanged?.Invoke(_maxValue.Value);
        }
    }

    public void Unbind(Action<float> OnValueChanged, Action<float> OnMaxValueChanged = null, Action<float> OnMinValueChanged = null)
    {
        this.OnValueChanged -= OnValueChanged;
        if (OnMaxValueChanged != null) this.OnMaxValueChanged -= OnMaxValueChanged;
        if (OnMinValueChanged != null) this.OnMinValueChanged -= OnMinValueChanged;
    }


}
