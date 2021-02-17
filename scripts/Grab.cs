using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{

    public float radius = 1f;
    public int damage = 5;
    public bool holding = false;
    public GameObject held;
    public float xOffset;
    public float yOffset;
    public AudioSource audioPlayer;
    public AudioClip releaseNoise;
    public AudioClip pickupNoise;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(this.transform.position, this.transform.position + new Vector3(radius, 0, 0), Color.green);
        if (Input.GetButtonDown("Action"))
        {
            Debug.Log("action pressed");
            Action((new Vector2(transform.position.x, transform.position.y)), radius, holding); 
        }
        if (held != null)
        {
            held.transform.position = this.transform.position + new Vector3(xOffset, yOffset, 0);
        }

        if (held == null)
        {
            holding = false;
        }
    }

    void Action(Vector2 center, float radius, bool isHolding)
    {
        Debug.Log("action function entered");
        //int layerMask = 1 << 9; //Layer 9
        if (isHolding)
        {
            audioPlayer.clip = releaseNoise;
            audioPlayer.Play();
            Debug.Log("released");
            held.SendMessage("OnRelease");
        } else
        {
            audioPlayer.clip = pickupNoise;
            audioPlayer.Play();
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);
            Debug.Log(hitColliders);
            int i = hitColliders.Length - 1;
            while (i >= 0 && holding == false)
            {
                Debug.Log(hitColliders[i]);
                hitColliders[i].gameObject.SendMessage("OnPickup");
                hitColliders[i].gameObject.SendMessage("Interact", damage);
                i--;
            }
        }
    }
}
