using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Animator anim;
    public int maxHealth = 50;
    public int currentHealth;
    public float attackRange = 0.9f;
    public int atkDamage = 7;
    public float atkRate = 2f;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;        
    }

    void Update()
    {
        if (currentHealth <=0) {
            Debug.Log("Player is dead !");
        }
    }

    public void TakeDamage(int damage) {
        anim.SetTrigger("Hurt");
        currentHealth -= damage;
    }
}
