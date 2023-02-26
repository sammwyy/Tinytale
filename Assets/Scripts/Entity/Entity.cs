using UnityEngine;

public class Entity : MonoBehaviour
{
    public EntityDirection Direction = EntityDirection.DOWN;
    public EntityMotion Motion = EntityMotion.IDLE;
    public float Health = 0;
    public float MaxHealth = 0;
    public float WalkSpeed = 0;
    public float RunSpeed = 0;

    private Animator _animator;

    public bool IsAlive()
    {
        return this.Health > 0;
    }

    protected void Awake()
    {
        this._animator = this.GetComponent<Animator>();
    }

    protected void Update()
    {
        // Handle animations.
        if (this._animator)
        {
            this._animator.SetFloat("Animation", (float)this.Motion);
            this._animator.SetFloat("Variant", (float)this.Direction);
        }

        // Handle movement.
        bool walking = this.Motion == EntityMotion.WALKING;
        bool running = this.Motion == EntityMotion.RUNNING;

        if (walking || running)
        {
            Vector3 movement = this.Direction.ToVector3D() * Time.deltaTime;
            this.transform.Translate(movement * (walking ? this.WalkSpeed : this.RunSpeed));
        }
    }
}
