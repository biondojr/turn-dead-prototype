using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    [SerializeField]
    private float height = 9f;
    [SerializeField]
    private float distance = 6f;
    [SerializeField]
    private float angle = 45f;
    [SerializeField]
    private float rotationSpeed = 0.5f;
    void Start()
    {
        HandleCamera();
    }

    // Update is called once per frame
    void Update()
    {
        HandleCamera();
    }

    protected virtual void HandleCamera()
    {
        if(!target)
        {
            return;
        }
        
        float horizontalInput = Input.GetAxis("Horizontal");
        angle += horizontalInput * rotationSpeed;

        Vector3 worldPosition = (Vector3.forward * distance) + (Vector3.up * height);
        Vector3 rotatedVector = Quaternion.AngleAxis(angle, Vector3.up) * worldPosition;
        Vector3 cameraPosition = target.position + rotatedVector;

        transform.position = cameraPosition;
        transform.LookAt(target.position);


    }
}
