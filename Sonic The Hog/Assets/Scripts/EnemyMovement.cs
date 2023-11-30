using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 5f;
    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingToStart = false;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + new Vector3(distance, 0, 0);
    }

    void Update()
    {
        MoveEnemy();
    }

    public void MoveEnemy()
    {
        Vector3 target = movingToStart ? startPos : endPos;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            movingToStart = !movingToStart;
            endPos = new Vector3(startPos.x + (movingToStart ? -distance : distance), startPos.y, startPos.z);
        }
    }
}
