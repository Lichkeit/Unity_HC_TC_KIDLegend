using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//引用 場景管理API
using System.Collections;

public class LevelManager : MonoBehaviour
{
    // GameObject.Find("物件名稱") - 找不到隱藏物件
    [Header("物件：光照與隨機技能")]
    public GameObject objLight;
    public GameObject randomSkill;

    [Header("是否自動顯示隨機技能")]
    public bool autoShowSkill;
    [Header("是否自動開門")]
    public bool autoOpenDool;

    private Animator door;
    private Image imgCross;

    private void Start()
    {
        door = GameObject.Find("木頭門").GetComponent<Animator>();
        imgCross = GameObject.Find("轉場效果").GetComponent<Image>();

        if (autoShowSkill) ShowSkill();
        if (autoOpenDool) Invoke("OpenDoor", 6);    // 延遲調用(方法，延遲時間)
    }

    /// <summary>
    /// 顯示技能
    /// </summary>
    private void ShowSkill()
    {
        randomSkill.SetActive(true);
    }

    /// <summary>
    /// 開門並顯示光照
    /// </summary>
    private void OpenDoor()
    {
        objLight.SetActive(true);
        door.SetTrigger("開門觸發");
    }

    /// <summary>
    /// 載入下一關
    /// </summary>
    /// <returns></returns>
    public IEnumerator NextLevel()
    {
        //載入下一關
        //SceneManager.LoadScene("場景名稱"); //場景管理氣.載入場景("場景名稱")

        AsyncOperation async = SceneManager.LoadSceneAsync("關卡2");   //場景管理器.非同步載入場景("場景名稱")

        //不允許直接載入
        async.allowSceneActivation = false;


        for (int i = 0; i < 100; i++)               //迴圈 for while
        {
            imgCross.color += new Color(1, 1, 1, 0.01f);   //0.01透明度+0.01
            yield return new WaitForSeconds(0.01f);        //等待0.01秒
        }

        //允許直接載入
        async.allowSceneActivation = true;


    }
}
