using UnityEngine;
using UnityEditor;

public class GizmoExample : MonoBehaviour
{
    public float radius = 1f;
    public Color sphereColor = Color.green;
    public Color handleColor = Color.yellow;
    public float handleSize = 0.1f;
    public Vector3 sphereOffset = Vector3.up;

    private void OnDrawGizmos()
    {
        Gizmos.color = sphereColor;
        Gizmos.DrawSphere(transform.position + sphereOffset, radius);

        Handles.color = handleColor;
        Vector3 handlePosition = transform.position + sphereOffset + Vector3.up * radius;
        handlePosition = Handles.PositionHandle(handlePosition, Quaternion.identity);
        sphereOffset = handlePosition - (transform.position + Vector3.up * radius);
    }
}
