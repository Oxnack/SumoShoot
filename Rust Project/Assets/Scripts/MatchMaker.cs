using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MatchMaker : NetworkBehaviour
{
    private NetworkMatch _networkMatch;
    private bool _ok = true;

    [SyncVar] public System.Guid matchGuid;
    
    private void Start()
    {
        _networkMatch = GetComponent<NetworkMatch>();
        if (isServer)
        {
            if (_ok)
            {
                matchGuid = GetGuid();
            }
        }
        Debug.Log("match Guid: " + GetGuid());
        _networkMatch.matchId = matchGuid;
    }

    private void Update()
    {
        
    }



    private System.Guid GetGuid()
    {
        System.Guid id = System.Guid.NewGuid();
        return id;
    }
}