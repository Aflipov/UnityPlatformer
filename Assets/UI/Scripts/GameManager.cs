using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Level Goals")]
    public int froggsGoal = 1;
    public int BabyFiresGoal = 3;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //Optional: Keep the GameManager when loading new scenes.
        }
    }
}