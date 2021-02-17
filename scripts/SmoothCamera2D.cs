using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera2D : MonoBehaviour
{

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    private Camera mainCamera;
    public float Y_offset;
    public float X_offset;
    private void Start()
    {
        mainCamera = this.GetComponent<Camera>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    } 

    // Update is called once per frame
    void Update()
    {
        if (target)
        {

            Vector3 targetWithOffset = target.position + new Vector3(X_offset, Y_offset, 0);
            Vector3 point = mainCamera.WorldToViewportPoint(target.position);
            Vector3 delta = targetWithOffset - mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}
