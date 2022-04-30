using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    Animator animator;
    public Transform target;
    public enum STATE
    {
        IDLE, WALK, RUN, ATTACK
    }
    public STATE state = STATE.IDLE;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (target == null)
        {
            target = GameObject.Find("Player").GetComponent<Transform>();
        }
        // = target.GetComponent<>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case STATE.IDLE:
                Idle();
                break;
            case STATE.RUN:
                Run();
                break;
            case STATE.WALK:
                Walk();
                break;
            case STATE.ATTACK:
                Attack();
                break;
            default:
                break;
        }

    }
    public void Idle()
    {
        AllAnimationFalse();
        if (GetDistance() < 15f)
        {
            state = STATE.RUN;
        }
    }
    public void Run()
    {
        AllAnimationFalse();
        animator.SetBool("IsRun", true);
        agent.stoppingDistance = 4f;
        /*if (playerController.IsGameover == false)
        {
            agent.SetDestination(target.transform.position);
        }*/


        if (GetDistance() < agent.stoppingDistance + 1f)
        {
            state = STATE.ATTACK;
        }
        if (GetDistance() > 20f)
        {
            state = STATE.WALK;
        }
        if(GetDistance()>30f)
        {
            state = STATE.IDLE;
        }
    }
    public void Walk()
    {
        AllAnimationFalse();
        animator.SetBool("IsWalk", true);
      //  agent.stoppingDistance = 6f;
        /*if (playerController.IsGameover == false)
        {
            agent.SetDestination(target.transform.position);
        }*/

        if (GetDistance() > 30f)
        {
            state = STATE.IDLE;
        }
    }
    public void Attack()
    {
        AllAnimationFalse();
        animator.SetBool("IsAttack", true);
        transform.LookAt(target.transform.position);

        if (GetDistance() > agent.stoppingDistance)
        {
            state = STATE.IDLE;
        }


    }
    public void AllAnimationFalse()
    {
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsWalk", false);
        animator.SetBool("IsRun", false);

    }
  /*  public void Dead()
    {
        AllAnimationFalse();
        animator.SetBool("IsDead", true);
    }*/
    public float GetDistance()
    {
       // if (playerController.IsGameover == true)
            //return Mathf.Infinity;
        return (Vector3.Distance(target.position, this.transform.position));
    }
}