using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditStats : MonoBehaviour
{

    public Animator anim;
    public float speed = 4f;
    public int maxHealth = 25;
    public int currentHealth;
    public float attackRange = 0.6f;
    public int atkDamage = 5;
    public float atkRate = 2f;

    private float timeDeath = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0) {
            Die();
        }
    }

    public void TakeDamage(int damage) {
        anim.SetTrigger("Hurt");
        currentHealth -= damage;
    }

    private void Die() {
        anim.SetBool("IsDead", true);
        GameManager.Instance.AddKill();

        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        foreach(Collider2D collider in colliders) {
            collider.enabled = false;
        }

        Invoke("DestroyThisGameObject", timeDeath);
        this.enabled = false;
    }

    private void DestroyThisGameObject(){
        Destroy(gameObject);
    }

}
    
