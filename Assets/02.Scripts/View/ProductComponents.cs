using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 获取 商品预制体中 一些需要动态改变的 子对象的克隆
/// </summary>
public class ProductComponents : MonoBehaviour
{
    //获取卡片背景对象
    public GameObject sellContentBgImg;
    //获取商品图片
    public Image sellContentImg;
    //获取商品售卖的数量
    public Text sellSumTxt;
    //获取购买按钮
    public GameObject sellSpendBtn;
    //获取购买完成按钮
    public GameObject sellFinishBtn;
    
    
    //还原商品预制体方法，使之变回原来开始的模样
    public void Init()
    {
        sellContentBgImg.SetActive(true);
        sellContentImg.sprite = Resources.Load("coin_1",typeof(Sprite)) as Sprite;
        sellSumTxt.text = "1000";
        sellSpendBtn.SetActive(true);
        sellFinishBtn.SetActive(true);
    }
    
}
