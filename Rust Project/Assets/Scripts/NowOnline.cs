using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using TMPro;

public class NowOnline : NetworkBehaviour                 // ����� �� ������ ����� ������������ ��������
{
    [SerializeField] private TextMeshProUGUI _onlineText;
    [SerializeField] private float _delay = 5f;      // �������� ����� �������(� �)

    private bool _ok = true;

    [SyncVar]
    public int countClients;

   

    private void Update()
    {
        StartCoroutine(DelayToCount(_delay));
    }

    private IEnumerator DelayToCount(float delay)           //   �������� �� �������� ����� ������� ���������� �������
    {
        if (_ok)
        {
            _ok = false;

            yield return new WaitForSeconds(delay);

            if (isServer)
            {
                countClients = NetworkServer.connections.Count;
            }
            _onlineText.text = "������: " + countClients;
            Debug.Log("Number of clients: " + countClients);

            _ok = true;
        }
    }
}
