using Godot;

namespace ChikenGun.Scripts;

public partial class Hud : Control
{
	[Export] private Player Player { get; set; }
	private TextureProgressBar _healthBar;

	public override void _Ready()
	{
		_healthBar = GetNode<TextureProgressBar>(nameof(TextureProgressBar));
		if (_healthBar == null)
		{
			GD.PushError("Hud does not have a HealthBar assigned!");
			return;
		}
		
		
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