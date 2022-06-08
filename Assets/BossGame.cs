using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossGame :MonoBehaviour, ITakenDamage
{
    public bool isAttack { get { return isAttacked; } set { isAttacked = value; } }


    [HideInInspector] public bool isAttacked;

    public Transform[] Pos;
    public int PosIndex;

    public Transform Player;

    public GameObject GameOver;


    public AIPath aI;
    public AIDestinationSetter aIDestinationSetter;
    private Animator monsterAnimator;
    private float moveSpeed;
    public int lifeMonster;

    public bool IsSkill_2;

    public GameObject XiaoBing;

    bool IsZHAO;

    public bool IsHui;
    int HuiInt;

    public Transform HuixuePos;

    public GameObject HuixueGame;

    public Text HPText;

    private void Start()
    {
        Player = GameObject.Find("Player").transform;
        monsterAnimator = GetComponent<Animator>();
        aIDestinationSetter = GetComponent<AIDestinationSetter>();
        aIDestinationSetter.target = Player.transform;
    }

    private void Update()
    {
        if (IsHui)
            return;
        MonsterAttack();
        if (transform.position.x < Player.position.x)
            transform.localScale = new Vector3(0.00612739f, 0.00612739f, 0.00612739f);
        if (transform.position.x > Player.position.x)
            transform.localScale = new Vector3(-0.00612739f, 0.00612739f, 0.00612739f);
    }

    public void MonsterAttack()
    {
        
        if (Vector2.Distance(transform.position, Player.transform.position) <= 5&& IsSkill_2==false)
        {
            monsterAnimator.SetTrigger("skill_2");
            Player.GetComponent<PlayerMovement>().moveSpeed = 0.8f;
            Invoke("GuiWei", 2);
            Invoke("Fanhui", 5f);
            IsSkill_2 = true;
            aI.maxSpeed = 3;
        }

        if (Vector2.Distance(transform.position, Player.transform.position) <= 2f)
        {
            monsterAnimator.SetTrigger("skill_1");
        }

        if (Vector2.Distance(transform.position, Player.transform.position) >= 3f)
        {
            monsterAnimator.SetTrigger("run");
        }
        
    }


    public void GuiWei()
    {
        Player.GetComponent<PlayerMovement>().moveSpeed = 3;
        Invoke("Skill_2Btn", 10f);
    }

    void Fanhui()
    {
        aI.maxSpeed = 1.9f;
    }

    void Skill_2Btn()
    {
        IsSkill_2 = false;
    }


    public void TakenDamage(int _amount)
    {
        if (IsHui)
        {
            HuiInt++;
            if (HuiInt >= 2)
            {
                IsHui = false;
                HuixueGame.SetActive(false);
                aIDestinationSetter.target = Player;
            }
        }
        else {

            lifeMonster -= 1;
            HPText.text = "HP£º" + lifeMonster.ToString();
            monsterAnimator.SetTrigger("hit_1");

            if (lifeMonster <= 20 && !IsZHAO)
            {
                XiaoBing.SetActive(true);
                monsterAnimator.SetTrigger("skill_2");
                IsHui = true;
                IsZHAO = true;
                aIDestinationSetter.target = HuixuePos;
                Invoke("Huixue", 7f);
                HuixueGame.SetActive(true);
            }
            if (lifeMonster <= 0)
            {
                GameOver.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    void Huixue()
    {
        if (IsHui)
        {
            HuixueGame.SetActive(false);
            lifeMonster = 40;
            aIDestinationSetter.target = Player;
            HPText.text = "HP£º" + lifeMonster.ToString();

        }
    }

}