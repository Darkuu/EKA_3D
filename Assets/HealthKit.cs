using UnityEngine;

public class HealthKit : MonoBehaviour
{
    [SerializeField] private int healAmount = 9999; // I want the player to fully heal, so i set it to a very big number.
    [SerializeField] private bool destroyOnPickup = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.HealToFull();
                Debug.Log("Health kit picked up!");

                if (destroyOnPickup)
                    Destroy(gameObject);
            }
        }
    }
}
