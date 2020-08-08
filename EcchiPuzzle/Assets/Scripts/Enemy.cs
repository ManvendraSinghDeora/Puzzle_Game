using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int max_Health;
    int current_Health;

    void Start()
    {
        max_Health = 30;
        current_Health = max_Health;
    }

    public void TakeDamage(int damage)
    {
        current_Health -= damage;
        if(current_Health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        print("Lmao,Noob Died");
        Destroy(gameObject);
    }

}
