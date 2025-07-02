using UnityEngine;

public class Pineapple : Collectible
{
    [SerializeField] private float hungerRestoration = 30f;
    protected override void Collect(GameObject player)
    {
        PickupSystem playerPickupSystem = player.GetComponent<PickupSystem>();
        HungerSystem playerHungerSystem = player.GetComponent<HungerSystem>();

        if (playerPickupSystem != null && playerHungerSystem != null)
        {
            playerPickupSystem.PickupPineapple();
            playerHungerSystem.RestoreHunger(hungerRestoration);
        }
        else
        {
            //Debug.LogWarning("Скрипт PickupSystem или HungerSystem не найден на игроке!");
        }

        if (collectEffect != null)
        {
            Instantiate(collectEffect, transform.position, Quaternion.identity);
        }

        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
