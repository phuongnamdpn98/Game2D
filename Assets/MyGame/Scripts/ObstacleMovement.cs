using UnityEngine;
[AddComponentMenu("DangNam/ObstacleMovement")]
public class ObstacleMovement : MonoBehaviour
{
    [Header("Movement Setting")]
    public Vector2 pointA;
    public Vector2 pointB;
    public float speed = 2f;
    private Vector2 targetPoint;

    void Start()
    {
        targetPoint = pointB;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, targetPoint) < 0.1f)
        {
            targetPoint = targetPoint == pointA ? pointB : pointA;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(pointA, 0.1f);
        Gizmos.DrawSphere(pointB, 0.1f);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pointA, pointB);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(0.5f, 0.5f, 0.5f));
    }
}
