// //道具類別
// public class Prop
// {
//     //道具id
//     public int id; 
//     //道具名稱
//     public string name; 
//     //道具描述
//     public string desc; 
//     //道具圖片
//     public Sprite icon;  
//     //道具性質標籤,多標籤以空格隔開
//     public string tag; 
//     //是否已解鎖
//     public bool isUnlock;
//     //解鎖條件
//     public string condition; 
// }
// //道具資料庫
// public class PropDB
// {
//     //道具列表
//     public List<Prop> props; 
//     //通過id獲取道具
//     public Prop GetPropByID(int id)
//     {
//         return props.Find(p => p.id == id);
//     }
//     //...更多方法
// }