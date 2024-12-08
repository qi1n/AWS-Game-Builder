using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [SerializeField] private float moveSpeed = 1f;
    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer mySpriteRenderer;

    private bool isMoving;

    private Vector2 input;

    private void Awake()
    {
        Instance = this;
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component is missing on the Player GameObject!");
        }
        mySpriteRenderer = GetComponent<SpriteRenderer>();


    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        //Move();
    }

    private void PlayerInput() {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                if (animator != null)
                {
                    animator.SetFloat("moveX", input.x);
                    animator.SetFloat("moveY", input.y);
                }

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;


                StartCoroutine(Move(targetPos));

                    
            }
        }

        animator.SetBool("isMoving", isMoving);

    }

    IEnumerator Move(Vector3 targetPos)
    {
        //rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixed))
        isMoving = true;
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    private void AdjustPlayerFacingDirection() 
    {
        Vector3 mousePos = Input.mousePosition;
        //Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        //if (mousePos.x < playerScreenPoint.x) { 
        //    mySpriteRenderer.flipX = true;
        //}
        //else
        //{
        //    mySpriteRenderer.flipX = false;
        //}

    }
}