using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float playerDistance;
    [SerializeField] private float speed = 1.0f;
    private Rigidbody enemyRb;
    private GameObject player;

    private bool stopped = false;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerControllerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(player.transform.position, transform.position);
        Vector3 lookDiretion = (player.transform.position - transform.position).normalized;

        if (!stopped && playerDistance < 10)
        {
            transform.Translate(lookDiretion * Time.deltaTime * speed);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GrabPlayer());
        }
    }

    private IEnumerator GrabPlayer()
    {
        Debug.Log("Grabbed!");
        playerControllerScript.grabbed = true;
        stopped=true;
        yield return new WaitForSeconds(2);
        playerControllerScript.grabbed = false;
        stopped=false;
        
    }
    
}
