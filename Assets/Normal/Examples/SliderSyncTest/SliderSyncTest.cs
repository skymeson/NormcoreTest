using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Normal.Realtime;

public class SliderSyncTest : MonoBehaviour {

    public Slider slider;

    public Text text;

    // Adjust this in inspector.
    [SerializeField]
    private float _value;
    //private float _value;
    private float _previousValue;

    private SliderSync _sliderSync;

    private RealtimeView _realtimeView;


    void Start () {

        //slider = GetComponent<Slider>();

        _realtimeView = GetComponent<RealtimeView>();


        _value = slider.value;
        text.text = _value.ToString();
        // Get a reference to the slider sync component.
        _sliderSync = GetComponent<SliderSync>();
	}
	
	void Update () {


        // If the _float has changed (via the inspector), call SetFloat on the slider sync component.
        if (_value != _previousValue) {

            _realtimeView.RequestOwnership();
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
