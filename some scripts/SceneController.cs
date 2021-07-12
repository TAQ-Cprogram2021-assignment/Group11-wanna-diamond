using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    /// <summary>
    /// 类型为SceneController单例
    /// </summary>
    public static SceneController instance;
    public GameObject playerPrefab;

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

    /// <summary>
    /// 根据传进的枚举值进行开启协程传值
    /// </summary>
    /// <param name="transitionPoint"></param>
    public void TransitionToDestination(TransitionPoint transitionPoint)
    {
        switch (transitionPoint.tranSitionType)
        {
            case TransitionPoint.TransitionType.sameScene:
                //TODO 同场景复活
                StartCoroutine(Transition(SceneManager.GetActiveScene().name, transitionPoint.destinationTag));
                break;
            case TransitionPoint.TransitionType.DifferentScene:
                //TODO 异场景传送
                StartCoroutine(Transition(transitionPoint.sceneName, transitionPoint.destinationTag));
                break;
        }
    }

    /// <summary>
    /// 控制场景重启和跳转
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="destinationTag"></param>
    /// <returns></returns>
    IEnumerator Transition(string sceneName, TransitionDestination.DestinationTag destinationTag)
    {
        //如果本场景的 名字和传进的值不相同，则进行场景跳转
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
            //yield return Instantiate(playerPrefab,GetDestination(destinationTag).transform.position,GetDestination(destinationTag).transform.rotation);
        }
        //相同的话则重启本场景
        else
        {
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            //yield return Instantiate(playerPrefab, GetDestination(destinationTag).transform.position, GetDestination(destinationTag).transform.rotation);
        }
    }

    /// <summary>
    /// 查找角色生成位置
    /// </summary>
    /// <param name="destinationTag"></param>
    /// <returns></returns>
    private TransitionDestination GetDestination(TransitionDestination.DestinationTag destinationTag)
    {
        var targetPos = FindObjectsOfType<TransitionDestination>();
        
        foreach (var item in targetPos)
        {
            if (item.destinationTag == destinationTag)
            {
                return item;
            }
        }

        return null;
    }
}
