using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif


[ExecuteInEditMode]
public class Grid : MonoBehaviour
{
    public int gridSize = 10;
    public float gridSpacing = 1;

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                Vector3 point = new Vector3(x * gridSpacing, 0, z * gridSpacing);
                Collider[] colliders = Physics.OverlapSphere(point, 0.5f);
                if (colliders.Length > 1)
                {
                    Gizmos.color = Color.red;
                }
                else
                {
                    Gizmos.color = Color.grey;
                }
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }
    #endif
}
