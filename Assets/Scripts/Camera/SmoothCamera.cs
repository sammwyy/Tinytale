using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    [Header("Entity Follow")]
    [SerializeField]
    private float FollowRange = 1;
    [SerializeField]
    private float FollowSpeed = 2;
    private Entity _followTarget;
    private bool _following;

    public void Follow(Entity entity)
    {
        this._followTarget = entity;
    }

    void Update()
    {
        // Follow Target
        if (this._followTarget)
        {
            Vector2 currentPos = transform.position;
            Vector2 targetPos = this._followTarget.transform.position;
            float distance = Vector2.Distance(currentPos, targetPos);

            if (distance > FollowRange)
            {
                this._following = true;
            }
            else if (distance < 0.1)
            {
                this._following = false;
            }

            if (this._following)
            {
                Vector2 movement = Vector2.Lerp(transform.position, targetPos, this.FollowSpeed * Time.deltaTime);
                Vector3 movement3D = new Vector3(movement.x, movement.y, transform.position.z);
                transform.position = movement3D;
            }
        }
    }
}
