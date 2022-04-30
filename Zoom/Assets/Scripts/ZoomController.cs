using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    [SerializeField] private Camera _cam = null;


    [Header("Positions")]
    [SerializeField] private Vector3 _startPos;
    [SerializeField] private Vector3 _targetPos;



    [Header("Rotations")]
    [SerializeField] private Vector3 _startRotation;
    [SerializeField] private Vector3 _targetRotation;


    [SerializeField] [Range(0, 5)] private float _lerptime = 0;


    void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButton(0)) {
            UpdateCameraPosition(_targetPos);
            UpdateCameraRotations(_targetRotation);
        }
        else {
            UpdateCameraPosition(_startPos);
            UpdateCameraRotations(_startRotation);
        }
    }

    private void UpdateCameraPosition(Vector3 _target) {
        _cam.transform.position = Vector3.Lerp(_cam.transform.position, _target, _lerptime * Time.deltaTime);
    }

    private void UpdateCameraRotations(Vector3 _target) {
        _cam.transform.rotation = Quaternion.Slerp(_cam.transform.rotation, Quaternion.Euler(_target), _lerptime * Time.deltaTime);
    }
}
