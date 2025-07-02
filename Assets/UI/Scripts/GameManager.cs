using UnityEngine;
using TMPro; // Required to use TextMeshPro
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } //Singleton pattern

    [Header("Total Parameters")]
    public int totalFrogsKilled = 0;
    public int totalBabyFiresCollected = 0;


    [Header("Current Parameters")]
    public int currentHealth;

    public UnityEvent<int> OnCoinCollected;

    [Header("UI References")]
    public TextMeshProUGUI coinText; // Assign in the Inspector

    //Singleton Pattern: Only one instance of the GameManager can exist.
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //Optional: Keep the GameManager when loading new scenes.
        }
        else
        {
            Destroy(gameObject); //Destroy duplicate GameManagers.
        }
    }

    void Start()
    {
        //UpdateCoinText(); //Initial update
    }

    //Method to call for coin collecting
    //public void CollectCoin(int coinValue)
    //{
    //    totalCoinsCollected += coinValue;
    //    OnCoinCollected?.Invoke(coinValue);
    //    UpdateCoinText(); //Update the coin Text
    //}

    //Update The Coins Text
    //void UpdateCoinText()
    //{
    //    if (coinText != null)
    //    {
    //        coinText.text = "Coins: " + totalCoinsCollected.ToString();
    //    }
    //    else
    //    {
    //        Debug.LogWarning("CoinText not assigned.  Assign a TextMeshProUGUI object to the coinText field in the Inspector.", this);
    //    }
    //}
}