using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BuildBlocksController : NetworkBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Vector3 _vectorToPlayer;

    private void Update()
    {
        if (!isLocalPlayer) return;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Shoot!");
            SpawnCube();
        }
    }


    [Command]
    private void SpawnCube()
    {
        Vector3 cubePosition = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        
        GameObject bullet = Instantiate(_cubePrefab, cubePosition, new Quaternion(0f, 0f, 0f, 0f));
        bullet.transform.Translate(_vectorToPlayer);      // чтобы пуля сбоку от игрока была                        
        NetworkServer.Spawn(bullet);                                 // короче спавн пули на сервере (команда)
    }


}
