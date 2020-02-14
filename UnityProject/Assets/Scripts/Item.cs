
using UnityEngine;

public class Item : MonoBehaviour
{

    [Header("道具音效")]
    public AudioClip sound;



    [HideInInspector]        //將公開的欄位隱藏
    /// <summary>
    /// 是否過關
    /// </summary>
    public bool pass;

    private Transform player;
    private AudioSource aud;


    private void Start()
    {

        Physics.IgnoreLayerCollision(10, 10, false);
        HandleCollision();

        aud = GetComponent<AudioSource>();
        player = GameObject.Find("玩家").transform;
    }

    private void Update()
    {
        GoToPlayer();
    }

    /// <summary>
    /// 處理碰撞問題：避免跟敵人玩家碰撞
    /// </summary>
    private void HandleCollision()
    {

        //物理，忽略圖層碰撞(圖層1，圖層2)
        Physics.IgnoreLayerCollision(10, 8);
        Physics.IgnoreLayerCollision(10, 9);
    }

    /// <summary>
    /// 前往玩家位置
    /// </summary>
    private void GoToPlayer()
    {
        if (pass)
        {
            Physics.IgnoreLayerCollision(10, 10);
            transform.position = Vector3.Lerp(transform.position, player.position, 0.7f * Time.deltaTime * 20);

            if (Vector3.Distance(transform.position,player.position)<2 && !aud.isPlaying)
            {
                aud.PlayOneShot(sound, 0.3f);
                Destroy(gameObject, 0.3f);
            }
        }
    }
}
