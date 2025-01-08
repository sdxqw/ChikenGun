using ChikenGun.Scripts.Components;
using Godot;
using GodotUtilities;

namespace ChikenGun.Scripts;

[Scene]
public partial class Player : CharacterBody2D
{
    private const float Speed = 300.0f;

    [Node] public HealthComponent HealthComponent { get; private set; }
    [Node] private AnimatedSprite2D AnimatedSprite2D { get; set; }

    public override void _Notification(int what)
    {
        if (what == NotificationSceneInstantiated) WireNodes();
    }

    public override void _Ready()
    {
        HealthComponent.OnDamage += OnDamage;
    }

    private void OnDamage(int damageTaken, int currentHealth)
    {
        GD.Print($"Player took {damageTaken} damage! Current health: {currentHealth}");
    }

    public override void _PhysicsProcess(double delta)
    {
        var velocity = Velocity;

        var direction = Input.GetAxis("MoveLeft", "MoveRight");
        if (direction != 0)
        {
            velocity.X = direction * Speed;
            AnimatedSprite2D.Play("run");
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            AnimatedSprite2D.Play("idle");
        }

        // Flip the sprite based on velocity and mouse position
        if (velocity.X != 0)
            AnimatedSprite2D.FlipH = velocity.X < 0;
        else
            AnimatedSprite2D.FlipH = GetGlobalMousePosition().X < GlobalPosition.X;

        Velocity = velocity;
        MoveAndSlide();
    }
}