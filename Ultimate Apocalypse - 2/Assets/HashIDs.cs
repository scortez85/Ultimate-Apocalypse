using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {
    public int speedFloat;
    public int isJumping;
    // Use this for initialization
    void Awake () {
        speedFloat = Animator.StringToHash("Speed");
        isJumping = Animator.StringToHash("isJumping");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
