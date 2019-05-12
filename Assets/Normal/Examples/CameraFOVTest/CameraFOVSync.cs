using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class CameraFOVSync : RealtimeComponent
{

    private Camera _camera;
    private CameraFOVModel _model;

    // Start is called before the first frame update
    void Start()
    {
        //_camera = Camera.main;
        _camera = GetComponent<Camera>();

    }

    private CameraFOVModel model
    {
        set
        {
           if(_model != null)
            {
                _model.cameraFOVDidChange -= FOVDidChange;
            }
            
            // Store the model
            _model = value;


            if(_model != null)
            {
                UpdateCameraFOV();

                _model.cameraFOVDidChange += FOVDidChange;
            }
        }
    }

    private void FOVDidChange(CameraFOVModel model, float value)
    {
        model.cameraFOV = value;
        UpdateCameraFOV();
    }

    public void UpdateCameraFOV()
    {
        _camera.fieldOfView = _model.cameraFOV;
    }

    public void SetCameraFOV(float fov)
    {
        // Set the color on the model
        // This will fire the colorChanged event on the model, which will update the renderer for both the local player and all remote players.
        _model.cameraFOV = fov;
    }
}
