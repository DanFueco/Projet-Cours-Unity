using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public Animator anim;
    private PlayerStats _playerStats;
    private Rigidbody2D _rb;
    Vector2 movement;
    private float _scaleX;
    private float _scaleY;

    // Start is called before the first frame update
    void Start()
    {
        _playerStats = GetComponent<PlayerStats>();
        _rb =  GetComponent<Rigidbody2D>();
        _scaleX = transform.localScale.x;
        _scaleY = transform.localScale.y;
    }

    float horizontalMove = 0;
    float verticalMove = 0;
    bool isMovingHorizontal = false;
    bool isMovingVertical = false;

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(KeyCode.RightArrow)) {
            transform.localScale = new Vector2(_scaleX,_scaleY);
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.localScale = new Vector2(-_scaleX,_scaleY);
        }

        horizontalMove = movement.x * _playerStats.speed;
        verticalMove = movement.y * _playerStats.speed;

        isMovingHorizontal = horizontalMove != 0;
        isMovingVertical = verticalMove != 0;

        anim.SetFloat("Speed", Mathf.Abs(isMovingHorizontal ? horizontalMove : isMovingVertical ? verticalMove : 0));
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + movement * _playerStats.speed * Time.fixedDeltaTime);
    }

}
