using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool invincible = false;
    [SerializeField] private float blinkTime = 1f;
    [SerializeField] private float blinkInterval = 0.1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!invincible)
            {
                invincible= true;
                GameManager.instance.LoseLife();
                StartCoroutine(BlinkAndRestart(blinkTime, blinkInterval));
            }
        }
    }

    private IEnumerator BlinkAndRestart(float duration, float interval)
    {
        float time = 0;
        bool visible = true;

        // Disable the collider so the player doesn't trigger multiple collisions.
        
        // Blinking effect
        while (time < duration)
        {
            // Toggle visibility
            spriteRenderer.enabled = visible;
            visible = !visible;

            // Wait for a bit before the next toggle
            yield return new WaitForSeconds(interval);

            time += interval;
        }

        // Make sure the sprite is visible before restarting
        spriteRenderer.enabled = true;
        invincible = false;
    }
}
