using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherScript : MonoBehaviour
{
    private SpriteRenderer skyGadient;
    Color lerpedColor = Color.white;
    public float speed = .01f;
    float startTime;

    public float dayLength = 30f;
    private float dayTimer;

    public float nightLength = 30f;
    private float nightTimer;

    public bool nightTime = false;

    float transitionTime = 0;

    public static bool NIGHT_ENABLED = false;
    void Start()
    {
        skyGadient = GameObject.FindGameObjectWithTag("Sky").GetComponent<SpriteRenderer>();
    }



    void Update()
    {
        if (NIGHT_ENABLED)
        {
            if (nightTime == false)
            {
                dayTimer += Time.deltaTime;
            }
            else
            {
                nightTimer += Time.deltaTime;
            }

            if (dayTimer > dayLength)
            {
                Debug.Log("It's Night Time");
                nightTime = true;
                dayTimer = 0;
                transitionTime = 0;
            }

            if (nightTimer > nightLength)
            {
                Debug.Log("It's Day Time");
                nightTime = false;
                nightTimer = 0;
                transitionTime = 0;
            }

            if (nightTime)
            {
                transitionTime += (Time.deltaTime * speed);
                skyGadient.color = Color.Lerp(Color.white, Color.black, transitionTime);
            }
            else
            {
                transitionTime += (Time.deltaTime * speed);
                skyGadient.color = Color.Lerp(Color.black, Color.white, transitionTime);
            }
        }
    }
}
