using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using TMPro;

public class Player : NetworkBehaviour                    // ��� ����������� ��������� �� ����������, � �� �� �������� ���������� ( ����� ��� ���� ��������� �� �������)
{                                                          // ������ ����� ������ � ���������� , �� ������ � ����������

    [SerializeField] private float _speedWalk;
    [SerializeField] private float _jumpPower, _maxJumpPower;

    [SerializeField] private TextMeshPro _namePlayerUI;

    private GameObject _camera;                             //��� ����������� ������ "�� �������" , ������� �����, � ������ ��� ���� ��������������
    private Rigidbody _rb;
    private Vector3 _walkDirection;
    private bool _isGrounded;
    private float _nowJumpPower;
    private string _offlineName;
    
    [SyncVar] private string _onlineName;



    private void Start()
    {
        _nowJumpPower = _jumpPower;
        _camera = GameObject.Find("Camera");
        _rb = GetComponent<Rigidbody>();
        
        if(isLocalPlayer)
        {
            _offlineName = PlayerPrefs.GetString("PlayerName");
            CmdNameToServer(_offlineName);
        }
    }

    [Command]
    public void CmdNameToServer(string name)
    {
        _onlineName = name;
    }


    private void Update()
    {
        _namePlayerUI.text = _onlineName;

        if (!isLocalPlayer) return;

        float x = Input.GetAxis("Horizontal");             // ������ ����� ������ �� ����� �  WASD ����
        float z = Input.GetAxis("Vertical");


        Jump(Input.GetKey(KeyCode.Space) && _isGrounded);
        _walkDirection = transform.right * x + transform.forward * z;
    }

    private void FixedUpdate()
    {
        Walk(_walkDirection);
    }

    private void Walk(Vector3 direction)
    {
        _rb.MovePosition(_rb.position + direction * _speedWalk * Time.deltaTime);
    }

    private void Jump(bool canJump)
    {
        if (canJump)
        {
            _rb.AddForce(Vector3.up * _nowJumpPower);
            _isGrounded = false;
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (!isLocalPlayer) return;

        if(collision.gameObject.tag == "Fall")
        {
            _camera.GetComponent<Transform>().position = new Vector3(0,10,0);
            _camera.GetComponent<Transform>().rotation = new Quaternion(0,0,0,0);

            NetworkManager.singleton.StopClient();
        }

        if(collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
        else if(collision.gameObject.tag == "Trampoline")
        {
            _rb.AddForce(Vector3.up * _maxJumpPower);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;
            _nowJumpPower = _jumpPower;
        }
    }

}
