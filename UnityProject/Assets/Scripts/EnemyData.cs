
using UnityEngine;

//腳本化物件 ScriptableObject : 將此腳本的資料儲存為物件並放在 Project 內

    [CreateAssetMenu(fileName ="怪物資料",menuName ="YAO/怪物")]
public class EnemyData : ScriptableObject
{
    [Header("血量"), Range(10,3000)]
    public float hp;
    [Header("攻擊力"), Range(10, 1000)]
    public float attack;
    [Header("攻擊冷卻時間"), Range(0, 5)]
    public float cd;
    [Header("移動速度"), Range(0, 1000)]
    public float speed;
    [Header("停止距離"), Range(0, 1000)]
    public float stopDistance;


}
