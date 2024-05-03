using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditCombat : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public LayerMask playerLayer;

    private float _nextAtkTime = 0f;
    private bool _playerInRange = false;
    private BanditStats _banditStats;
    
    void Start() 
    {
        _banditStats = GetComponent<BanditStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= _nextAtkTime && _playerInRange) {
            Attack();
            _nextAtkTime = Time.time + 1f / _banditStats.atkRate;
        }
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }

    public void Hit()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, _banditStats.attackRange, playerLayer);
        foreach(Collider2D player in hitPlayer) {
            if(!(player is BoxCollider2D)) {
                Debug.Log("Player has been hit !");
                player.GetComponent<PlayerStats>().TakeDamage(_banditStats.atkDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null) {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, _banditStats.attackRange);   
    }

    public void SetIsPlayerInRange(bool inRange) {
        _playerInRange = inRange;
    }
}
