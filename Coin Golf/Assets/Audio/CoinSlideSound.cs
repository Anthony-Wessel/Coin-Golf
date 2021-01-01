using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSlideSound : MonoBehaviour
{
    public AudioClip slideSound;
    AudioSource src;
    Rigidbody playerRB;
    

    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = playerRB.velocity.magnitude;
        
        if (speed > 0 && isGrounded())
        {
            if (!src.isPlaying)
                src.PlayOneShot(slideSound);

            src.volume = speed / 3;
        }
        if (!isGrounded()) src.Stop();
    }

    bool isGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hitInfo;

        return Physics.Raycast(ray, out hitInfo, 1f, LayerMask.GetMask("Table"));
    }
    
}
