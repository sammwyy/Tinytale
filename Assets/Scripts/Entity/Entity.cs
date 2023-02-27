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
    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidBody;

    public bool IsAlive
    {
        get { return this.Health > 0; }
    }

    public void Kill()
    {
        this.Health = 0;
        this._renderer.enabled = false;
    }

    public void Spawn(float x, float y)
    {
        this.Health = this.MaxHealth;
        this.Teleport(x, y);
        this._renderer.enabled = true;
    }

    public void Teleport(float x, float y)
    {
        this.transform.position = new Vector2(x, y);
    }

    protected void Awake()
    {
        this._animator = this.GetComponent<Animator>();
        this._renderer = this.GetComponent<SpriteRenderer>();
        this._rigidBody = this.GetComponent<Rigidbody2D>();

        this._renderer.enabled = false;
    }

    protected void Update()
    {
        // Handle animations.
        if (this.IsAlive && this._animator)
        {
            this._animator.SetFloat("Animation", (float)this.Motion);
            this._animator.SetFloat("Variant", (float)this.Direction);
        }
    }

    protected void FixedUpdate()
    {
        // Handle movement.
        bool walking = this.Motion == EntityMotion.WALKING;
        bool running = this.Motion == EntityMotion.RUNNING;

        if (this.IsAlive && (walking || running))
        {
            Vector3 movement = this.Direction.ToVector3D();
            float speed = (walking ? this.WalkSpeed : this.RunSpeed);
            this._rigidBody.MovePosition(transform.position + movement * (speed * Time.deltaTime));
        }
    }
}
