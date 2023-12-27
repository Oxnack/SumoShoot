using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using TMPro;

public class NowOnline : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _onlineText;

    private void Update()
    {
        _onlineText.text = "онлайн: " + NetworkServer.connections.Count;
    }
}
