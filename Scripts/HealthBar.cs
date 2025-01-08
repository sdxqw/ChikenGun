using ChikenGun.Scripts.Components;
using Godot;
using GodotUtilities;

namespace ChikenGun.Scripts;


public partial class HealthBar : TextureProgressBar
{
    [Export] private HealthComponent HealthComponent { get; set; }
    

    public override void _Ready()
    {
        if (HealthComponent == null)
        {
            GD.PushError("HealthBar does not have a HealthComponent assigned!");
            return;
        }

        HealthComponent.OnDamage += OnDamage;
        Value = HealthComponent.CurrentHealth;
        MaxValue = HealthComponent.MaxHealth;
    }

    private void OnDamage(int damageTaken, int currentHealth)
    {
        Value = currentHealth;
    }
}