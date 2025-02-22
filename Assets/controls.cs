using UnityEngine;
using UnityEngine.InputSystem;

public class controls : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 200f;
    private Vector3 movementInput;
    private Vector2 rotationInput;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Update movement input
        // This should be connected to the Input Actions configured earlier
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        movementInput = new Vector3(input.x, 0, input.y);
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        rotationInput = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        MoveDrone();
        RotateDrone();
    }

    void MoveDrone()
    {
        Vector3 move = transform.forward * movementInput.z + transform.right * movementInput.x;
        rb.AddForce(move * speed);
    }

    void RotateDrone()
    {
        float yaw = rotationInput.x * rotationSpeed * Time.fixedDeltaTime;
        transform.Rotate(0, yaw, 0);
    }
}
