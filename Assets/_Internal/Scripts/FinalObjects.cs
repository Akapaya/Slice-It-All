using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalObjects : MonoBehaviour
{
    [SerializeField] private int _valueTimes;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Knife")
        {
            PlayerManager.DesactivePlayerEvent?.Invoke();
            UiManager.TimesCoinsEvent?.Invoke(_valueTimes);
        }
    }
}
