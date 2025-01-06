using ChikenGun.Scripts.Components;
using Godot;

namespace ChikenGun.Scripts;

public partial class Player : CharacterBody2D
{
    private const float Speed = 300.0f;

    [Export] private HealthComponent HealthComponent { get; set; }

    public override void _Ready()
    {
        if (HealthComponent == null)
        {
            GD.PushError("Player does not have a HealthComponent assigned!");
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

        var direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if (direction != Vector2.Zero)
            velocity.X = direction.X * Speed;
        else
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);

        Velocity = velocity;
        MoveAndSlide();
    }
}