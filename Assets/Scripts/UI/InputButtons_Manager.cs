
using System;
using UnityEngine;


public class InputButtons_Manager : MonoBehaviour
{
    [SerializeField] private PlayerData_Object playerData;
    private static string PlayerTag = "Player";
    
    private Rigidbody _playerRigidbody;
    private GameObject _player;
    private Transform _playerTransform;
    
    private float _moveSpeed;
    private float _jumpSpeed;
    private float _slideTime;
    private float _groundCheckFeetRadius;
    
    private bool _isHoldLeft;
    private bool _isHoldRight;
    private bool _isJump;
    private bool _isSlide;
    private bool _isGrounded;
    void Start()
    {
        GetDataFromPlayerData();
        FindPlayer();
    }

    

    void FindPlayer()
    {
        _player = GameObject.FindWithTag(PlayerTag).gameObject;
        _playerRigidbody = _player.GetComponent<Rigidbody>();
        _playerTransform = _player.GetComponent<Transform>();
    }
    void GetDataFromPlayerData()
    {
     _moveSpeed = playerData.moveSpeed;
    _jumpSpeed  = playerData.jumpSpeed;
    _slideTime  = playerData.slideTime;
    _groundCheckFeetRadius  = playerData.groundCheckFeetRadius;
    }

    void Update()
    {
        GroundCheck();
   
    }

  
    void GroundCheck()
    {
        var feetPos = _playerTransform.Find("FeetPos").transform;
        Vector3 dir = new Vector3(0, -1);
        _isGrounded = Physics.Raycast(feetPos.position, dir, _groundCheckFeetRadius);
    }
    
    void FixedUpdate()
    {
        if (_isHoldLeft)
        {
            _playerRigidbody.AddForce(-_moveSpeed*100 *Time.deltaTime, 0, 0);
        }
        if (_isHoldRight)
        {
            _playerRigidbody.AddForce(+_moveSpeed*100 *Time.deltaTime, 0, 0);
        }

        if (_isJump)
        {
            _playerRigidbody.AddForce(0, +_jumpSpeed*1000* Time.deltaTime, 0);
            _isJump = false;
        }
    }

    public void ControlLeftOnPress()
    {
        _isHoldLeft = true;
    }
    public void ControlLeftOnRelease()
    {
        _isHoldLeft = false;
    }
    public void ControlRightOnPress()
    {
        _isHoldRight = true;
    }
    public void ControlRightOnRelease()
    {
        _isHoldRight = false;
    }
    public void ControlJumpOnPress()
    {
        if (_isGrounded && !_isSlide) _isJump = true;
    }

    public void ControlSlideOnPress()
    {
        var scale = _playerTransform.localScale;
        _playerTransform.localScale = new Vector3(scale.x, scale.y / 2, scale.z);
        _isSlide = true;

    }
    public void ControlSlideOnRelease()
    {
        _isSlide = false;
        var scale = _playerTransform.localScale;
        _playerTransform.localScale = new Vector3(scale.x, scale.y * 2, scale.z);
    }

    public void AttackOnPress()
    {
        _player.GetComponent<Player_Manager>().IsShoot = true;
    }
    
}
