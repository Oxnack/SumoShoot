using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MouseLook : NetworkBehaviour
{
    [SerializeField] private float _sensitivity;
    [SerializeField] private Transform _character;
    private GameObject _camera;


    private float _xRotation;



    void Update()
    {

        _camera = GameObject.Find("Camera");

        if (!isLocalPlayer) return;

        _camera.GetComponent<Transform>().position = transform.position;
        _camera.GetComponent<Transform>().rotation = transform.rotation;


        if (Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }


        Tracking();

     
    }


    private void Tracking()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _character.Rotate(Vector3.up * mouseX);
    }

    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
