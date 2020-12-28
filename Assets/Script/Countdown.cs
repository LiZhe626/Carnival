using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    private Text countdowntext;//倒计时文本
    private Image Ten_minutes;//分钟十位
    private Image Units_minutes;//分钟个位
    private Image Ten_seconds;//秒钟十位
    private Image Units_seconds;//秒钟个位
    public Sprite[] number_picture;//数字图片数组
    public float time = 100;//时限
    public int time_old = 0;//时限旧
    public bool donghua;//颜色动画
    // Start is called before the first frame update
    void Start()
    {
        time_old = (int)time;
        countdowntext = this.transform.GetChild(0).GetComponent<Text>();
        Ten_minutes = this.transform.GetChild(1).GetComponent<Image>();
        Units_minutes = this.transform.GetChild(2).GetComponent<Image>();
        Ten_seconds = this.transform.GetChild(3).GetComponent<Image>();
        Units_seconds = this.transform.GetChild(4).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            return;
        }
        time -= Time.deltaTime;
        if ((int)time != time_old)
        {
            time_old = (int)time;
            //拿到整分钟
            int Whole_minute = time_old / 60;
            //拿到剩余的秒数
            int DayRemainingTime = time_old % 60;

            int minutes_ten = Whole_minute / 10; //十位的分钟
            int minutes_units = Whole_minute % 10;//个位的分钟

            //设置分钟图片
            Ten_minutes.sprite = number_picture[minutes_ten];
            Units_minutes.sprite = number_picture[minutes_units];

            //十位的秒数

            int seconds_ten = DayRemainingTime / 10;//十位的秒数
            int seconds_units = DayRemainingTime % 10;//个位的秒数

            //设置秒钟图片
            Ten_seconds.sprite = number_picture[seconds_ten];
            Units_seconds.sprite = number_picture[seconds_units];

            //倒计时文字显示
            countdowntext.text = "倒计时：" + Whole_minute.ToString("00") + ":" + DayRemainingTime.ToString("00");//时限.ToString("00")更改为没有后缀
        }
        //倒数10秒变为红色并循环闪烁
        if (time < 10 && donghua == false)
        {
            donghua = true;
            Ten_minutes.DOColor(Color.red, 1).OnComplete(() => { Ten_minutes.DOFade(0, 0.5f).SetLoops(-1, LoopType.Yoyo); });
            Units_minutes.DOColor(Color.red, 1).OnComplete(() => { Units_minutes.DOFade(0, 0.5f).SetLoops(-1, LoopType.Yoyo); });
            Ten_seconds.DOColor(Color.red, 1).OnComplete(() => { Ten_seconds.DOFade(0, 0.5f).SetLoops(-1, LoopType.Yoyo); });
            Units_seconds.DOColor(Color.red, 1).OnComplete(() => { Units_seconds.DOFade(0, 0.5f).SetLoops(-1, LoopType.Yoyo); });
        }

    }
}
