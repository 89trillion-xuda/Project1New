using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

namespace ViewCoinController
{
    /// <summary>
    /// 视图的 跳转 和 启用与弃用 即显示与隐藏 控制器：
    /// </summary>
    public class ViewSkipController : MonoBehaviour
    {
        //获得开始界面面板
        [SerializeField] private GameObject sellBeginPanel;
        //获得商店界面面板
        [SerializeField] private GameObject sellRootPanel;
        //获得购买按钮
        [SerializeField] private GameObject SellSpendBtn;
    
        //进入商店方法
        public void EnterShop()
        {
            //开始界面画板不显示
            sellBeginPanel.SetActive(false);
            //商店界面画板显示
            sellRootPanel.SetActive(true);
        }
    
        //退出商店方法
        public void OutShop()
        {
            //开始界面画板显示
            sellBeginPanel.SetActive(true);
            //商店界面画板不显示
            sellRootPanel.SetActive(false);
        }
    
        //购买按钮监听方法
        public void PopUps()
        {
            //购买按钮不显示
            SellSpendBtn.SetActive(false);
        }
    }

}