using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;

public class Portal : NetworkBehaviour
{
    [SerializeField] private TextMeshPro _delayText;
    [SerializeField] private TextMeshPro _delayText2;
    [SerializeField] private GameObject _portal2;
    [SerializeField] private int _delayed;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            _portal2.GetComponent<BoxCollider>().enabled = false;

            other.transform.position = _portal2.transform.position;

            StartCoroutine(Delay(_delayed));
        }
    }

    private IEnumerator Delay(int delay)                                            // задержка между стрельбы (пулями)
    {
        while(delay > 0)
        {

            yield return new WaitForSeconds(1f);
            delay -= 1;
            _delayText.text = "Подождите: \n" + delay + " секунд.";
            _delayText2.text = "Подождите: \n" + delay + " секунд.";
        }
                                                   
        _delayText.text = "";
        _delayText2.text = "";

        gameObject.GetComponent<BoxCollider>().enabled = true;
        _portal2.GetComponent<BoxCollider>().enabled = true;
    }
}
