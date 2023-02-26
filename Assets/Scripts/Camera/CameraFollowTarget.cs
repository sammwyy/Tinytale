using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    [SerializeField]
    private float FollowSpeed = 2;
    [SerializeField]
    private GameObject FollowTarget;

    void Update()
    {
        // Follow Target
        if (this.FollowTarget)
        {
            Vector3 currentPos = transform.position;
            Vector3 targetPos = this.FollowTarget.transform.position;
            targetPos.z = currentPos.z;

            Vector3 movement = Vector3.Lerp(transform.position, targetPos, this.FollowSpeed * Time.deltaTime);
            transform.position = movement;
        }
    }
}
