
using UnityEngine;
using UnityEngine.UI;

public class HpDamageManager : MonoBehaviour
{
    private Image hpBar;

    private void Start()
    {
        hpBar = transform.GetChild(1).GetComponent<Image>();
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
}
