using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameSceneManage gameSceneManage;
    [SerializeField] private SpriteRenderer spriteRenderer; // Assign this in the inspector.
    [SerializeField] private BoxCollider2D boxCollider;
    private bool invincible = false;
    [SerializeField] private float blinkTime = 1f;
    [SerializeField] private float blinkInterval = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (gameSceneManage != null && !invincible)
            {
                invincible= true;
                boxCollider.enabled = false;
                StartCoroutine(BlinkAndRestart(blinkTime, blinkInterval));
            }
            else
            {
                Debug.LogError("GameSceneManage is not assigned on " + gameObject.name);
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
        boxCollider.enabled = true;
    }
}
