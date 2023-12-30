using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using TMPro;

public class NowOnline : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI _onlineText;

    [SyncVar]
    public int countClients;

    private void Update()
    {
        _onlineText.text = "онлайн: " + countClients;
        Debug.Log("Number of players: " + countClients);

        if (isServer)
        {
            countClients = NetworkServer.connections.Count;
            Debug.Log(NetworkServer.connections.Count);
        }
        Debug.Log(NetworkServer.connections.Count);
    }
}
