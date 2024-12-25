using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{

    public float verticalSpeedMultiplier = 5f;
    public float horizontalSpeedMultiplier = 3f;

    Rigidbody _rigidbody;
    [SerializeField] Animator animator;

    Vector3 _movement;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {

    }

    void Move()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("Punch");
        }


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        float horizontalSpeed = horizontal * horizontalSpeedMultiplier;
        float verticalSpeed;
        if (vertical > 0)
        {
            verticalSpeed = vertical * verticalSpeedMultiplier;
        }
        else
        {
            verticalSpeed = vertical * horizontalSpeedMultiplier;
        }
        _movement = new Vector3(horizontalSpeed, 0.0f, verticalSpeed);
        _rigidbody.velocity = _movement;

    }
}
