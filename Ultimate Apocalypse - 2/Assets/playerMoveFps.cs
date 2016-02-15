using UnityEngine;
using System.Collections;

public class playerMoveFps : MonoBehaviour {
    //init var for animations
    public int speedFloat;

    public float turningSpeed = 100;
    public float moveSpeed = 10f;

    //init for animation
    private Animator anim;
    private HashIDs hash;


    void Awake()
    {
        anim = GetComponent<Animator>();
        //hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();

        // Set the weight of the shouting layer to 1.
        //anim.SetLayerWeight(1, 1f);
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if ( v != 0f)
        {
            //Rotating(horizontal, vertical);
            //Debug.Log("run");
            GetComponent<Animator>().SetFloat("playerSpeed", 5.5f);
            // transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.Translate(0, 0, moveSpeed * Time.deltaTime * v);
            //anim.SetFloat(hash.speedFloat, 5.5f);
            //anim.SetFloat(speedFloat, 5.5f);

        }
        if (h != 0f)
        {
            transform.Rotate(0, turningSpeed * Time.deltaTime * h , 0);
            //anim.SetFloat(hash.speedFloat, 5.5f);
        }

        if ( v == 0) {

            //anim.SetFloat(hash.speedFloat, 0);
            GetComponent<Animator>().SetFloat("playerSpeed", 0);
        }
    }
    
}
