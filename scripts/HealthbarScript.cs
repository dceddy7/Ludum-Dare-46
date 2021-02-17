using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarScript : MonoBehaviour
{
    public GameObject barFill;
    public GameObject barBackground;
    public float fillMax;
    public float fillAmount;
    bool show;

    void Update()
    {
        if (show)
        {
            barFill.transform.localScale = new Vector3(fillAmount / fillMax, 1, 1);
        }
    }

    public void hideBar()
    {
        barFill.SetActive(false);
        barBackground.SetActive(false);
        show = false;

    }

    public void showBar()
    {
        barFill.SetActive(true);
        barBackground.SetActive(true);
        show = true;
    }
}
