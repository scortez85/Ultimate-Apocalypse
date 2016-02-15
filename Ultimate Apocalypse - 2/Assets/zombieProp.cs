using UnityEngine;
using System.Collections;

public class zombieProp : MonoBehaviour {

    public float xspeed = 1f;
    public float delay = 0;
	// Use this for initialization
	void Start () {
        delay = Random.Range(1f, 35f);
	
	}
	
	// Update is called once per frame
	void Update () {
        if (delay > 0)
            delay-=Time.deltaTime;
        if (delay  <1)
        {
            transform.Translate(0, 0, xspeed * Time.deltaTime);
            GetComponent<Animator>().SetBool("zombieActive", true);
            GetComponent<Animator>().SetFloat("speed", 2);
        }
	}
}
