using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _actualCoinsText;
    [SerializeField] private TMP_Text _totalCoinsText;

    private int _totalCoins;
    private int _actualCoins;
    private bool _alteredValue;

    public delegate void UpdateTotalCoinsDelegate(int value);
    public static UpdateTotalCoinsDelegate UpdateTotalCoinsEvent;

    public delegate void UpdateCoinsDelegate(int value);
    public static UpdateCoinsDelegate UpdateCoinsEvent;

    public delegate void TimesCoinsDelegate(int times);
    public static TimesCoinsDelegate TimesCoinsEvent;

    private void OnEnable()
    {
        UpdateCoinsEvent += UpdateCoin;
        TimesCoinsEvent += TimesCoin;
        UpdateTotalCoinsEvent += UpdateTotalCoins;
    }

    private void OnDisable()
    {
        UpdateCoinsEvent -= UpdateCoin;
        TimesCoinsEvent -= TimesCoin;
        UpdateTotalCoinsEvent -= UpdateTotalCoins;
    }

    private void UpdateTotalCoins(int value)
    {
        _totalCoins += value;
        _totalCoinsText.text = "Total: " + _totalCoins.ToString();
    }

    private void UpdateCoin(int value)
    {
        _actualCoins += value;
        _actualCoinsText.text = _actualCoins.ToString();
    }

    private void TimesCoin(int times)
    {
        if (_alteredValue == false)
        {
            _alteredValue = true;
            _actualCoins = times * _actualCoins;
            _actualCoinsText.text = _actualCoins.ToString();
            SaveManager.UpdateCoinsEvent?.Invoke(_actualCoins);
        }
    }
}
