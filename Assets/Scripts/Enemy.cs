using Pathfinding;
using System.Collections;
using UnityEngine;

/// <summary>
/// 第三个怪物
/// </summary>
public class Enemy : MonoBehaviour, ITakenDamage
{
    [SerializeField] private float moveSpeed;
    private Transform target;
    [SerializeField] private int maxHp;
    public int hp;

    [Header("Hurt")]
    private SpriteRenderer sp;
    public float hurtLength;//MARKER 效果持续多久
    private float timeBtwHurt;//MARKER 相当于计数器

    [HideInInspector] public bool isAttacked;
    [SerializeField] private GameObject explosionEffect;

    public Transform[] Pos;
    public int PosIndex;

    public Transform Player;

    public bool IsGong;


    public AIDestinationSetter aIDestinationSetter;

    public bool isAttack { get { return isAttacked; }  set { isAttacked = value; } }

    public GameObject bulletEffect;

    private void Start() 
    {
        //血量
        hp = maxHp;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();

        PosIndex = Random.Range(0, Pos.Length);
        aIDestinationSetter.target = Pos[PosIndex];
        
    }

    private void Update()
    {
        timeBtwHurt -= Time.deltaTime;
        if (timeBtwHurt <= 0)
            sp.material.SetFloat("_FlashAmount", 0);

        if (IsGong)
            return;
        //自动更新寻路点
        if (Vector2.Distance(transform.position, Pos[PosIndex].position) <= 0.5f)
        {
            PosIndex = Random.Range(0, Pos.Length);
            aIDestinationSetter.target = Pos[PosIndex];
        }


    }

    /// <summary>
    /// 受到伤害
    /// </summary>
    /// <param name="_amount"></param>
    public void TakenDamage(int _amount)
    {
        isAttack = true;
        StartCoroutine(isAttackCo());
        hp -= _amount;
        HurtEffect();
        IsGong = true;
        aIDestinationSetter.target = Player;
        ///敌人没血死亡
        if (hp <= 0)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void HurtEffect() 
    {
        sp.material.SetFloat("_FlashAmount", 1);
        timeBtwHurt = hurtLength;
    }

    IEnumerator isAttackCo()
    {
        yield return new WaitForSeconds(0.2f);
        isAttack = false;
    }

}
