
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;


    /// <summary>
    /// 有勾選 IsTrigger  物件
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="玩家")    //如果碰到.名稱是玩家
        {
            other.GetComponent<Player>().Hit(damage);  //取得玩家.受傷(傷害)
        }
    }
}
