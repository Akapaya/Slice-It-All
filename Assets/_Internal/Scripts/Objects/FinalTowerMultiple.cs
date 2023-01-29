using UnityEngine;

public class FinalTowerMultiple : MonoBehaviour
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
