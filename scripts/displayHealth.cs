using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class displayHealth : MonoBehaviour
{

    public Text health;
    // Start is called before the first frame update
    void Start()
    {
        health = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "" + FireController.FIRE_HEALTH;
    }
}
