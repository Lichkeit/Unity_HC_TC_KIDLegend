
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpDamageManager : MonoBehaviour
{
    private Image hpBar;
    private RectTransform rtValue;
    private Text textValue;

    private void Start()
    {
        hpBar = transform.GetChild(1).GetComponent<Image>();
        rtValue = transform.GetChild(2).GetComponent<RectTransform>();
        textValue = transform.GetChild(2).GetComponent<Text>();
    }
    private void Update()
    {
        FixedAngle();
    }

    /// <summary>
    /// 固定角度:不要讓血條旋轉
    /// </summary>
    private void FixedAngle()
    {
        //變形.歐拉角度(世界角度)=三維向量(x,y,z)
        transform.eulerAngles = new Vector3(35, -180, 0);
    }
    
   public void UpdateHpBar(float hpCurrent,float hpMax)
    {
        hpBar.fillAmount = hpCurrent / hpMax;
    }

    public IEnumerator ShowValue(float value,string mark,Vector3 size,Color valueColor)
    {
        textValue.text = mark + value;  //更新文字.內容為:符號+數值，例如:-90，+50
        valueColor.a = 0;               //顏色.透明度=0
        textValue.color = valueColor;   //更新文字.顏色
        rtValue.localScale = size;      //更新文字.尺寸

        for (int i = 0; i < 50; i++)
        {
            textValue.color += new Color(0, 0, 0, 0.1f);    //透明度遞增
            rtValue.anchoredPosition += Vector2.up * 5;     //Y軸遞增
            yield return new WaitForSeconds(0.01f);         //等待時間
               
        }

        rtValue.anchoredPosition = new Vector2(0, 70);     //還原座標
        textValue.color = new Color(0, 0, 0, 0);           //還原透明度

    }
}
