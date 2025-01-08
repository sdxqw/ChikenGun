using Godot;
using GodotUtilities.Util;

namespace ChikenGun.Scripts.Components;

[GlobalClass]
public partial class HitBoxComponent : Area2D
{
    [Export] private int Damage { get; set; } = 10;
    
    public override void _Ready()
    {
        AreaEntered += OnAreaEntered;
    }

    private void OnAreaEntered(Area2D area)
    {
        if (area is not HurtBoxComponent hurtBox) return;
        if (hurtBox.GetParent() == GetParent())
            Logger.Error($"Layer and Mask collision between {Name} and {hurtBox.Name} is not allowed!");

        hurtBox.HealthComponent.TakeDamage(Damage);
    }
}