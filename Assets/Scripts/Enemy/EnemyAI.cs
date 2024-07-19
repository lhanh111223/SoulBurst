using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    public Transform player;
    public float moveSpeed = 5.0f;
    public float attackRange = 1.0f; // Khoảng cách để bắt đầu tấn công

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();

            // Thay đổi hướng của nhân vật địch
            if (player.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }

    void MoveTowardsPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > attackRange)
        {
            // Di chuyển tới người chơi
            _anim.SetBool("isMoving", true);
            _anim.SetBool("isAttack", false);
            Vector2 direction = (player.position - transform.position).normalized;
            _rb.MovePosition((Vector2)transform.position + direction * moveSpeed * Time.deltaTime);
        }
        else
        {
            // Tấn công người chơi
            _anim.SetBool("isMoving", false);
            _anim.SetBool("isAttack", true);
        }
    }
}
