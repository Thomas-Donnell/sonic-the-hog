using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("References")]
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;

    [Header("Settings")]
    public float speed = 1.5f;
    public float closeEnoughDistance = 0.1f;

    private Vector2 currentTarget;

    private void Start()
    {
        // Initially set the target to the end point.
        SetTarget(endPoint.position);
    }

    private void FixedUpdate()
    {
        // Move the platform towards the target
        platform.position = Vector2.MoveTowards(platform.position, currentTarget, speed * Time.deltaTime);

        // If the platform is close enough to the target, switch targets
        if (Vector2.Distance(platform.position, currentTarget) <= closeEnoughDistance)
        {
            SwitchTarget();
        }
    }

    /// <summary>
    /// Switches the platform's movement target between start and end points.
    /// </summary>
    private void SwitchTarget()
    {
        if (currentTarget == (Vector2)startPoint.position)
        {
            SetTarget(endPoint.position);
        }
        else
        {
            SetTarget(startPoint.position);
        }
    }

    /// <summary>
    /// Sets the current movement target.
    /// </summary>
    /// <param name="target">New target position.</param>
    private void SetTarget(Vector2 target)
    {
        currentTarget = target;
    }

    private void OnDrawGizmos()
    {
        if (platform != null && startPoint != null && endPoint != null)
        {
            Gizmos.color = Color.green; // Use different colors to differentiate between the lines.
            Gizmos.DrawLine(platform.position, startPoint.position);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(platform.position, endPoint.position);
        }
    }


}
