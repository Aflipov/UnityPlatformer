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


    private void Start()
    {
        currentBabyFires = 0;
        currentFroggsKilled = 0;
    }

    public void PickupBabyFire()
    {
        currentBabyFires++;
        OnBabyFirePickup.Invoke();
        Debug.Log("BabyFires: " + currentBabyFires);
    }

    public void FroggUP()
    {
        currentFroggsKilled++;
        OnFroggKill.Invoke();
        Debug.Log("Froggs killed: " + currentFroggsKilled);
    }
    public void PickupPineapple()
    {
        currentPineapples++;
        OnPineapplePickup.Invoke();
        Debug.Log("Pineapples: " + currentPineapples);
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
