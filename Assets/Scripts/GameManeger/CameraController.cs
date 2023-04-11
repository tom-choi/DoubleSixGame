using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _maxJumpTime = 0.3f;

    private bool isMouseControlEnabled;
    private bool UsingMouseControl
    {
        get => isMouseControlEnabled;
        set
        {
            isMouseControlEnabled = value;
            Cursor.visible = !value;
            Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }

    private void HandleMouseMovement()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 newRotation = transform.eulerAngles + new Vector3(-mouseY, mouseX, 0);
        if (newRotation.x < 180)
            newRotation.x = Mathf.Min(newRotation.x, 89);
        if (newRotation.x >= 180)
            newRotation.x = Mathf.Max(newRotation.x, 271);
        transform.eulerAngles = newRotation;
    }

    private void HandleKeyboardMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 flattenedForward = transform.forward;
        flattenedForward.y = 0;
        flattenedForward.Normalize();

        Vector3 forward = _speed * Time.deltaTime * verticalInput * flattenedForward;
        Vector3 right = _speed * Time.deltaTime * horizontalInput * transform.right;

        Vector3 newPosition = transform.position + forward + right;
        if (Input.GetKey(KeyCode.Space))
        {
            newPosition.y += _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            newPosition.y -= _speed * Time.deltaTime;
        }

        newPosition.x = Mathf.Clamp(newPosition.x, -10, 10);
        newPosition.z = Mathf.Clamp(newPosition.z, -10, 10);

        transform.position = newPosition;
    }

    private void LateUpdate()
    {
        if (UsingMouseControl && Input.GetKeyDown(KeyCode.Escape))
        {
            UsingMouseControl = false;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UsingMouseControl = !UsingMouseControl;
        }

        if (UsingMouseControl)
        {
            HandleMouseMovement();
        }

        HandleKeyboardMovement();
    }
}