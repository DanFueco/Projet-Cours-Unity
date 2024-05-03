using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator anim;
    public Transform attackPoint;
    float nextAtkTime = 0f;
    public LayerMask enemyLayers;

    private PlayerStats _playerStats;

    void Start()
    {
        _playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAtkTime) {
            if(Input.GetKeyDown(KeyCode.E)) {
                Attack();
                nextAtkTime = Time.time + 1f / _playerStats.atkRate;
            }
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, _playerStats.attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies) {
            if(!(enemy is BoxCollider2D)) {
                enemy.GetComponent<BanditStats>().TakeDamage(_playerStats.atkDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null) {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, _playerStats.attackRange);   
    }
}
