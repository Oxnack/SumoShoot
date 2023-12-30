using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class BattleButton : NetworkBehaviour
{

    public void ConnectToServer()
    {
        NetworkManager.singleton.StartClient();

    }
}
