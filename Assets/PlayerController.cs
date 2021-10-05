using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerStatus))]
[RequireComponent(typeof(MobAttack))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float jumpPower = 3;
    private CharacterController _characterController;
    private Transform _transform;
    private Vector3 _moveVelocity;
    private PlayerStatus _status;
    private MobAttack _attack;

    private bool IsGrounded
    {
        get
        {
            var ray = new Ray(_transform.position + new Vector3(0, 0.1f), Vector3.down);
            var raycastHits = new RaycastHit[1];
            var hitCount = Physics.RaycastNonAlloc(ray, raycastHits, 0.2f);
            return hitCount >= 1;
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _transform = transform;
        _status = GetComponent<PlayerStatus>();
        _attack = GetComponent<MobAttack>();
    }

    // Update is called once per frame
    private void Update()
    {
        animator.SetFloat("MoveSpeed", new Vector3(_moveVelocity.x, 0, _moveVelocity.z).magnitude);
        Debug.Log(IsGrounded ? "地上にいます" : "空中です");
        //_moveVelocity.x = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        //_moveVelocity.z = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;
        //_transform.LookAt(_transform.position + new Vector3(_moveVelocity.x, 0, _moveVelocity.z));
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            _attack.AttackIfPossible();
        }
        if (_status.IsMovable)
        {
            _moveVelocity.x = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
            _moveVelocity.z = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;
            _transform.LookAt(_transform.position + new Vector3(_moveVelocity.x, 0, _moveVelocity.z));
        }
        else
        {
            _moveVelocity.x = 0;
            _moveVelocity.z = 0;
        }
        if (IsGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("ジャンプ！");
                _moveVelocity.y = jumpPower;
            }
        }
        else
        {
            _moveVelocity.y += Physics.gravity.y * Time.deltaTime;
        }
        _characterController.Move(_moveVelocity * Time.deltaTime);
    }
}
