using System.Collections.Generic;
using UnityEngine;


public class RayCasterCam : MonoBehaviour
{
    public List<GameObject> targets; // 选中的游戏对象
    public List<GameObject> loseFocus; // 失焦的游戏对象
    private RaycastHit hit; // 碰撞信息
    public Material OutlineEffect;
 
    private void Start() {
        targets = new List<GameObject>();
        loseFocus = new List<GameObject>();
        hit = new RaycastHit();
    }
 
    private void Update() {
        if (Input.GetMouseButtonUp(0)) 
        {
            GameObject hitObj = GetHitObj();
            if (hitObj == null) 
            { 
                // 未选中任何物体, 已选中的全部取消选中
                targets.ForEach(obj => loseFocus.Add(obj));
                targets.Clear();
            }
            else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) 
            {
                if (targets.Contains(hitObj)) 
                { // Ctrl重复选中, 取消loseFocus
                    loseFocus.Add(hitObj);
                    targets.Remove(hitObj);
                } 
                else 
                { // Ctrl追加
                    targets.Add(hitObj);
                }
            } 
            else 
            { // 单选
                targets.ForEach(obj => loseFocus.Add(obj));
                targets.Clear();
                targets.Add(hitObj);
                loseFocus.Remove(hitObj);
            }
            // do sth
            DoSth();
            ClearMyLoseFocus();
        }
    }
    private void DoSth()
    {
        TabMenu tabMenu = GameObject.Find("TabMenu").GetComponent<TabMenu>();
        if (targets.Count == 1 && targets[0].name == "Player")
        {
            tabMenu.TabFlag = true;
        }
    }
 
    private void ClearMyLoseFocus() 
    { 
        // Clear
        loseFocus.Clear();
    }
 
    private GameObject GetHitObj() 
    { // 获取屏幕射线碰撞的物体
        // Get the camera component attached to this game object
        Camera cam = GetComponent<Camera>();

        // Cast a ray from the center of the screen
        //Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        // Check for collisions with objects in the scene
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            return hit.collider.gameObject;
        }
        return null;
    }
}