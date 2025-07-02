using UnityEngine;

public class BabyFire : Collectible
{
    protected override void Collect(GameObject player)
    {
        PickupSystem playerPickupSystem = player.GetComponent<PickupSystem>();

        if (playerPickupSystem != null)
        {
            playerPickupSystem.PickupBabyFire();
            Debug.Log("Есть! бейбифаер");
        }
        else
        {
            //Debug.LogWarning("Скрипт PickupSystem не найден на игроке!");
        }

        if (collectEffect != null)
        {
            Instantiate(collectEffect, transform.position, Quaternion.identity);
        }

        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
