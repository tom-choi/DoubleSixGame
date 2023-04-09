using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private Transform _target;
    [SerializeField] private bool _isMouseControlEnabled = false;
    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _isMouseControlEnabled = !_isMouseControlEnabled;
            Cursor.visible = !_isMouseControlEnabled;
            Cursor.lockState = _isMouseControlEnabled ? CursorLockMode.Locked : CursorLockMode.None;
        }

        if (_isMouseControlEnabled)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            Vector3 newRotation = transform.eulerAngles + new Vector3(-mouseY, mouseX, 0);
            transform.eulerAngles = newRotation;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Rotate the input vector by the camera's eulerAngles
        Vector3 rotatedInput = Quaternion.Euler(transform.eulerAngles) * new Vector3(horizontalInput, 0, verticalInput);

        Vector3 newPosition = transform.position + rotatedInput * _speed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, -10f, 10f);
        newPosition.z = Mathf.Clamp(newPosition.z, -10f, 10f);

        transform.position = newPosition;
    }
}