using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MobStatus))]

public class MobAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private Collider attackCollider;

    private MobStatus _status;
    // Start is called before the first frame update
    private void Start()
    {
        _status = GetComponent<MobStatus>();
        attackCollider.enabled = false;
    }
    public void AttackIfPossible()
    {
        //if (!_status.IsAttackable) return;
        _status.GoToAttackStateIfProssible();
    }
    public void OnAttackRangeEnter(Collider collider)
    {
        AttackIfPossible();
    }
    public void OnAttackStart()
    {
        attackCollider.enabled = true;
    }
    public void OnHitAttack(Collider collider)
    {
        var targetMob = collider.GetComponent<MobStatus>();
        if (null == targetMob) return;
        targetMob.Damage(1);
    }
    public void OnAttackFinished()
    {
        attackCollider.enabled = false;
        StartCoroutine(CooldownCorutine());
    }
    private IEnumerator CooldownCorutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        _status.GoToNormalStateIfProssible();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
