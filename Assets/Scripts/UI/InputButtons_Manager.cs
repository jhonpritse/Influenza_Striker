
using System;
using UnityEngine;


public class InputButtons_Manager : MonoBehaviour
{
    private const string PlayerTag = "Player/Body";
    
    [SerializeField] private PlayerData_Object playerData;
    
    private Rigidbody _playerRigidbody;
    private GameObject _player;
    private Transform _playerTransform;
    private Transform _feetPos;
    private Player_Manager _playerManager;
    
    private float _moveSpeed;
    private float _jumpSpeed;
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
    
    void GetDataFromPlayerData()
    {
     _moveSpeed = playerData.moveSpeed;
    _jumpSpeed  = playerData.jumpSpeed;
    _groundCheckFeetRadius  = playerData.groundCheckFeetRadius;
    }

    private void FindPlayer()
    {
        _player = GameObject.FindWithTag(PlayerTag).gameObject;
  
        _playerRigidbody = _player.GetComponent<Rigidbody>();
        _playerTransform = _player.GetComponent<Transform>();
        _feetPos = _playerTransform.Find("FeetPos").GetComponent<Transform>();
        _playerManager = _player.GetComponent<Player_Manager>();
    }

    private void Update()
    {
        GroundCheck();
    }
    
    private void GroundCheck()
    {
        var feetPosition = _feetPos.position;
        var dir = new Vector3(0, -1);
        _isGrounded = Physics.Raycast(feetPosition, dir, _groundCheckFeetRadius);
    }

    private void FixedUpdate()
    {
       PlayerMovement();
    }

    private void PlayerMovement()
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
        _playerManager.IsShoot = true;
    }
    
}
