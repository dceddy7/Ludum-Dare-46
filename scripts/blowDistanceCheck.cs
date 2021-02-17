using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blowDistanceCheck : MonoBehaviour
{
    public GameObject button;
    private void Start()
    {
        button.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("testing");
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("blow fire");
            button.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("testing");
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("blow fire");
            button.SetActive(false);
        }
    }


}
