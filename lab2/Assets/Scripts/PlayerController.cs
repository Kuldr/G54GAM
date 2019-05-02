using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool canJump = true;
    int groundMask = 1 << 8;
    bool isIdle;
    bool isLeft;
    int isIdleKey = Animator.StringToHash("isIdle");

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Animator a = GetComponent<Animator>();
        a.SetBool(isIdleKey, isIdle);

        SpriteRenderer r = GetComponent<SpriteRenderer>();
        r.flipX = isLeft;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isIdle = true;

        // the new velocity to apply to the character
        Vector2 physicsVelocity = Vector2.zero;
        Rigidbody2D r = GetComponent<Rigidbody2D>();

        // move to the left
        if( Input.GetKey(KeyCode.A)) {
            physicsVelocity.x -= 2;
            isIdle = false;
            isLeft = true;

        }
        // move to the right
        if (Input.GetKey(KeyCode.D))
        {
            physicsVelocity.x += 2;
            isIdle = false;
            isLeft = false;
        }
        // Jump if allowed
        if( Input.GetKey(KeyCode.W) && canJump) {
            r.velocity = new Vector2(physicsVelocity.x, 8);
            canJump = false;
            isIdle = false;
        }

        // Test the ground immediately below the player and if it tagged as
        // ground layer, then allow the player to jump again
        if( Physics2D.Raycast(new Vector2(transform.position.x - 0.1f, transform.position.y), -Vector2.up, 2.0f, groundMask)) {
            canJump = true;
        }

        // apply the updated velocity to the rigid body
        r.velocity = new Vector2(physicsVelocity.x, r.velocity.y);
    }
}
