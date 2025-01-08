using Godot;
using GodotUtilities.Util;

namespace ChikenGun.Scripts.Components;

[GlobalClass]
public partial class HitBoxComponent : Area2D
{
    private bool _isEnabled;
    [Export] public int Damage { get; set; } = 10;

    [Export]
    public bool IsEnabled
    {
        get => _isEnabled;
        set
        {
            _isEnabled = value;
            if (_isEnabled) CheckForOverlappingAreas();
        }
    }

    public override void _Ready()
    {
        AreaEntered += OnAreaEntered;
    }

    private void OnAreaEntered(Area2D area)
    {
        if (area is not HurtBoxComponent hurtBox) return;
        if (hurtBox.GetParent() == GetParent())
            Logger.Error($"Layer and Mask collision between {Name} and {hurtBox.Name} is not allowed!");
        if (!IsEnabled) return;

        GD.Print("Hit from " + GetParent().Name + " to " + hurtBox.GetParent().Name);

        hurtBox.HealthComponent.TakeDamage(Damage);
    }

    private void CheckForOverlappingAreas()
    {
        foreach (var area in GetOverlappingAreas()) OnAreaEntered(area);
    }
}