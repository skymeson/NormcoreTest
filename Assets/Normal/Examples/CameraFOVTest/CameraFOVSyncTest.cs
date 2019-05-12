using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFOVSyncTest : MonoBehaviour
{
    [SerializeField]
    private float _cameraFOV;

    private float _previousCameraFOV;



    public Slider slider;


    private CameraFOVSync _cameraFOVSync;

    void Start()
    {
        // Get a reference to the color sync component.
        // Must be on Main Camera for this to work.
        // Check if null.
        //_cameraFOVSync = Camera.main.gameObject.GetComponent<CameraFOVSync>();
        _cameraFOVSync = GetComponent<CameraFOVSync>();
    }

    void Update()
    {
        _cameraFOV = slider.value;
        //Debug.Log("Camera FOV: " + _cameraFOV);

        // If the fov has changed (via the inspector), call SetCameraFOV on the sync component.
        if (_cameraFOV != _previousCameraFOV)
        {

            Debug.Log("Check if the fov has changed (via the inspector), call SetCameraFOV on the sync component.");
            _cameraFOVSync.SetCameraFOV(_cameraFOV);
            _previousCameraFOV = _cameraFOV;
        }
    }
}
