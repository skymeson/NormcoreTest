using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Normal.Realtime;

public class SliderSync : RealtimeComponent {

    //private MeshRenderer _meshRenderer;
    private Slider slider; 
    private SliderSyncModel _model;
	
	void Start () {
        // Get a reference to the mesh renderer
        //_meshRenderer = GetComponent<MeshRenderer>();
        slider = GetComponent<Slider>();

    }
	
	private SliderSyncModel model {
        set {
            if (_model != null) {
                // Unregister from events
                _model.slidevalueDidChange -= ValueDidChange;
            }

            // Store the model
            _model = value;

            if (_model != null) {
                // Update the mesh renderer to match the new model.
                UpdateSlider();

                // Register for events so we'll know if the color changes later.
                _model.slidevalueDidChange += ValueDidChange;
            }
        }
    }

    private void ValueDidChange(SliderSyncModel model, float value) {
        // Update the slider.
        UpdateSlider();
    }

    private void UpdateSlider() {
        // Get the value from the model and set it on the Slider.
        slider.value = _model.slidevalue;
    }

    public void SetSliderValue(float value) {
        // Set the color on the model
        // This will fire the colorChanged event on the model, which will update the renderer for both the local player and all remote players.
        _model.slidevalue = value;
    }
}
