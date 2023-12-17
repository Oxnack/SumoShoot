using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFly : MonoBehaviour                                 // ��������� ������� ���� � ���� � ����� ��� � ��������
{                                                                    // � �������� ����, ���� ������� �� �������� ������� , � �� �� ������� 
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
