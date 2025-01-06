using Godot;

namespace ChikenGun.Scripts.Components;

public partial class HurtBoxComponent : Area2D
{
    [Export] public HealthComponent HealthComponent { get; set; }

    public override void _Ready()
    {
        if (HealthComponent == null)
            GD.PushError($"HurtBoxComponent on {Name} does not have a HealthComponent assigned!");
    }
}