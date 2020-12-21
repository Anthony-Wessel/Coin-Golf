using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    bool draggingCoin = false;

    Vector2 dragOrigin;
    Vector2 dragEnd;

    [SerializeField] float maxForce = 5;
    [SerializeField] float minForce = 1;

    Rigidbody rb;
    ExtendableArrow arrow;

    Vector3 force;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        arrow = GetComponentInChildren<ExtendableArrow>();
        arrow.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Player is dragging to launch the coin
        if (draggingCoin)
        {
            // Grab the current mouse position as the new end point
            dragEnd = Input.mousePosition;
            UpdateForce();
            if (force != Vector3.zero)
            {
                // Make the arrow visible
                arrow.gameObject.SetActive(true);

                // Set the arrow's length
                arrow.SetLength((force.magnitude - minForce) / (maxForce - minForce));

                // Set the arrow's rotation
                float rotation = -Mathf.Atan2(force.z, force.x) * Mathf.Rad2Deg - 90;
                arrow.transform.rotation = Quaternion.Euler(0, rotation, 0);
            }
            else
            {
                // Hide the arrow
                arrow.gameObject.SetActive(false);
            } 
        }
        else
        {
            // Hide the arrow
            arrow.gameObject.SetActive(false);
        }

        // LMB Down
        if (Input.GetMouseButtonDown(0))
        {
            if (!isMoving() && RaycastCoin())
            {
                // Grab the current mouse position as the origin
                dragOrigin = Input.mousePosition;
                draggingCoin = true;
            }
            else
            {
                // Rotate camera
            }
        }
        // LMB Up
        else if (Input.GetMouseButtonUp(0))
        {
            if (draggingCoin)
            {
                if (force != Vector3.zero)
                {
                    // Launch the coin
                    rb.AddForce(force, ForceMode.Impulse);
                    GameManager.AddStroke();
                }
                
                draggingCoin = false;
            }
        }
    }

    // Returns true if coin is moving, false if it is still
    bool isMoving()
    {
        return rb.velocity.magnitude != 0;
    }

    // Returns true if mouse is over the coin
    bool RaycastCoin()
    {
        return Raycast("Player");
    }

    // Returns true if mouse is over an object in the target layer
    bool Raycast(string targetLayer)
    {
        // Create the ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit info;

        // Raycast
        return Physics.Raycast(ray, out info, LayerMask.GetMask(targetLayer));
    }

    // Updates the force that will be used to launch the coin
    void UpdateForce()
    {
        // Convert the screen points to world points
        Vector3 originWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(dragOrigin.x, dragOrigin.y, Camera.main.nearClipPlane));
        Vector3 endWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(dragEnd.x, dragEnd.y, Camera.main.nearClipPlane));
        
        // Calculate the force based on origin and end points
        force = (originWorldPoint - endWorldPoint) * 50;

        // Clamp the force values
        if (force.magnitude < minForce)
        {
            force = Vector3.zero;
        }
        if (force.magnitude > maxForce)
        {
            force = force.normalized * maxForce;
        }
    }
}
