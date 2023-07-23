using UnityEngine;

public class Drag : MonoBehaviour
{
    public GameObject virtualObject;

    void Update()
    {
        // Check if there is an object at y = 0
        if (!Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity))
        {
            // Move the virtualObject to the integer coordinates (x, 0, z)
            int x = Mathf.FloorToInt(transform.position.x);
            int z = Mathf.FloorToInt(transform.position.z);
            Vector3 cubePosition = new Vector3(x, 0, z);
            virtualObject.transform.position = cubePosition;
            virtualObject.SetActive(true);
        }
        else
        {
            // Destroy the virtual object if there is an object at y = 0
            virtualObject.SetActive(false);
        }
    }
}