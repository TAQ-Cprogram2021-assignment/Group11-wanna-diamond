using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class playerDie : MonoBehaviour
{
    //player的预制体
    public GameObject playerPrefab;
    public static playerDie instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public void ResetGame(TransitionDestination.DestinationTag destinationTag)
    {
        GameObject.Find("Die").GetComponent<TransitionPoint>().destinationTag = destinationTag;
    }

    private void Update()
    {
        //如果找不到名字为player的物体
        if (!GameObject.Find("player"))
        {
            //在destinationTag位置生成一个并赋值给临时变量player
            GameObject player = Instantiate(playerPrefab, GetDestination(GetComponent<TransitionPoint>().destinationTag).transform.position,
                quaternion.identity);
            
            //将生成的player物体的名字改为player
            player.name = "player";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    /// <summary>
    /// 在场景内查找要生成的位置
    /// </summary>
    /// <param name="destinationTag"></param>
    /// <returns></returns>
    public TransitionDestination GetDestination(TransitionDestination.DestinationTag destinationTag)
    {
        //查找所有带有TransitionDestination脚本的物体
        var Pos = FindObjectsOfType<TransitionDestination>();
        //遍历pos数组
        foreach (var item in Pos)
        {
            //如果item的destinationTag和传进来的destinationTag相同
            if (item.destinationTag == destinationTag)
            {
                //返回item
                return item;
            }
        }

        //如果查找不到则返回空
        return null;
    }
}
