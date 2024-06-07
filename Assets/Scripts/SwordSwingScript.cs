using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwingScript : MonoBehaviour
{
    public Animator anim;

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            StartCoroutine(SwingSword());
            // anim.Play("Default", 0);
        }
    }

    IEnumerator SwingSword() {
        anim.Play("SwordSwingRightHand", 0);
        yield return new WaitForSeconds(.5f);
        anim.Play("Default", 0);
    }
}
