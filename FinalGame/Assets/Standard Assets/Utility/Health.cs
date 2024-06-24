using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthPoints = 100f;

    public void TakeDamage(float amount)
    {
        healthPoints -= amount;
        if (healthPoints <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // Add death logic here (e.g., disable the game object, play an animation, etc.)
        Debug.Log(transform.name + " died.");
        gameObject.SetActive(false);
    }
}

