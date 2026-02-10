using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;
    
    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 8f;

    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 moveDirection;

    void Awake()
    {
        InitRigidbody();
    }

    void Update()
    {
        ReadInputs();
        CalculateMoveDirection();
    }

    void FixedUpdate()
    {
        ApplyMovement();
        ApplyRotation();
    }

    private void InitRigidbody()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void ReadInputs()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveInput = new Vector3(horizontal, 0f, vertical);
    }

    private void CalculateMoveDirection()
    {
        moveDirection = moveInput.normalized;
    }

    private void ApplyMovement()
    {
        Vector3 velocity = rb.linearVelocity;
        Vector3 targetVelocity = moveDirection * moveSpeed;

        rb.linearVelocity = new Vector3(
            targetVelocity.x,
            velocity.y,
            targetVelocity.z
        );
    }

    private void ApplyRotation()
    {
        if (moveDirection.sqrMagnitude > 0.001f)
            return;
        
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        Quaternion newRotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        
        rb.MoveRotation(newRotation);
    }
}