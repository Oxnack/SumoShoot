using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mirror;

public class MainMenuEvents : MonoBehaviour
{
    [SerializeField] private InputField _inputField;

    private void Start()
    {
        NameAsk();
    }

    private void NameAsk()
    {
        if (PlayerPrefs.GetString("PlayerName") == "")
        {
            PlayerPrefs.SetString("PlayerName", "Player72328");
        }
        else
        {
            _inputField.text = PlayerPrefs.GetString("PlayerName");
        }
        Debug.Log("Your name:" + PlayerPrefs.GetString("PlayerName"));
    }

    public void OnRename()
    {
        PlayerPrefs.SetString("PlayerName", _inputField.text); 
    }

    public void ConnectToServer()
    {
        NetworkRoomManager.singleton.StartClient();
    }
}
