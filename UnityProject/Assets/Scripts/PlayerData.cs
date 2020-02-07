
using UnityEngine;

[CreateAssetMenu(fileName ="玩家資料",menuName ="YAO/玩家資料")]
public class PlayerData : ScriptableObject
{



    [Header("血量與最大血量")]
    [Range(200, 3000)]
    public float hp = 200;

    public float hpMax;

    [Header("血量與最大血量"), Range(0, 1)]
    public float cd = 0.8f;
    [Header("武器速度"), Range(100, 5000)]
    public float power = 500;





}
