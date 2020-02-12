
using UnityEngine;
using UnityEngine.AI;  //引用 人工智慧 API

public class Enemy : MonoBehaviour
{
    [Header("敵人資料")]
    public EnemyData data;                   //每一隻怪物共用

    private Animator ani;
    private NavMeshAgent agent;
    private Transform target;
    private float timer;
    private HpDamageManager HpDamageManager; //血量數值管理器
    private float hp;                        //每一隻怪物獨立



    private void Start()
    {
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = data.speed;
        agent.stoppingDistance = data.stopDistance;
        hp = data.hp;

        target = GameObject.Find("玩家").transform;
        HpDamageManager = GetComponentInChildren<HpDamageManager>();

    }


    private void Update()
    {
        Move();
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        if (ani.GetBool("死亡開關")) return;
        
        //代理器.設定目的地(玩家.座標)
        agent.SetDestination(target.position);


        Vector3 targetPos = target.position; //區域變數 目標座標=玩家.座標
        targetPos.y = transform.position.y;  //目標座標.y=自己.y
        transform.LookAt(targetPos);         //看著

        //remainingDisance 跟目標的距離
        //如果 進入 停止距離範圍內就等待 否則 跑步
        if (agent.remainingDistance<agent.stoppingDistance)
        {
            Wait();
        }
        else
        {
            ani.SetBool("跑步開關", true);
        }
        
    }

    /// <summary>
    /// 等待
    /// </summary>
    private void Wait()
    {
        ani.SetBool("跑步開關", false);  //等待動畫
        timer += Time.deltaTime;         //累加使間

        //print("計時器:" + timer);

        if (timer>=data.cd)             //如果 計時器 >=冷卻時間
        {
            Attack();
        }
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    protected virtual void Attack()
    {
        timer = 0;                        //歸零
        ani.SetTrigger("攻擊觸發");       //攻擊動畫
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage"></param>
    public void Hit(float damage)
    {
        hp -= damage;
        HpDamageManager.UpdateHpBar(hp, data.hpMax);


        //啟動協程(血量傷害值管理器.顯示數值(傷害值 ， - ， 1 ， 白色))
        StartCoroutine(HpDamageManager.ShowValue(damage, "-", Vector3.one, Color.white));

        if (hp <= 0) Dead();
    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        ani.SetBool("死亡開關", true);
        agent.isStopped = true;
        Destroy(this);             //刪除元件  Destroy(GetComponent<指定元件>())
    }

    /// <summary>
    /// 掉寶
    /// </summary>
    private void Prop()
    {

    }
}
