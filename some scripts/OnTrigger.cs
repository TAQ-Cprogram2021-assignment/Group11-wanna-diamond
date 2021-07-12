using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class OnTrigger : MonoBehaviour
{
    public float self = 2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        #region _1
        
        if (other.name.Equals("1"))
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (other.name.Equals("_1"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 5;
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
        
        #endregion
        
        #region _2

        if (other.name.Equals("_2"))
        {
            //如果碰到地刺的话自身Y轴向上 *5并且将碰撞器关掉
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 5;
            GetComponent<CapsuleCollider2D>().enabled = false;
            var Dz = FindObjectsOfType<PolygonCollider2D>();
            foreach (var item in Dz)
            {
                item.enabled = false;
            }

            if (GameObject.Find("1"))
            {
                GameObject.Find("1").GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        
        if (other.name.Equals("Die"))
        {
            //SceneManager.LoadScene("SampleScene");
            //playerDie.instance.ResetGame();
            SceneController.instance.TransitionToDestination(GameObject.Find("Die").GetComponent<TransitionPoint>());
            Destroy(gameObject);
        }

        #endregion

        #region MyRegion

        if (other.name.Equals("_3"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 5;
            GetComponent<CapsuleCollider2D>().enabled = false;
            var Dz = FindObjectsOfType<PolygonCollider2D>();
            foreach (var item in Dz)
            {
                item.enabled = false;
            }
        }

        #endregion

        if (other.name.Equals("Dz"))
        {
            other.transform.position += Vector3.left;
            //Destroy(other.gameObject);
        }

        if (other.name.Equals("Save"))
        {
            //GameObject.FindObjectOfType<GameManager>()._originalPos = other.transform.position;
            GameObject.Find("Die").GetComponent<TransitionPoint>().destinationTag =
                other.GetComponent<TransitionDestination>().destinationTag;
            
            Debug.Log("Save");
        }

        if (other.name.Equals("Clearance"))
        {
            GameObject.Find("Die").GetComponent<TransitionPoint>().destinationTag =
                other.GetComponent<TransitionPoint>().destinationTag;
            
            SceneController.instance.TransitionToDestination(GameObject.Find("Clearance")
                .GetComponent<TransitionPoint>());
        }

        if (other.name.Equals("ClearanceGame3"))
        {
            GameObject.Find("Die").GetComponent<TransitionPoint>().destinationTag =
                other.GetComponent<TransitionPoint>().destinationTag;
            SceneController.instance.TransitionToDestination(GameObject.Find("ClearanceGame3")
                .GetComponent<TransitionPoint>());
        }

        if (other.name.Equals("ClearanceGame4"))
        {
            GameObject.Find("Die").GetComponent<TransitionPoint>().destinationTag =
                other.GetComponent<TransitionPoint>().destinationTag;
            
            SceneController.instance.TransitionToDestination(GameObject.Find("ClearanceGame4")
                
                .GetComponent<TransitionPoint>());
        }

        if (other.name.Equals("ClearanceGame5"))
        {
            GameObject.Find("Die").GetComponent<TransitionPoint>().destinationTag =
                other.GetComponent<TransitionPoint>().destinationTag;
            
            SceneController.instance.TransitionToDestination(GameObject.Find("ClearanceGame5")
                .GetComponent<TransitionPoint>());
        }

        if (other.name.Equals("ClearanceGame6"))
        {
            GameObject.Find("Die").GetComponent<TransitionPoint>().destinationTag =
                other.GetComponent<TransitionPoint>().destinationTag;
            
            SceneController.instance.TransitionToDestination(GameObject.Find("ClearanceGame6")
                .GetComponent<TransitionPoint>());
        }

        if (other.name.Equals("ClearanceGame7"))
        {
            GameObject.Find("Die").GetComponent<TransitionPoint>().destinationTag =
                other.GetComponent<TransitionPoint>().destinationTag;
            
            SceneController.instance.TransitionToDestination(GameObject.Find("ClearanceGame7")
                .GetComponent<TransitionPoint>());
        }

        if (other.name.Equals("_2_"))
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //如果检测到的物体的名字为开始则执行下面的代码
        if (other.name.Equals("开始"))
        {
            Debug.Log("开始");
            //查找所有挂有Test脚本的物体
            var test = FindObjectsOfType<Test>();
            //遍历test数组
            foreach (var item in test)
            {
                item.IsCountdown = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
