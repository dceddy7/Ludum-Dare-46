using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[System.Serializable]
public class FireController : MonoBehaviour
{
    [SerializeField]
    public static int FIRE_HEALTH;
    public static int BURN_TIER;

    [SerializeField]
    public ParticleSystem[] particles;
    int state = 0;
    public int maxState;
    public Text fireText;

    float time;
    public float timer = 10f;

    float blowTime;
    public float blowTimer = 1f;
    public int blowVal;
    public AudioSource audioPlayer;
    public AudioClip blowNoise;

    public List<FireState> states;
    FireState currentState;

    SceneScript manager;

    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneScript>();
        maxState = states.Capacity - 1;
        //turns off particles
        foreach(ParticleSystem part in particles)
        {
            part.Stop();
        }
        currentState = states[0];
        currentState.effect.Play();
        BURN_TIER = currentState.burnTier;
        Debug.Log(currentState.displayName);
        Debug.Log(currentState.displayColor);
        fireText.text = currentState.displayName;
        fireText.color = currentState.displayColor;
    }

    // Update is called once per frame
    void Update()
    {
        blowTime += Time.deltaTime;
        time += Time.deltaTime;
        CheckState(FIRE_HEALTH);

        if(FIRE_HEALTH >= 15000 && !gameOver)
        {
            Debug.Log("attempting end");
            gameOver = true;
            StartCoroutine("GameOver", 5f);
        }
    }

    private void CheckState(int health)
    {
        if(health > currentState.healthMax)
        {
            ChangeState(state++);
        } else if (health < currentState.healthMin)
        {
            ChangeState(state--);
        }
    }


    private void ChangeState(int futureState)
    {
        if (futureState >= 0)
        {
            currentState.effect.Stop();

            currentState = states[futureState];

            Debug.Log(currentState.displayName);
            Debug.Log(currentState.displayColor);

            currentState.effect.Play();
            BURN_TIER = currentState.burnTier;
            fireText.text = currentState.displayName;
            fireText.color = currentState.displayColor;

           
        }
        /*
        particles[state].Stop();
        particles[futureState].Play();
        if(futureState == 3)
        {
            WeatherScript.NIGHT_ENABLED = true;
        }
        state++;
        */


    }

    public void Blow()
    {
        if(blowTime > blowTimer)
        {
            FIRE_HEALTH += blowVal;
            blowTime = 0;
            audioPlayer.clip = blowNoise;
            audioPlayer.Play();
        }
        
    }

    IEnumerator GameOver(float waitTime)
    {
        Debug.Log("ending");
        yield return new WaitForSeconds(waitTime);
        manager.EndGame();
    }

}
