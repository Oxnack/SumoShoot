using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFly : MonoBehaviour                                 // обработка летания куба у всех в катке как у клиентов
{                                                                    // и удаление куба, тоже отдельо на сторонах киентов , а не на сервере 
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _timeToDestroy;


    private void Start()
    {
        StartCoroutine(Destroyer()); 
    }

    private void Update()
    {
        if (gameObject)
        {
            transform.Translate(0, 0, 1f * _bulletSpeed * Time.deltaTime);
        }
    }


    public IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(_timeToDestroy);
        Destroy(gameObject);
    }
}
