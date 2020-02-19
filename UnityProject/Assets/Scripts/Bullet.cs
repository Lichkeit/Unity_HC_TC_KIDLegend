
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    /// <summary>
    /// true 代表是玩家子彈.flase  代表敵人的子彈
    /// </summary>
    public bool playerBullet;



    /// <summary>
    /// 有勾選 IsTrigger  物件
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (!playerBullet)           //如果子彈是敵人的
        {
           if (other.name=="玩家")    //如果碰到.名稱是玩家
           {
            other.GetComponent<Player>().Hit(damage);  //取得玩家.受傷(傷害)
                Destroy(gameObject);
           }

        }
        else
        {
            if (other.GetComponent<Enemy>()&& other.tag == "敵人")    //如果碰到.名稱是玩家
            {
                other.GetComponent<Enemy>().Hit(damage);  //取得玩家.受傷(傷害)
                Destroy(gameObject);
            }
        }
    }
}
