using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private int _coins;
    
    public delegate void UpdateCoinsDelegate(int value);
    public static UpdateCoinsDelegate UpdateCoinsEvent;

    private void Awake()
    {
        LoadCoins();
        UiManager.UpdateTotalCoinsEvent?.Invoke(_coins);
    }

    private void OnEnable()
    {
        UpdateCoinsEvent += UpdateCoin;
    }

    private void OnDisable()
    {
        UpdateCoinsEvent -= UpdateCoin;
    }

    private void UpdateCoin(int value)
    {
        _coins += value;
        SaveCoins();
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt("coins", _coins);
    }

    public void LoadCoins()
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            _coins = PlayerPrefs.GetInt("coins");
        }
    }
}
