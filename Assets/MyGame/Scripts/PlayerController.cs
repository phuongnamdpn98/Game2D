using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
[AddComponentMenu("DangNam/PlayerController")]
public class PlayerController : MonoBehaviour
{
    [Header("Player Setting")]
    public LayerMask groundLayer;
    public float moveSpeed = 5f;
    public float jumpforce = 10f;
    public Transform groundCheck;
    public float radius = 0.2f;
    private Rigidbody2D rb;
    private bool facingRight = true;

    private Animator anim;
    private int isWalkId;
    private int isJumpId;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        isWalkId = Animator.StringToHash("isWalk");
        isJumpId = Animator.StringToHash("isJump");
    }

    void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.Space) && IsGround())
        {
            StartCoroutine(Jump());
        }

    }

    private IEnumerator Jump()
    {
        anim.SetTrigger(isJumpId);
        yield return new WaitForSeconds(0.3f);
        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);

    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
        if((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            Flip();
        }
        if(math.abs(rb.linearVelocity.x) > 0.1f)
        {
            anim.SetBool(isWalkId, true);
        }
        else
        {
            anim.SetBool(isWalkId, false);

        }
    }

    bool FaceRight()
    {
        return facingRight;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    bool IsGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, radius, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }
}
