using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 5f;
    public float pauseDuration = 2f;
    [SerializeField] private Animator animator;

    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingToStart = false;
    private Coroutine movement;

    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(startPos.x + distance, startPos.y, startPos.z);

        movement = StartCoroutine(MoveBackAndForth());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !PlayerMovement.isGrounded)
        {
            StopCoroutine(movement);
            StartCoroutine(DestroyAfterDelay());
        }
    }

    IEnumerator MoveBackAndForth()
    {
        while (true)
        {
            // Move towards the target
            Vector3 target = movingToStart ? startPos : endPos;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            // Check if we reached the target
            if (transform.position == target)
            {
                // Wait for a bit before moving in the opposite direction
                movingToStart = !movingToStart;
                yield return new WaitForSeconds(pauseDuration);
            }
            yield return null;
        }
    }

    private IEnumerator DestroyAfterDelay()
    {
        // Wait for 2 seconds before destroying the GameObject
        animator.SetBool("destroyed", true);
        yield return new WaitForSeconds(.3f);

        // Your destruction logic here
        Destroy(gameObject);
    }
}
