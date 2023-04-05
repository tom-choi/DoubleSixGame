using UnityEngine;

[ExecuteInEditMode]
public class Grid : MonoBehaviour
{
    public int gridSize = 10;
    public float gridSpacing = 1;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        
        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                // Color[] rainbowColors = new Color[] { Color.red, Color.yellow, Color.green, Color.blue, Color.cyan, Color.magenta, Color.white };
                // int randomColorIndex = Random.Range(0, rainbowColors.Length);
                // Gizmos.color = rainbowColors[randomColorIndex];

                Vector3 point = new Vector3(x * gridSpacing, 0, z * gridSpacing);
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }
}
