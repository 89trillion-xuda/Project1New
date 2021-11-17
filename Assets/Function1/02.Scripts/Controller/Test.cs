using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Tweener twe = transform.DOMove(new Vector3(2, 3, 0), 2);
        twe.SetAutoKill(true);
        twe.SetEase(Ease.InCubic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
