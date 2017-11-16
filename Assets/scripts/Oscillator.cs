using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : StateMachineBehaviour {

    public GameObject starHead;
    public float x;
    public float y;
    public float z;
    public float speed;
    public float width;
    public float height;

    private float timeCounter = 0;

    public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        x = 0;
        y = 0;
        z = 0;
    }

    public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        timeCounter += Time.deltaTime * speed;
        x = Mathf.Cos(timeCounter) * width;
        y = Mathf.Sin(timeCounter) * height;
        z = 0;

        starHead.transform.position = new Vector3(x, y, z);
    }

    public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
                x = 0;
        y = 0;
        z = 0;
        Debug.Log("End Idle State");
    }
}
