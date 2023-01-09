
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PreparedGameInterface : MonoBehaviour
{
    public TMP_Text startText;

    public static event Action OnInterfacePrepared;

    public void InvokePreparedGame() {
        gameObject.SetActive(true);
        StartCoroutine(DownTime());
    }

    private IEnumerator DownTime() {
        for (int i = 5; i >= 0; i--) {
             startText.text = "Starting in " + i;
            yield return new WaitForSeconds(1f);
        }
        
        gameObject.SetActive(false);
        OnInterfacePrepared?.Invoke();
    }
}
