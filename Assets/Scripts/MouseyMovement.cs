using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseyMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 mMovement;
    private InputAction mMovementAction;

    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mMovementAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        GetInputs();
    }

    private void FixedUpdate()
    {
        if (mMovementAction.IsPressed())
        {
            Movement();
        }
    }

    private void Movement()
    {
        //Vector3 wantedPosition = transform.position + (transform.forward * mMovement.y * moveSpeed * Time.deltaTime);
        //rb.MovePosition(wantedPosition);
        Vector3 wantedPosition = transform.forward * mMovement.y * moveSpeed * Time.deltaTime;
        rb.linearVelocity = (wantedPosition);

        Quaternion wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * (mMovement.x * turnSpeed * Time.deltaTime));
        rb.MoveRotation(wantedRotation);
    }

    private void GetInputs()
    {
        mMovement = mMovementAction.ReadValue<Vector2>();
    }
}
