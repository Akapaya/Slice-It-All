using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private int _coins;
    [SerializeField] private TMP_Text _coinsText;

    public delegate void UpdateCoinsDelegate(int value);
    public static UpdateCoinsDelegate UpdateCoinsEvent;

    public delegate void TimesCoinsDelegate(int times);
    public static TimesCoinsDelegate TimesCoinsEvent;

    private void OnEnable()
    {
        UpdateCoinsEvent += UpdateCoin;
        TimesCoinsEvent += TimesCoin;
    }

    private void OnDisable()
    {
        UpdateCoinsEvent -= UpdateCoin;
        TimesCoinsEvent -= TimesCoin;
    }

    private void UpdateCoin(int value)
    {
        _coins += value;
        _coinsText.text = _coins.ToString();
    }

    private void TimesCoin(int times)
    {
        _coins = times *_coins;
        _coinsText.text = _coins.ToString();
        SaveManager.UpdateCoinsEvent?.Invoke(_coins);
    }
}
