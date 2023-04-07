using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private Transform _target;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void LateUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 newPosition = transform.position + new Vector3(horizontalInput, 0, verticalInput) * _speed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, -10f, 10f);
        newPosition.z = Mathf.Clamp(newPosition.z, -10f, 10f);

        transform.position = newPosition;
        // transform.position = Vector3.Lerp(transform.position, newPosition + _offset, Time.deltaTime * 10f);
        
    }
}