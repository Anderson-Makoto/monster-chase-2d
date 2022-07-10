using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    public float jumpForce = 11f;
    private float movementX;
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded = true;

    private const string WALK_ANIMATION = "Walk";
    private const string GROUND_TAG = "Ground";
    private const string GHOST_TAG = "Ghost";
    private const string ENEMY_1_TAG = "Enemy 1";
    private const string ENEMY_2_TAG = "Enemy 2";
    private const int MAX_X = 57;
    private const int MIN_X = -57;

    void Awake() 
    {
        this.rigidbody2d = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {}

    void Update()
    {
        this.animate();
        this.walk();
        this.jump();
    }

    private void walk() 
    {
        this.movementX = Input.GetAxisRaw("Horizontal");
        if (this.transform.position.x >= MAX_X && this.movementX == 1) {
            return;
        }  
        if (this.transform.position.x <= MIN_X && this.movementX == -1) {
            return;
        }  
        float posX = this.transform.position.x;

        posX += this.movementX * this.moveForce * Time.deltaTime;
        Vector2 currentPos = new Vector2(posX, this.transform.position.y);
        this.transform.position = currentPos;
    }

    private void animate() 
    {
        if (this.movementX > 0) 
        {
            this.animator.SetBool(WALK_ANIMATION, true);
            this.spriteRenderer.flipX = false;
        } else if (this.movementX < 0) 
        {
            this.animator.SetBool(WALK_ANIMATION, true);
            this.spriteRenderer.flipX = true;
        } else 
        {
            this.animator.SetBool(WALK_ANIMATION, false);
        }
        
    }

    private void jump() 
    {
        bool jumpKey = Input.GetButtonDown("Jump");
        if (jumpKey && this.isGrounded) {
            this.isGrounded = false;
            this.rigidbody2d.AddForce(new Vector2(0f, this.jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2d)
    {
        if (collision2d.gameObject.CompareTag(GROUND_TAG))
        {
            this.isGrounded = true;
        }

        List<string> enemies = new List<string>();
        enemies.Add(ENEMY_1_TAG);
        enemies.Add(ENEMY_2_TAG);
        enemies.Add(GHOST_TAG);

        if (enemies.Contains(collision2d.gameObject.tag))
        {
            Destroy(this.gameObject);
        }
    }
}
