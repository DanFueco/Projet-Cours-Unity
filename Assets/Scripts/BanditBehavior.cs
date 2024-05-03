using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditBehavior : MonoBehaviour
{

    public Animator anim;

    private GameObject _player;
    private BanditStats _banditStats;
    private BanditCombat _banditCombat;
    private Vector3 _playerPosition;
    private float _moveSpeed;
    private float _scaleX;
    private float _scaleY;

    // Start is called before the first frame update
    void Start()
    {
        _banditStats =  GetComponent<BanditStats>();
        _banditCombat = GetComponent<BanditCombat>();
        _moveSpeed = _banditStats.speed;
        _player = GameManager.Instance.player;
        _scaleX = transform.localScale.x;
        _scaleY = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (_banditStats.currentHealth <= 0) {
            return;
        }

        _playerPosition = _player.transform.position;
        Vector2 direction = transform.position - _playerPosition;
        if(direction.x > 0) {
            transform.localScale = new Vector2(_scaleX, _scaleY);
        } else if (direction.x < 0) {
            transform.localScale = new Vector2(-_scaleX, _scaleY);
        }
        transform.position = Vector2.MoveTowards(transform.position, _playerPosition, _moveSpeed * Time.deltaTime);
        anim.SetFloat("Speed", _moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            _moveSpeed = 0;
            _banditCombat.SetIsPlayerInRange(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            _moveSpeed = _banditStats.speed;
            _banditCombat.SetIsPlayerInRange(false);
        }
    }
}
