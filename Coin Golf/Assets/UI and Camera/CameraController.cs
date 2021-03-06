using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    bool draggingCamera;
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Rotate
        if (draggingCamera)
        {
            if (Input.GetMouseButtonUp(1))
                draggingCamera = false;

            float x = Input.GetAxisRaw("Mouse X");
            float y = -Input.GetAxisRaw("Mouse Y");

            transform.Rotate(Vector3.up, x, Space.World);
            transform.Rotate(Vector3.right, y, Space.Self);
        }
        else
        {
            if (Input.GetMouseButtonDown(1))
                draggingCamera = true;
        }
    }

    private void LateUpdate()
    {
        // Chase player
        if (transform.position.y > -3)
            transform.position = Vector3.Lerp(transform.position, player.position, 4*Time.deltaTime);
        
    }
}
