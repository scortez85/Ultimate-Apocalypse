using UnityEngine;
using System.Collections;

public class printAni : MonoBehaviour {

    public bool playClip = false;
    public float aniTime = 10f;
    public Animation ani;
    public GameObject allSpark;
	void Start () {
        ani = GetComponent<Animation>();
        //ani.Play("letsCreate0");
        ani.Stop();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (aniTime > 0)
            aniTime--;

        if (playClip && aniTime>0)
        {
            ani.Play("letsCreate0");
            allSpark.active = true;
            
        }

        if (aniTime == 0)
        {
            ani.Stop();
            allSpark.active = false;
        }
	}
}
