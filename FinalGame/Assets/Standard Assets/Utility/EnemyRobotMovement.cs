// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemyRobotMovement : MonoBehaviour
// {
//     private Animator animator;
//     private Rigidbody rb;
//     public GameObject explosion;
//     public GameObject player; // Reference to the Player GameObject
//     public float moveSpeed = 2f; // Adjusted move speed for EnemyRobot
//     public float damage = 10f;
//     public float health = 20f;  // Health of the EnemyRobot

//     public GameObject MainPlayer;

//     void Start()
//     {
//         animator = GetComponent<Animator>();
//         rb = GetComponent<Rigidbody>();

//         // Find the Player GameObject using its tag
//         player = GameObject.FindGameObjectWithTag("Player");
//         if (player == null)
//         {
//             Debug.LogError("Player GameObject not found. Make sure the Player has the 'Player' tag assigned.");
//         }
//     }

//     void Update()
//     {
//         if (player == null) return; // Ensure player reference is not null

//         // Calculate distance to player
//         float range = Vector3.Distance(player.transform.position, transform.position);

//         // Rotate to look at player if within 10m
//         if (range < 10)
//         {
//             transform.LookAt(player.transform.position);
//         }

//         // Move towards player if within 5m and not too close (more than 2m away)
//         if (range < 5 && range > 2)
//         {
//             animator.SetBool("isWalking", true);
//             transform.position += transform.forward * moveSpeed * Time.deltaTime;
//         }
//         else
//         {
//             animator.SetBool("isWalking", false);
//         }

//         // Attack if very close (within 2m)
//         if (range < 2)
//         {
//             // Deal damage to player
//             MainPlayer playerComponent = player.GetComponent<MainPlayer>();
//             if (playerComponent != null)
//             {
//                 playerComponent.TakeDamage(damage);
//             }

//             // Explode and destroy the EnemyRobot
//             Explode();
//         }
//     }

//     public void TakeDamage(float amount)
//     {
//         health -= amount;
//         if (health <= 0f)
//         {
//             Explode();
//         }
//     }

//     void Explode()
//     {
//         Instantiate(explosion, transform.position, transform.rotation);
//         Destroy(gameObject);
//     }
// }
