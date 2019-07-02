using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

    Transform target;
    NavMeshAgent navMeshAgent;

	// Use this for initialization
	void Start () {
        navMeshAgent = GetComponent<NavMeshAgent>();
	}

    void Update()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.position);
            FaceTarget();
        }

        
    }

    public void MoveToPoint(Vector3 point)
    {
        navMeshAgent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        navMeshAgent.stoppingDistance = newTarget.radius * 0.8f;
        navMeshAgent.updateRotation = false;
        target = newTarget.interactionTransform; 
    }
    
    public void StopFollowingTarget()
    {
        navMeshAgent.stoppingDistance = 0f;
        navMeshAgent.updateRotation = true;
        target = null; 
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
