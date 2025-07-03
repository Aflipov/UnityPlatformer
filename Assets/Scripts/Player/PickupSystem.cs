using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class PickupSystem : MonoBehaviour
{
    [Header("Collectibles Counters")]
    [SerializeField] protected int currentBabyFires;
    [SerializeField] protected int currentFroggsKilled;
    [SerializeField] protected int currentPineapples;


    [Header("Events")]
    public UnityEvent OnBabyFirePickup;
    public UnityEvent OnFroggKill;
    public UnityEvent OnPineapplePickup;

    private int babyFiresGoal = GameManager.Instance.BabyFiresGoal;
    private int froggsGoal = GameManager.Instance.froggsGoal;


    private void Start()
    {
        currentBabyFires = 0;
        currentFroggsKilled = 0;

        babyFiresGoal = GameManager.Instance.BabyFiresGoal;
        froggsGoal = GameManager.Instance.froggsGoal;
    }

    private void Update()
    {
        //GoalCheck();
    }

    public void PickupBabyFire()
    {
        currentBabyFires++;
        OnBabyFirePickup.Invoke();
        Debug.Log("BabyFires: " + currentBabyFires);

        GoalCheck();
    }

    public void FroggUP()
    {
        currentFroggsKilled++;
        OnFroggKill.Invoke();
        Debug.Log("Froggs killed: " + currentFroggsKilled);

        GoalCheck();
    }
    public void PickupPineapple()
    {
        currentPineapples++;
        OnPineapplePickup.Invoke();
        Debug.Log("Pineapples: " + currentPineapples);
    }

    private void GoalCheck()
    {
        if (currentBabyFires >= babyFiresGoal && currentFroggsKilled >= froggsGoal)
        {
            SaveManager.SaveScore(PauseManager.instance.Timer);

            SceneSwapManager.SwapScene("MainMenu");
        }
    }

    public int GetBabyFiresCollected()
    {
        return currentBabyFires;
    }

    public int GetFroggsKilled()
    {
        return currentFroggsKilled;
    }
    public int GetPineapplesCollected()
    {
        return currentPineapples;
    }
}