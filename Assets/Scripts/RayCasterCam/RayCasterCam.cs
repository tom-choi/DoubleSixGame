using UnityEngine;

public class RayCasterCam : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    public string Shoot()
    {
        // Get the camera component attached to this game object
        Camera cam = GetComponent<Camera>();

        // Cast a ray from the center of the screen
        //Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        // Check for collisions with objects in the scene
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Return the name of the game object that was hit
            Debug.Log(hit.collider.gameObject.name);
            return hit.collider.gameObject.name;
        }

        // If no collision was detected, return null
        return null;
    }
}