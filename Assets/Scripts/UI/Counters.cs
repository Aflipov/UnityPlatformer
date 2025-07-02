using TMPro;
using UnityEngine;

public class Counters : MonoBehaviour
{
	[SerializeField] private PickupSystem playerPickupSystem;
	[SerializeField] private PlayerHealthSystem playerHealthSystem;

    [SerializeField] private TextMeshProUGUI babyFiresCounter;
    [SerializeField] private TextMeshProUGUI froggsCounter;
    [SerializeField] private TextMeshProUGUI pineapplesCounter;

	public int currentBabyFires;
	public int currentFroggs;
	public int currentPineapples;

	void Start()
	{
		currentBabyFires = playerPickupSystem.GetBabyFiresCollected();
		currentFroggs = playerPickupSystem.GetFroggsKilled();
		currentPineapples = playerPickupSystem.GetPineapplesCollected();

        playerPickupSystem.OnBabyFirePickup.AddListener(OnBabyFireCollected);
        playerPickupSystem.OnFroggKill.AddListener(OnFroggKilled);
        playerPickupSystem.OnPineapplePickup.AddListener(OnPineappleCollected);
    }

	//private void OnEnable()
	//{
	//	if (playerHealthSystem != null)
	//	{
	//		playerPickupSystem.OnBabyFirePickup.AddListener(OnBabyFireCollected);
	//		playerPickupSystem.OnFroggKill.AddListener(OnFroggKilled);
	//		playerPickupSystem.OnPineapplePickup.AddListener(OnPineappleCollected);
	//	}
	//}

	//private void OnDisable()
	//{
	//	if (playerHealthSystem != null)
 //       {
 //           playerPickupSystem.OnBabyFirePickup.RemoveListener(OnBabyFireCollected);
 //           playerPickupSystem.OnFroggKill.RemoveListener(OnFroggKilled);
 //       }
	//}

	public void OnBabyFireCollected()
	{
		currentBabyFires = playerPickupSystem.GetBabyFiresCollected();
		babyFiresCounter.text = string.Format("{0:D2}", currentBabyFires);
	}
	public void OnFroggKilled()
	{
		currentFroggs = playerPickupSystem.GetFroggsKilled();
        froggsCounter.text = string.Format("{0:D2}", currentFroggs);
    }
	public void OnPineappleCollected()
	{
        currentPineapples = playerPickupSystem.GetPineapplesCollected();
		pineapplesCounter.text = string.Format("{0:D2}", currentPineapples);
    }
}
