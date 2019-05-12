using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderSyncTest : MonoBehaviour {

    public Slider slider;

    public Text text;

    // Adjust this in inspector.
    [SerializeField]
    private float _value;
    //private float _value;
    private float _previousValue;

    private SliderSync _sliderSync;

	void Start () {

        //slider = GetComponent<Slider>();

        _value = slider.value;
        text.text = _value.ToString();
        // Get a reference to the slider sync component.
        _sliderSync = GetComponent<SliderSync>();
	}
	
	void Update () {


        // If the _float has changed (via the inspector), call SetFloat on the slider sync component.
        if (_value != _previousValue) {
            _sliderSync.SetSliderValue(_value);
            _previousValue = _value;
            text.text = _value.ToString();

        }
    }

    public void SetSliderValue(float value)
    {
        _value = value;
    }
}
