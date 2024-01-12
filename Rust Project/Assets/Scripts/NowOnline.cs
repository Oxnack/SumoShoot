using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using TMPro;

public class NowOnline : NetworkBehaviour                 // класс на ввывод числа подключенных клиентов
{
    [SerializeField] private TextMeshProUGUI _onlineText;
    [SerializeField] private float _delay = 5f;      // задержка между выводом(в с)

    private bool _ok = true;

    [SyncVar]
    public int countClients;

   

    private void Update()
    {
        StartCoroutine(DelayToCount(_delay));
    }

    private IEnumerator DelayToCount(float delay)           //   курутина на задержку перед выводом количества игроков
    {
        if (_ok)
        {
            _ok = false;

            yield return new WaitForSeconds(delay);

            if (isServer)
            {
                countClients = NetworkServer.connections.Count;
            }
            _onlineText.text = "онлайн: " + countClients;
            Debug.Log("Number of clients: " + countClients);

            _ok = true;
        }
    }
}
