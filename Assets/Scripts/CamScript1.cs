using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float maxDistance = 10f;
    public float minDistance = 3f;
    public float followSpeed = 5f;

    private Vector3 offset;
    private float currentDistance;

    void Start()
    {
        offset = transform.position - player.position;
        currentDistance = offset.magnitude;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = player.position + offset.normalized * currentDistance;
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > maxDistance)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            currentDistance = maxDistance;
        }
        else if (distance < minDistance)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            currentDistance = minDistance;
        }
        else
        {
            currentDistance = distance;
        }

        transform.LookAt(player);
    }
}
