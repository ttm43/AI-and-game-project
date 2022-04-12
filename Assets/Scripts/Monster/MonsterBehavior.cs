using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBehavior : MonoBehaviour
{
    protected GameObject [] playerArr;
    protected GameObject player;

    [Header("===Monster Setting===")]
    public float lifeMonster;
    public float attack;
    public float moveSpeed;
    public float attackRange;
    public int monsterScore;
    public float dropRate;
    public GameObject dropItem;
    

    [Header("===Monster Animator===")]
    protected Animator monsterAnimator;
    protected AnimatorStateInfo monsterStateInfo;

    //public Text scoreText;

    public virtual void Start()
    {
        playerArr = GameObject.FindGameObjectsWithTag("Player");
        player = playerArr[0];
        monsterAnimator = GetComponent<Animator>();
    }
    public virtual void FixedUpdate()
    {
        if(lifeMonster <= 0)
        {
            Destroy(gameObject);
        }

        MonsterAttack();
        
    }
    public virtual void MonsterAttack()
    {

    }
    public virtual void MonsterAttackWay()
    {

    }
    public void ItemDrop()
    {
        Instantiate<GameObject>(dropItem, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }
}
