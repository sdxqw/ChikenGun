using Godot;

namespace ChikenGun.Scripts.Components;

[GlobalClass]
public partial class HurtBoxComponent : Area2D
{
    [Export] public HealthComponent HealthComponent { get; private set; }

    public override void _Ready()
    {
        if (HealthComponent == null)
            GD.PushError($"HurtBoxComponent on {Name} does not have a HealthComponent assigned!");
    }
}