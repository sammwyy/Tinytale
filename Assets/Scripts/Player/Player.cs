using UnityEngine;

public class Player : EntityWithInventory
{
    void UpdateMovement()
    {
        this.Motion = EntityMotion.WALKING;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.Direction = EntityDirection.UP;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.Direction = EntityDirection.LEFT;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.Direction = EntityDirection.DOWN;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.Direction = EntityDirection.RIGHT;
        }
        else
        {
            this.Motion = EntityMotion.IDLE;
        }
    }

    new void Update()
    {
        this.UpdateMovement();

        base.Update();
    }
}
