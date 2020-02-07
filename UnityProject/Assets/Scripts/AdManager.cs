
using UnityEngine;
using UnityEngine.Advertisements;  //引用廣告API

public class AdManager : MonoBehaviour,IUnityAdsListener
{
    private string googlePlay = "3457977";             //廣告ID Google Play
    private string placementRevival = "revival";       //廣告名稱 復活
    private Player player;

    private void Start()
    {
        //廣告.初始化(廣告服務 ID,啟動測試模式)
        Advertisement.Initialize(googlePlay, true);
        //廣告.增加監聽者(此腳本)
        Advertisement.AddListener(this);

        player = FindObjectOfType<Player>();
    }

    /// <summary>
    /// 顯示復活廣告
    /// </summary>
    public void ShowRevivalAd()
    {
        if (Advertisement.IsReady(placementRevival))   //如果 廣告準備完成(廣告名稱)
        {
            Advertisement.Show(placementRevival);      //顯示廣告(廣告名稱)
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId==placementRevival)
        {
            //switch 判斷式(要判斷的值)
            switch (showResult)
            {
                //第一種可能 case 廣告失敗
                case ShowResult.Failed:
                    print("廣告失敗");
                    break;
                //第二種可能 case 廣告略過
                case ShowResult.Skipped:
                    print("廣告略過");
                    break;
                //第三種可能 case 廣告完成
                case ShowResult.Finished:
                    print("廣告完成");
                    player.Revival();
                    break;
               
            }
        }
    }
}
