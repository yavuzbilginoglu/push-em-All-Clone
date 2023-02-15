using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3  offset;
    [SerializeField] private float chaseSpeed = 5;
    void Start()
    {

        if(!target)
        {
            target = GameObject.FindObjectOfType<PlayerMovement>().transform;
        }
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, chaseSpeed * Time.deltaTime);
        
    }
}
