using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameLook : MonoBehaviour
{
    private GameObject _camera;

    void Start()
    {
        _camera = GameObject.Find("Camera");
    }

    void Update()
    {
        transform.LookAt(_camera.transform);
    }
}
