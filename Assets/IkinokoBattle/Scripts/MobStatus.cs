using UnityEngine;

public abstract class MobStatus : MonoBehaviour
{
    protected enum StateEnum
    {
        Normal,
        Attack,
        Die
    }
    public bool IsMovable => StateEnum.Normal == _state;
    public bool IsAttackable => StateEnum.Attack == _state;
    public float LifeMax => lifeMax;
    public float Life => _life;
    [SerializeField] private float lifeMax = 10;
    protected Animator _animator;
    protected StateEnum _state = StateEnum.Normal;
    [SerializeField] private float _life;
    protected virtual void OnDie()
    {
        LifeGaugeContainer.Instance.Remove(this);
    }
    //ダメージ計算
    public void Damage(int damage)
    {
        if (_state == StateEnum.Die) return;

        _life -= damage;
        if (_life > 0) return;
        _state = StateEnum.Die;
        _animator.SetTrigger("Die");
        OnDie();
    }
    public void GoToAttackStateIfProssible()
    {
        //if (!IsAttackable) return;
        if (_state == StateEnum.Die) return;

        _state = StateEnum.Attack;
        _animator.SetTrigger("Attack");
    }
    public void GoToNormalStateIfProssible()
    {
        if (_state == StateEnum.Die) return;

        _state = StateEnum.Normal;
    }
    protected virtual void Start()
    {
        _life = lifeMax;
        _animator = GetComponentInChildren<Animator>();
        LifeGaugeContainer.Instance.Add(this);
    }
    protected virtual void Update()
    {
    }

}
