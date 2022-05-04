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
    public GameObject ragdollPrefab;
    public enum STATE
    {
        IDLE, RUN, ATTACK
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
            //case STATE.WALK:
               // Walk();
                //break;
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
        if(Vector3.Distance(target.transform.position,this.transform.position)<20f)
        {
            state = STATE.RUN;
        }
    }
    public void Run()
    {
        AllAnimationFalse();
        animator.SetBool("IsRun", true);
        agent.stoppingDistance = 5f;
        /*if (playerController.IsGameover == false)
        {
            agent.SetDestination(target.transform.position);
        }*/
        agent.SetDestination(target.transform.position);

        if (Vector3.Distance(target.transform.position,this.transform.position)< agent.stoppingDistance + 1f)
        {
            state = STATE.ATTACK;
        }
        if(Vector3.Distance(target.transform.position,this.transform.position)>30f)
        {
            state = STATE.IDLE;
        }
    }
    public void Attack()
    {
        AllAnimationFalse();
            animator.SetBool("IsAttack", true);
        transform.LookAt(target.transform.position);
        if (Vector3.Distance(target.transform.position,this.transform.position)>agent.stoppingDistance+1f)
        {
            state = STATE.RUN;
        }
        if (Vector3.Distance(target.transform.position, this.transform.position) > 30f)
        {
            state = STATE.IDLE;
        }
    }

    public void AllAnimationFalse()
    {
        animator.SetBool("IsAttack", false);
       // animator.SetBool("IsWalk", false);
        animator.SetBool("IsRun", false);

    }
}