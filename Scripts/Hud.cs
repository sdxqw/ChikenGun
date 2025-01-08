using Godot;
using GodotUtilities;

namespace ChikenGun.Scripts;

[Scene]
public partial class Hud : Control
{
	[Export] private Player Player { get; set; }
	[Node]
	private TextureProgressBar _healthBar;

	public override void _Notification(int what)
	{
		if (what == NotificationSceneInstantiated) {
			WireNodes(); 
		}
	}

	public override void _Ready()
	{
		if (Player == null)
		{
			GD.PushError("Hud does not have a Player assigned!");
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