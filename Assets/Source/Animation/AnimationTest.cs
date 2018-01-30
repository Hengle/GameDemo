using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour {
    private AnimationManager animationManager;
	// Use this for initialization
	void Start () {
        animationManager = new AnimationManager(transform);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animationManager.CrossFade("Attack");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            animationManager.CrossFade("Attack1");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            animationManager.CrossFade("Attack2");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            animationManager.CrossFade("Idle");
        }
    }
}
