
using UnityEngine;
using System.Collections;

public class EnemyNear : Enemy
{
    /// <summary>
    /// 繪製圖示:在場景面板內繪製圖示方便編輯
    /// </summary>
    private void OnDrawGizmos()
    {

        //圖示.顏色=顏色
        Gizmos.color = Color.red;

        //圖示.繪製射線(中心線,方向)

        //前方 transform.forward
        //右方 transform.right
        //上方 transform.up
        Gizmos.DrawRay(transform.position+data.nearAttackPos, transform.forward*data.nearAttackLength);
    }

    protected override void Attack()
    {
        base.Attack();

        StartCoroutine(DelayAttack());
    }


    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(data.nearAttackDelay);
        RaycastHit hit; //區域變數 接受射線碰到的資訊(碰撞資訊)

        //參數修飾詞:out 將方法內的資料保存在區域變數內

        //物理.射線碰撞(中心點,方向,碰撞資訊,長度)
        if (Physics.Raycast(transform.position + data.nearAttackPos, transform.forward ,out hit,data.nearAttackLength))
        {
            print("打到的物件:" + hit.collider.name);
        }
    }

}
