using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadEnemy : MonoBehaviour
{
    public Collider2D enemyColl;
    public Bird_Script enemy;
    public PlayerController player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemyColl.enabled = false;
            enemy.isHead = true;
            player.EnemyDestroy();

        }
    }
}
