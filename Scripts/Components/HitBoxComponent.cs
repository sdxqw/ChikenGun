using Godot;

namespace ChikenGun.Scripts.Components;

public partial class HitBoxComponent : Area2D
{
    [Export] private int Damage { get; set; } = 10;


    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }

    private void OnBodyEntered(Node body)
    {
        if (body is HurtBoxComponent hurtBox) hurtBox.HealthComponent.TakeDamage(Damage);
    }
}