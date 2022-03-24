using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NavMovement : MonoBehaviour
{
    private Animator _animator;

    private static readonly int Speed = Animator.StringToHash("Speed");


    public Transform target;
//create and get a reference to the MeshAngnet
    private NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 meshPosition = GetNavmecshPosition(target.position);
        // _agent.SetDestination(meshPosition);
        _animator.SetFloat(Speed, transform.position.magnitude);

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           if (Physics.Raycast(ray, out RaycastHit hitInfo))
           {
               _agent.SetDestination(hitInfo.point);
           }
        }
    }

    Vector3 GetNavmecshPosition(Vector3 samplePosition)
    {
        NavMesh.SamplePosition(samplePosition, out NavMeshHit hitInfo, 100f, -1);
        return hitInfo.position;
    }
}
