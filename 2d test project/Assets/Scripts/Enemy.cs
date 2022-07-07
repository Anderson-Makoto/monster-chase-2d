using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private readonly float REGULAR_SPEED = 10f;
    private readonly float FAST_SPEED = 15f;
    private readonly string GHOST_TAG = "Ghost";
    private readonly string ENEMY_1_TAG = "Enemy 1";
    private readonly string ENEMY_2_TAG = "Enemy 2";

    private SpriteRenderer spriteRenderer;
    private bool isFirstFrame = true;
    private Rigidbody2D rigidbody2d;
    private float currentSpeed;
    private Collider2D collider2d;

    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.rigidbody2d = GetComponent<Rigidbody2D>();
        this.collider2d = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.walk();
        this.die();
    }

    private void walk()
    {
        if (this.isFirstFrame) {
            if (this.gameObject.tag == this.GHOST_TAG) {
                this.currentSpeed = this.REGULAR_SPEED;
            } else if (this.gameObject.tag == this.ENEMY_1_TAG) {
                this.currentSpeed = this.REGULAR_SPEED;
            } else {
                this.currentSpeed = this.FAST_SPEED;
            }
            if (this.transform.position.x > 0) {
                this.spriteRenderer.flipX = true;
                this.currentSpeed *= (-1);
            }

            this.isFirstFrame = false;
        }

        this.rigidbody2d.velocity = new Vector3(this.currentSpeed, -10f, 0f);
    }

    private void die() {
        if (this.transform.position.y <= -5.5f) {
            Destroy(this.gameObject);
        }
    }
}
