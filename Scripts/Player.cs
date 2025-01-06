using ChikenGun.Scripts.Components;
using Godot;

namespace ChikenGun.Scripts;

public partial class Player : CharacterBody2D
{
    private const float Speed = 300.0f;

    [Export] private HealthComponent HealthComponent { get; set; }
    [Export] private AnimatedSprite2D _animated;

    public override void _Ready()
    {
        if (HealthComponent == null)
        {
            GD.PushError("Player does not have a HealthComponent assigned!");
            return;
        }
        
        if (_animated == null)
        {
            GD.PushError("Player does not have an AnimatedSprite2D assigned!");
            return;
        }

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
            _animated.Play("run");
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            _animated.Play("idle");
        }
    
        // Flip the sprite based on velocity and mouse position
        if (velocity.X != 0)
        {
            _animated.FlipH = velocity.X < 0;
        }
        else
        {
            _animated.FlipH = GetGlobalMousePosition().X < GlobalPosition.X;
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}