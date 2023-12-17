using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class Player : NetworkBehaviour                    // тут перемещение персонажа по риджитбоди, а не по чарестер контроллер ( нужно для сумо оброботки на сервере)
{                                                          // Миррор плохо дружит с чарастером , но хорошо с риджитбоди

    [SerializeField] private float _speedWalk;
    [SerializeField] private float _jumpPower;

    private GameObject _camera;                             //тут перемещение камены "за игроком" , сначала игрок, а камера под него подстраивается
    private Rigidbody _rb;
    private Vector3 _walkDirection;
    private bool _isGrounded;


    private void Start()
    {
        _camera = GameObject.Find("Camera");
        _rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (!isLocalPlayer) return;

        float x = Input.GetAxis("Horizontal");             // кнопки влево вправо на клаве и  WASD тоже
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
            _rb.AddForce(Vector3.up * _jumpPower);
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
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }
    }





}
