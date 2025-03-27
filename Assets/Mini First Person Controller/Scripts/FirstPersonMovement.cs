using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    private Animator animator;
    private Rigidbody rigidbody;

    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    void Awake()
    {
        // Lấy Animator từ con thay vì từ chính nó
        animator = GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        if (animator == null)
        {
            Debug.LogError("Animator not found in child objects!");
        }
    }

    void FixedUpdate()
    {
        // Kiểm tra xem có nhấn phím chạy không
        IsRunning = canRun && Input.GetKey(runningKey);

        // Lấy tốc độ di chuyển
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Nhận giá trị di chuyển từ input
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        bool isMoving = moveX != 0 || moveY != 0;

        // Vector vận tốc di chuyển
        Vector2 targetVelocity = new Vector2(moveX * targetMovingSpeed, moveY * targetMovingSpeed);

        // Áp dụng di chuyển
        rigidbody.linearVelocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.linearVelocity.y, targetVelocity.y);

        // Cập nhật Animator nếu tìm thấy
        if (animator != null)
        {
            animator.SetBool("isMoving", isMoving);
            animator.SetBool("isRunning", IsRunning);
            animator.SetFloat("speed", targetMovingSpeed);
        }
    }
}
