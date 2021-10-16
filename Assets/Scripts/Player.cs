using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public UI ui;

    public SpriteRenderer sr;

    public float moveSpeed;
    public Rigidbody2D rig;
    public float jumpForce;

    public int score;

    // It is recommended by Unity that you write your physics code inside of
    // the FixedUpdate function, as it is frame-rate independent and useful
    // for physics calculations.
    private void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(xInput * moveSpeed, rig.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && IsGrounded())
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if(rig.velocity.x > 0)
        {
            // move right
            sr.flipX = false;
        }
        else if(rig.velocity.x < 0)
        {
            // move left
            sr.flipX = true;
        }

        if (transform.position.y <= -12)
            GameOver();
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.1f, 0), Vector2.down, 0.2f);
        return hit.collider != null;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount)
    {
        score += amount;
        ui.SetScoreText(score);
    }
}
