using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameSceneManage gameSceneManage;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float blinkTime = 1f;
    [SerializeField] private float blinkInterval = 0.1f;
    [SerializeField] private float bounceForce = 5f; // Force for bouncing back
    private bool isBlinking = false;
    private int collisionCount = 0; // Track the number of collisions with enemies

    void Start()
    {
        if (!spriteRenderer) spriteRenderer = GetComponent<SpriteRenderer>();
        if (!gameSceneManage) gameSceneManage = FindObjectOfType<GameSceneManage>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!isBlinking)
            {
                collisionCount++;
                BounceBack(collision);
                StartCoroutine(Blink(blinkTime, blinkInterval));

                if (collisionCount >= 2) // Check if Sonic hit an enemy twice
                {
                    DieAndRestart();
                }
            }
        }
    }

    private void BounceBack(Collision2D collision)
    {
        if (collision.contactCount > 0)
        {
            Vector2 collisionNormal = collision.contacts[0].normal;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Apply a more pronounced upward force
                Vector2 bounceDirection = new Vector2(-collisionNormal.x, 1).normalized;
                rb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
            }

            // Temporarily disable player movement
            PlayerMovement playerMovement = GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.DisableMovementTemporarily(0.5f); // Disable for 0.5 second
            }
        }
    }


    private IEnumerator Blink(float duration, float interval)
    {
        isBlinking = true;
        float time = 0;
        bool visible = true;

        while (time < duration)
        {
            spriteRenderer.enabled = visible;
            visible = !visible;
            yield return new WaitForSeconds(interval);
            time += interval;
        }

        spriteRenderer.enabled = true;
        isBlinking = false;
    }

    private void DieAndRestart()
    {
        // Logic to handle Sonic's death and restart the level
        gameSceneManage.RestartGame(); // Assuming RestartGame() is defined in GameSceneManage
    }
}