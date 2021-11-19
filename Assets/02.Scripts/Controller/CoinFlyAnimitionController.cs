using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

/// <summary>
/// 购买宝箱按钮按下时，生成飞金币的控制、金币数量控制、特效控制，玩家金币数量信息控制
/// </summary>
public class CoinFlyAnimitionController : MonoBehaviour
{
    //传进来的金币克隆对象
    [SerializeField]private GameObject CoinFlyObjClone;
    //传进来的开箱特效对象
    [SerializeField]private GameObject BoxSpeEftClone;
    //传进来的宝箱图片
    [SerializeField]private Image boxImg;
    //传进来的金币图片，用于设置飞金币的终点坐标位置
    [SerializeField]private GameObject coinImg;
    //得到用户信息中的金币数量文本对象
    [SerializeField]private Text coinSumTxt;

    //计算金币生成总数，上限为15
    private int count;
    //计算点击次数
    private int onClickCount;
    //循环变量
    private int i;
    //计算特效数量
    private int BoxSpeFftCount;

    //实例化后的特效对象
    private GameObject BoxSpeEft;
    
    public void OnClick()
    {
        //变更宝箱图片为 打开的宝箱图片
        //获取该精灵体下的全部子精灵
        Sprite[] sprites = Resources.LoadAll<Sprite>("AEP_Atlas");
        //修改精灵体 为 打开状态的宝箱 的精灵体
        boxImg.sprite = sprites[0];
        //放大一下宝箱大小，不然看着不协调
        boxImg.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        
        //只实例化一个特效对象
        if (BoxSpeFftCount == 0)
        {
            //第一次的时候，实例化一个特效对象
            BoxSpeEft  = GameObject.Instantiate(BoxSpeEftClone,transform) as GameObject;
            //特效数量+1
            BoxSpeFftCount++;
        }

        //点击次数+1，点击次数封顶3次，用于计算飞金币的数量
        onClickCount++;
        if (onClickCount > 3)
        {
            onClickCount = 3;
        }
        
        //设置特效对象 的起始坐标为 宝箱位置
        BoxSpeEft.transform.position = boxImg.transform.position - new Vector3(0,0.1f,0);

        //延迟执行 生成飞金币 的 函数，根据点击次数onClickCount，生成数量 = onClickCount（点击次数）*5; 最多生成15个
        for (i = 1; i <= onClickCount * 5; i++)
        {
            //Debug.Log("飞金币序号："+ i +" > 延迟时间：" + i*0.1f);
            Invoke("Repid",i*0.1f);
        }
    }

    //一次飞金币动画的函数
    public void Repid()
    {
        count++;
        
        //实例化飞金币动画的对象
        GameObject CoinFly = GameObject.Instantiate(CoinFlyObjClone, transform) as GameObject;

        //设置飞金币的起始坐标
        CoinFly.transform.position = boxImg.transform.position;
        //CoinFly.transform.position = new Vector3(0, 0, 0);

        //一个金币飞完一次的时间后，Distory这个对象
        CoinFly.transform
            .DOMove(coinImg.transform.position, 1.8f)
            .SetEase(Ease.InCubic)//先慢后快
            .OnComplete(() =>
            {
                Destroy(CoinFly);//销毁飞金币对象
                CancelInvoke();
                AddCoin();//增加玩家持有的金币数量
                count--;//飞金币数量减少1
                CloseBoxSpeEft();//判断关闭特效函数
            });
        //设置金币渐大
        CoinFly.transform.DOScale(1f, 1f);
    }

    //关闭箱子的函数
    public void CloseBox()
    {
        //获取该精灵体下的全部子精灵
        Sprite[] sprites = Resources.LoadAll<Sprite>("AEP_Atlas");
        //修改精灵体为打开状态的宝箱的精灵体
        boxImg.sprite = sprites[3];
        //关闭箱子时，把宝箱变为原来缩放的大小
        boxImg.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    
    //点击宝箱增加金币的函数
    public void AddCoin()
    {
        //玩家持有金币数量 +1
        coinSumTxt.text = (int.Parse(coinSumTxt.text) + 1).ToString();
    }

    //判断特效关闭时间
    public void CloseBoxSpeEft()
    {
        Debug.Log(count);
        
        if (count == 0)
        {
            //销毁特效
            Destroy(BoxSpeEft);
            //特效数量-1
            BoxSpeFftCount--;
            //关闭箱子
            CloseBox();
        }
    }

    void Start()
    {
        
    }
}
