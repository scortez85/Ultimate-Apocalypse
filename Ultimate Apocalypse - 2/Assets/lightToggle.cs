using UnityEngine;
using System.Collections;

public class lightToggle : MonoBehaviour {

    // Use this for initialization
    public GameObject redLight;
    public GameObject greenLight;
    public float lightTimer1 = 3;
	void Start () {
        redLight.GetComponent<Light>().enabled = false;
        greenLight.GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update() {
        if (lightTimer1 > 0)
            lightTimer1 -= Time.deltaTime;
        else if (lightTimer1 < 1)
            lightTimer1 = 5;

        if (lightTimer1 < 2)
        {
            redLight.GetComponent<Light>().enabled = true;
            greenLight.GetComponent<Light>().enabled = false;
            //lightTimer1 = 10;
        }
        else
        {
            redLight.GetComponent<Light>().enabled = false;
            greenLight.GetComponent<Light>().enabled = true;
        }

        }

   
}
