using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject player;
    public float distance = 5f;
    public float speed = 5f;
	public float resetSpeed = 50f;
    private Vector3 offset = new Vector3(0f, 2.4f, 0f); 

    private bool z;

    void LateUpdate() {

		// This is an attempt to replicate Ocarina of Time's camera. 
		// There is a bug when you walk into the camera, it kinda goes crazy. I couldn't fix this!

        Vector3 desiredPosition = player.transform.position - player.transform.forward * distance + offset;
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (!z && Input.GetButton("Z")) {
            z = true;
        }
        else if (z) {
            transform.LookAt(player.transform);
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, resetSpeed * Time.deltaTime);

            if (transform.position == desiredPosition) {
                z = false;
            }
        }
        else {
            if (dist > distance * 2) {
                transform.position = Vector3.MoveTowards(transform.position, desiredPosition, speed * 3 * Time.deltaTime);
            }
            else if (dist < distance) {
                transform.LookAt(player.transform);
            }
            else {
                transform.position = Vector3.MoveTowards(transform.position, desiredPosition, speed * Time.deltaTime);
            }
            transform.LookAt(player.transform);
        }
    }
}