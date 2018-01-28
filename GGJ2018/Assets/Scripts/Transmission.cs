using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Transmission : MonoBehaviour {

    [HideInInspector]
    public NavMeshAgent playerAgent;
    public bool hasInteracted;
    public GameObject player = null;
    public float promptDistance = 3;

    public string promptMessage = "PRESS E (CHANGE THIS TEXT DYANNA)";

    public enum States { IDLE, WAITING, INTERACTING}
    public States currentState = States.IDLE;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 3f;
        playerAgent.destination = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        currentState = States.IDLE;
    }

    void Update()
    {
        if(currentState == States.IDLE)
        {
            DoIdle();
        }
        else if(currentState == States.WAITING)
        {
            DoWaiting();
        }
    }

    void DoIdle()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (distanceToPlayer <= promptDistance)
        {
            currentState = States.WAITING;
            PromptManager.SetText(promptMessage);
            PromptManager.SetVisible(true);
        }
    }

    void DoWaiting()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if(distanceToPlayer > promptDistance)
        {
            currentState = States.IDLE;
            PromptManager.SetVisible(false);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            currentState = States.INTERACTING;
            Interact(); //delete this
            PromptManager.SetVisible(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, promptDistance);
    }

    public virtual void Interact() //delete this
    {
        Debug.Log("Interacting with base class");
    }
}
