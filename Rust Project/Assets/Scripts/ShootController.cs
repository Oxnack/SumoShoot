using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ShootController : NetworkBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private float _transformToPlayerX;
    [SerializeField] private float _delay;
    
    private bool _ok = true;                           // ����� �� �������� (�� ��������)


    private void Update()
    {
        if (!isLocalPlayer) return;

        if (Input.GetMouseButtonDown(0) && _ok)
        {
            Debug.Log("Shoot!");
            SpawnBullet();

            _ok = false;

            StartCoroutine(Delayed());
        }
    }

    [Command]
    private void SpawnBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        bullet.transform.Translate(_transformToPlayerX, 0, 0);      // ����� ���� ����� �� ������ ����                        
        NetworkServer.Spawn(bullet);                                 // ������ ����� ���� �� ������� (�������)
    }

 
    public IEnumerator Delayed()                                            // �������� ����� �������� (������)
    {
        yield return new WaitForSeconds(_delay);
        _ok = true;
    }

 
}
