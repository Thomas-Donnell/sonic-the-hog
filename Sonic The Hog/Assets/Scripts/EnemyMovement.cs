using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 5f;
    public float pauseDuration = 2f;

    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingToStart = false;

    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(startPos.x + distance, startPos.y, startPos.z);
        StartCoroutine(MoveBackAndForth());
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
}
