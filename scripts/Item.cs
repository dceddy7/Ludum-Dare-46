using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IGrabbable
{
    public int fuelVal;
    public int itemTier;
    Rigidbody2D rb;
    AudioSource aud;
    void Start()
    {
        aud = this.GetComponent<AudioSource>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void Burn()
    {
        aud.Play();
        Destroy(this.gameObject, .5f);
    }

    public void OnPickup()
    {
        Debug.Log("OnPickup called on " + this.gameObject);
        rb.simulated = false;
        //Debug.Log("passed 1");
        Grab player = GameObject.FindGameObjectWithTag("Player").GetComponent<Grab>();
        //Debug.Log("passed 2");
        player.held = this.gameObject;
        //Debug.Log("passed 3");
        player.holding = true;
        //Debug.Log("passed 4");
    }

    public void OnRelease()
    {
        Grab player = GameObject.FindGameObjectWithTag("Player").GetComponent<Grab>();
        rb.simulated = true;
        player.holding = false;
        player.held = null;
        if (CharacterController2D.m_FacingRight)
        {
            rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            rb.AddForce(Vector2.right * 3, ForceMode2D.Impulse);
        } else
        {
            rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            rb.AddForce(Vector2.left * 3, ForceMode2D.Impulse);
        }
    }
}
