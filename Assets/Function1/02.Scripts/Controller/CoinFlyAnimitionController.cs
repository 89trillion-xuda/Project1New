using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class CoinFlyAnimitionController : MonoBehaviour
{

    public GameObject CoinFlyObjClone;
    public GameObject BoxSpeEftClone;
    
    //计算金币生成总数，上限为15
    public int count=0;
    //计算特效数量

    // Start is called before the first frame update
    public void onClick()
    {
        GameObject coin = GameObject.Find("CoinImage");
        GameObject box = GameObject.Find("SellContentImg");
        //GameObject BoxSpeEft;
        
        count += 5;

        //控制飞金币数量最多为15个，多了就不再创建飞金币动画
        if (count <= 15)
        {
            //实例化飞金币动画的对象
            GameObject CoinFly = GameObject.Instantiate(CoinFlyObjClone, transform) as GameObject;
            //实例化特效对象
            GameObject BoxSpeEft  = GameObject.Instantiate(BoxSpeEftClone,transform) as GameObject;

            //设置金币对象 和 特效对象 的起始坐标为 宝箱位置
            CoinFly.transform.position = box.transform.position;
            BoxSpeEft.transform.position = box.transform.position;
            
            //410 1670

            //一个金币飞完一次的时间后，Distory金币对象 和 特效对象
            CoinFly.transform
                .DOMove(new Vector3(coin.transform.position.x, coin.transform.position.y, coin.transform.position.z), 2)
                .OnComplete(() => Destroy(CoinFly))
                .OnComplete(() => Destroy(BoxSpeEft));

            //延迟执行函数，每点击一次，就 总共生成五次动画
            Invoke("repid",0.2f);
            Invoke("repid",0.4f);
            Invoke("repid",0.6f);
            Invoke("repid",0.8f);
        
            count -= 5;
        }

    }

    //一次飞金币动画的函数
    public void repid()
    {
        //实例化飞金币动画的对象
        GameObject CoinFly = GameObject.Instantiate(CoinFlyObjClone, transform) as GameObject;

        GameObject coin = GameObject.Find("CoinImage");
        GameObject box = GameObject.Find("SellContentImg");

        //设置起始坐标
        CoinFly.transform.position = box.transform.position;
        //410 1670

        //一个金币飞完一次的时间后，Distory这个对象
        CoinFly.transform
            .DOMove(new Vector3(coin.transform.position.x, coin.transform.position.y, coin.transform.position.z), 2)
            .OnComplete(() => Destroy(CoinFly));
    }

    void Start()
    {
        
    }
}
