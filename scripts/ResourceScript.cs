using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScript : MonoBehaviour, I_Interactable
{
    public int maxHealth;
    public GameObject droppedItem;
    public int droppedAmount = 3;
    public SpriteRenderer spriteObj;
    public Sprite harvestedSprite;
    public Sprite unharvestedSprite;
    public float respawnTime;
    public HealthbarScript healthbar;

    int resourceHealth;
    bool harvested = false;
    // Start is called before the first frame update
    void Start()
    {
        healthbar.fillMax = maxHealth;
        healthbar.fillAmount = maxHealth;
        resourceHealth = maxHealth;
        spriteObj = this.gameObject.GetComponent<SpriteRenderer>();
        spriteObj.sprite = unharvestedSprite;
        healthbar.hideBar();
    }

    

    public void Interact(int damage)
    {
        
        if (resourceHealth > 0)
        {
            resourceHealth -= damage;
            healthbar.fillAmount = resourceHealth;
        }
        if(resourceHealth != maxHealth && harvested == false)
        {
            healthbar.showBar();
        }
        else
        {
            healthbar.hideBar();
        }
        if (resourceHealth <= 0 && harvested == false)
        {
            HarvestResource();
        }
    }

    public void HarvestResource()
    {
        for (int i = 0; i < droppedAmount; i++) {
            Instantiate(droppedItem, transform.position + new Vector3(Random.Range(-.5f, .5f), i * .5f,0), Quaternion.identity);
        }
        harvested = true;
        spriteObj.sprite = harvestedSprite;
        healthbar.hideBar();

        StartCoroutine("RespawnResource", respawnTime);
    }

    IEnumerator RespawnResource(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        spriteObj.sprite = unharvestedSprite;
        harvested = false;
        resourceHealth = maxHealth;
        healthbar.fillAmount = maxHealth;
    }
}
