
using UnityEngine;
using System.Collections;

public class EnemyFar : Enemy
{
    [Header("子彈")]
    public GameObject bullet;

    protected override void Attack()
    {
        base.Attack();
        StartCoroutine(CreateBullet());

    }

    /// <summary>
    /// 產生子彈物件
    /// </summary>
    /// <returns></returns>
    private IEnumerator CreateBullet()
    {
        yield return new WaitForSeconds(data.nearAttackDelay);                         //等待

        Vector3 pos = transform.position + new Vector3(0, data.nearAttackPos.y, 0);    //累加Y軸
        pos += transform.forward * data.nearAttackPos.z;                               //累加Z軸

        GameObject temp=Instantiate(bullet, pos, transform.rotation);                  //生成子彈
        temp.GetComponent<Rigidbody>().AddForce(transform.forward * data.farPower);    //推出子彈

        temp.AddComponent<Bullet>();                                                   //添加元件<泛型>
        temp.GetComponent<Bullet>().damage = data.attack;                              //設定子彈傷害=資料.攻擊力
    }
}
