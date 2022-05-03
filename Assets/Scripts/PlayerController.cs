using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    
    public NavMeshAgent playerAgent;
    public GameObject targetDestination;
    public GameObject footprint;
    public Camera cam;
    public bool grabbed = false;
    private Vector3 lastPos;
    private Rigidbody playerRigidBody;
    private Animator playerAnimator;
    private NavMeshPath path;

    void Start()
    {
        lastPos = transform.position;
        playerRigidBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        path = new NavMeshPath();

        
    }

    void Update()
    {
        if (CharacterIsMoving()){
            playerAnimator.SetBool("isWalking", true);
        } 
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;
            if (Physics.Raycast(ray, out hitPoint))
            {
                if (!grabbed){
                    playerAgent.isStopped = false;
                    playerAgent.SetDestination(hitPoint.point);
                    DrawPath(hitPoint.point);
                }
                else if (grabbed)
                {
                    playerAgent.isStopped = true;
                }   
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Footsteps")){
            Destroy(other.gameObject);
        }
    }

    private bool CharacterIsMoving()
    {
        Vector3 displacement = transform.position - lastPos;
        lastPos = transform.position;

        if (displacement.magnitude > 0.001)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void DrawPath(Vector3 destination)
    {
        CleanPath();
        NavMesh.CalculatePath(playerAgent.transform.position, destination, NavMesh.AllAreas, path);
        Vector3 clickPoint = new Vector3(destination.x, destination.y + 0.2f, destination.z);

        GameObject clickPointPrefab = Instantiate(targetDestination, clickPoint, targetDestination.transform.rotation);

        // Loop through corners
        for (int i = 0; i < path.corners.Length -1; i++) {
             
            float distance = Vector3.Distance(path.corners[i], path.corners[i + 1]);
            Vector3 direction = (path.corners[i + 1] - path.corners[i]).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            // Footprint pointed to direction
            footprint.transform.rotation = lookRotation;
            footprint.transform.Rotate(90,0,0);

            // Loop through straight path to instantiate footprints
            for(int f = 1; f < distance; f++)
            {
                Vector3 position = path.corners[i] + (direction * f);
                
                // Check distance between footprints and click point
                if (Vector3.Distance(clickPointPrefab.transform.position, position) > 0.5)
                {
                    Instantiate(footprint, position, footprint.transform.rotation);
                }

            }
        }
        
    }

    void CleanPath()
    {
        GameObject[] footprints = GameObject.FindGameObjectsWithTag("Footsteps");
        GameObject clickPoint = GameObject.FindGameObjectWithTag("Click Point");
        Destroy(clickPoint);
        for(int i=0; i < footprints.Length; i++)
        {
            Destroy(footprints[i]);
        }
    }   

    void OnLadder(){
        
    }

}