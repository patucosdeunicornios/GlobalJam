using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaves : MonoBehaviour
{
    Component mayor;
    Component middle;
    Component lower;

    public float secondsToLive = 3f;
    public float currentAge = 0;

    void Start()
    {

        setWaves();
        Object.Destroy(gameObject, secondsToLive);
    }

    void Update()
    {

    }

    void setWaves()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "mayor")
            {
                mayor = child;
            }
            else if (child.name == "middle")
            {
                middle = child;
            }
            else
            {
                lower = child;
            }
        }
        
        // setVisibilityAll(false);
    }

    void setVisibilityAll(bool visibility)
    {
        mayor.GetComponent<Renderer>().enabled = visibility;
        middle.GetComponent<Renderer>().enabled = visibility;
        lower.GetComponent<Renderer>().enabled = visibility;
    }

    void setVisibilityOne(Component component, bool visibility)
    {
        component.GetComponent<Renderer>().enabled = visibility;
    }


    private float maxLevel = 3f;
    void activate(Component component, float opacity, float level)
    {
        //4/3 = 1.3 
        Renderer rend = component.GetComponent<Renderer>();
        rend.enabled = true;
        if ((opacity / maxLevel) < level)
        {
            opacity = opacity % maxLevel;
        }

        if (opacity > 3) opacity = 3;

        Debug.Log(component.name);

        
        // Color color = rend.material.color;
        // color.a = 0.25f * opacity;
        // rend.material.SetColor("_Color", color);
    }

    public void setIntensity(int intensity)
    {
        
        setWaves();
        Debug.Log("Intensity" + intensity);
        activate(lower, intensity, 0);
        if (intensity > 3)
        {
            activate(middle, intensity, 2);

            if (intensity > 6)
            {
                activate(mayor, intensity, 3);
            }
        }

    }
}
