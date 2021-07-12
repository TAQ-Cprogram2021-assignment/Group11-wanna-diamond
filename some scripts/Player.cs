using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    /// <summary>
    /// 类型为Player单例
    /// </summary>
    public static Player instance;
    
    //获取自身刚体
    private Rigidbody2D _rig2D;
    //获取自身BoxCollider2D组件(地面检测而)
    private BoxCollider2D _box;
    //获取动画控制器，动画切换
    public Animator anim;
    //BoxCollider2D要检测的层
    public LayerMask layer;

    //移动速度
    public float speed;
    //第一次跳的高度
    public float jump;
    //二段跳的高度
    public float doubleJump;

    //是否可以二段跳
    private bool _isDoubleJump;


    // Start is called before the first frame update
    void Start()
    {
        _rig2D = GetComponent<Rigidbody2D>();
        _box = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(speed);
        Jump(jump, doubleJump);
    }

    /// <summary>
    /// 控制角色移动
    /// </summary>
    /// <param name="speed"></param>
    private void Move(float speed)
    {
        if (Input.GetKey(KeyCode.A))
        {
            //向左移动
            _rig2D.velocity = new Vector2(-speed, _rig2D.velocity.y);
            Debug.Log(_rig2D.velocity);
            anim.SetBool("IsRun", true);
            //向左移动的话localScale的x改为相反的值
            transform.localScale = new Vector3(-GetComponent<OnTrigger>().self, GetComponent<OnTrigger>().self, GetComponent<OnTrigger>().self);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            //向右移动
            _rig2D.velocity = new Vector2(speed, _rig2D.velocity.y);
            Debug.Log(_rig2D.velocity);
            anim.SetBool("IsRun", true);
            //向右移动的话将localScale的x值改为正值
            transform.localScale = new Vector3(GetComponent<OnTrigger>().self, GetComponent<OnTrigger>().self, GetComponent<OnTrigger>().self);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _rig2D.velocity = new Vector2(0, _rig2D.velocity.y);
            anim.SetBool("IsRun", false);
        }

        if (!IsGround())
        {
            //如果不在地面上播放跳跃动画
            anim.SetBool("IsJump",true);
        }
        else
        {
            //如果在地面上停止播放跳跃动画
            anim.SetBool("IsJump",false);
        }
    }

    /// <summary>
    /// 控制角色跳跃
    /// </summary>
    /// <param name="jumpSpeed"></param>
    /// <param name="doubleJump"></param>
    private void Jump(float jumpSpeed,float doubleJump)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGround())
            {
                _rig2D.velocity = new Vector2(_rig2D.velocity.x, jumpSpeed);
                Debug.Log(_rig2D.velocity);
                _isDoubleJump = true;
            }
            else
            {
                if (_isDoubleJump)
                {
                    _rig2D.velocity = new Vector2(_rig2D.velocity.x, doubleJump);
                    Debug.Log(_rig2D.velocity);
                    _isDoubleJump = false;
                }
            }
        }
    }

    /// <summary>
    /// 判断是否在地面上
    /// </summary>
    /// <returns></returns>
    public bool IsGround()
    {
        return _box.IsTouchingLayers(layer);
    }
}
