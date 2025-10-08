using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    public float speed = 5f;
    private Transform target;
    private Vector3 nextPosition;
    public float minDistance = 0.1f;
    private Rigidbody2D rb;
    private int isIdleId;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = PointA;
        anim = GetComponentInChildren<Animator>();
        isIdleId = Animator.StringToHash("isIdle");
    }

    void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("IdleDragon"))
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        Vector2 direction = (target.position - transform.position).normalized;
        if (Vector2.Distance(transform.position, target.position) < minDistance)
        {
            anim.SetTrigger(isIdleId);
            target = target == PointA ? PointB : PointA;
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        rb.linearVelocity = direction * speed;
    }

    private void OnDrawGizmos()
    {
        if (PointA != null && PointB != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(PointA.position, PointB.position);
        }
    }
}
