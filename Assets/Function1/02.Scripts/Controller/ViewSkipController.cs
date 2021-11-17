using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

/// <summary>
/// 视图的 跳转 和 启用与弃用 即显示与隐藏 控制器：
/// </summary>
public class ViewSkipController : MonoBehaviour
{
    //定义全局变量，用于全局使用
    private GameObject sellBeginPanel;
    private GameObject sellRootPanel;
    //private GameObject PopupsPanel;

    public GameObject CurrentObject;


    private void Awake()
    {
        //为 开始画板 和 商店画板 两个界面 初始化 获得对象
        sellBeginPanel = GameObject.Find("SellBeginPanel");
        sellRootPanel = GameObject.Find("SellRootPanel");
        //为 弹窗 初始化 获得对象
        //PopupsPanel = GameObject.Find("PopupsPanel");
    }
    
    //进入商店方法
    public void enterShop()
    {
        sellBeginPanel.SetActive(false);
        sellRootPanel.SetActive(true);
        //PopupsPanel.SetActive(false);
    }
    
    //退出商店方法
    public void outShop()
    {
        sellBeginPanel.SetActive(true);
        sellRootPanel.SetActive(false);
    }
    
    //购买按钮监听方法
    public void popUps()
    {
        //打开选择确定的弹窗
        //PopupsPanel.SetActive(true);
        
        //分配当前游戏对象为 本对象
        CurrentObject = transform.gameObject;
        //实例化当前游戏对象
        //GameObject CurrentObj = GameObject.Instantiate(CurrentObject,transform) as GameObject;

        //获得当前游戏对象的子对象集合
        Transform[] ts = CurrentObject.GetComponentsInChildren<Transform>();
        for (int i = 0; i < ts.Length; i++)
        {
            //找到购买按钮，购买完成后，隐藏购买按钮
            if (ts[i].name.Equals("SellSpendBtn"))
            {
                Debug.Log(ts[i].name);
                ts[i].gameObject.SetActive(false);
            }
        }
    }

    /*//确定购买方法
    public void sure()
    {
        //隐藏弹窗
        PopupsPanel.SetActive(false);
    }
    //取消购买方法
    public void back()
    {
        PopupsPanel.SetActive(false);
    }*/
}
