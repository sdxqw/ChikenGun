using Godot;
using GodotUtilities;
using GodotUtilities.Util;

namespace ChikenGun.Scripts;

[Scene]
public partial class Hud : Control
{
    [Node] private TextureProgressBar _healthBar;

    [Export] private Player Player { get; set; }

    public override void _Notification(int what)
    {
        if (what == NotificationSceneInstantiated) WireNodes();
    }

    public override void _Ready()
    {
        if (Player == null)
        {
            Logger.Error("Hud does not have a Player assigned!");
            return;
        }

        Player.HealthComponent.OnDamage += OnDamage;
        _healthBar.Value = Player.HealthComponent.CurrentHealth;
        _healthBar.MaxValue = Player.HealthComponent.MaxHealth;
    }

    private void OnDamage(int damageTaken, int currentHealth)
    {
        _healthBar.Value = currentHealth;
    }
}