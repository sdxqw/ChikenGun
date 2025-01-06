using ChikenGun.Scripts.Components;
using Godot;

namespace ChikenGun.Scripts;

public partial class RedotEnemy : CharacterBody2D
{
    [Export] private HealthComponent HealthComponent { get; set; }

    public override void _Ready()
    {
        if (HealthComponent == null)
        {
            GD.PushError("RedotEnemy does not have a HealthComponent assigned!");
            return;
        }

        HealthComponent.OnDamage += OnDamage;
    }

    private void OnDamage(int damageTaken, int currentHealth)
    {
        GD.Print($"RedotEnemy took {damageTaken} damage! Current health: {currentHealth}");
    }

    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }
}