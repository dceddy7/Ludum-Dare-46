using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerThoughtScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float xOffset;
    public float yOffset;
    public SpriteRenderer sprite;

    
    public bool PLAYER_SPEECH_ENABLED = false;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PLAYER_SPEECH_ENABLED && (sprite.enabled == false))
        {
            sprite.enabled = true;
        } 
        if((PLAYER_SPEECH_ENABLED) == false && (sprite.enabled))
        {
            sprite.enabled = false;
        }

        this.transform.position = target.position + new Vector3(xOffset, yOffset, 0);
    }
}
