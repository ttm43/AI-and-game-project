﻿using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMonster : MonsterBehavior, ITakenDamage
{
    public bool isAttack { get { return isAttacked; } set { isAttacked = value; } }


    [HideInInspector] public bool isAttacked;

    public Transform[] Pos;
    public int PosIndex;

    public Transform Player;



    public AIDestinationSetter aIDestinationSetter;
    public override void Start()
    {
        playerArr = GameObject.FindGameObjectsWithTag("Player");
        player = playerArr[0];
        monsterAnimator = GetComponent<Animator>();
        PosIndex = Random.Range(0, Pos.Length);
        aIDestinationSetter.target = Pos[PosIndex];
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Pos[PosIndex].position) <= 0.5f)
        {
            PosIndex = Random.Range(0, Pos.Length);
            aIDestinationSetter.target = Pos[PosIndex];
        }
        //八米内朝着主角走，反之继续巡航
        if (Vector2.Distance(transform.position, Player.position) <= 8f)
        {
            aIDestinationSetter.target = Player.transform;
        }
        else
        {
            aIDestinationSetter.target = Pos[PosIndex];
        }
    }


    public override void MonsterAttack()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        Vector2 dir = player.transform.position - transform.position;

        if (dist > attackRange)
        {
            monsterAnimator.SetFloat("moveSpeed", moveSpeed);
            monsterAnimator.SetBool("Attack", false);
        }
        else
        {
            monsterAnimator.SetFloat("moveSpeed", 0);
            monsterAnimator.SetBool("Attack", true);
            MonsterAttackWay();

            monsterStateInfo = monsterAnimator.GetCurrentAnimatorStateInfo(0);
            if (monsterStateInfo.IsTag("MonsterAttack"))
            {
                if (monsterStateInfo.normalizedTime >= 0.98f)
                {
                   // player.GetComponent<PlayerSystem>().playerLife -= attack;

                }

            }

        }
    }

    public override void MonsterAttackWay()
    {
        //由于是近战攻击，设置怪物的攻击方向，调用相关动画
        Vector2 dir = player.transform.position - transform.position;
        float dir_x = dir.x;
        float dir_y = dir.y;

        if (dir_x > 0.1f || dir_x < -0.1f)
        {
            monsterAnimator.SetFloat("hit_vertical", 0.0f);
            monsterAnimator.SetFloat("hit_horizontal", dir_x);
        }
        else
        {
            monsterAnimator.SetFloat("hit_horizontal", 0.0f);
            monsterAnimator.SetFloat("hit_vertical", dir_y);
        }
    }


    public void TakenDamage(int _amount)
    {

        lifeMonster -= 1;

        ///收到伤害后退
        Vector2 difference = (transform.position - player.transform.position).normalized;
        transform.position = new Vector2(transform.position.x + 0.5f * difference.x,
                                                transform.position.y + 0.5f * difference.y);
    }

}

