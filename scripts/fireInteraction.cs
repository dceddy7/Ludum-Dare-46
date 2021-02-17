using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("testing");
        if (collision.gameObject.tag == "Flamable")
        {
            Debug.Log("burn baby burn");
            Item fuel = collision.gameObject.GetComponent<Item>();
            if (fuel.itemTier <= FireController.BURN_TIER)
            {
                FireController.FIRE_HEALTH += fuel.fuelVal;
                fuel.Burn();
            }
        }
    }

}
