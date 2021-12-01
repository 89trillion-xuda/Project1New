using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProductsView
{
    /// <summary>
    /// 获取 商品预制体中 一些需要动态改变的 子对象的克隆
    /// </summary>
    public class ProductComponents : MonoBehaviour
    {
        //获取卡片背景对象
        [SerializeField] private GameObject sellContentBgImg;
        //获取商品图片
        [SerializeField] private Image sellContentImg;
        //获取商品售卖的数量
        [SerializeField] private Text sellSumTxt;
        //获取购买按钮
        [SerializeField] private GameObject sellSpendBtn;
        //获取购买完成按钮
        [SerializeField] private GameObject sellFinishBtn;


        //  初始化每一个商品信息预制体函数
        public void setInit(int type, int subType, int num, int isPurchased)
        {
            //除了卡片以外的商品不需要卡片背景
            if (type != 3)
            {
                sellContentBgImg.SetActive(false);
            }
            else
            {
                sellContentBgImg.SetActive(true);
            }

            //设置商品图片资源
            if (type == 2)
            {
                sellContentImg.sprite = Resources.Load("diamond_2", typeof(Sprite)) as Sprite;
            }else if (type == 3)
            {
                sellContentImg.sprite = Resources.Load(subType.ToString(), typeof(Sprite)) as Sprite;
            }
                    
            //设置商品售卖的数量
            sellSumTxt.text = num.ToString();
                    
            //判断商品售卖状态，未售卖就显示购买按钮
            if (isPurchased == 1)
            {
                sellSpendBtn.SetActive(false);
            }
            else
            {
                sellSpendBtn.SetActive(true);
            }
            //显示购买完成的✅
            sellFinishBtn.SetActive(true);
        }
        
    
    }

}