using Godot;

namespace ChikenGun.Scripts.Components;

[GlobalClass]
public partial class HealthComponent : Node
{
    [Signal]
    public delegate void OnDamageEventHandler(int damageTaken, int currentHealth);

    [Signal]
    public delegate void OnDeathEventHandler();

    [Signal]
    public delegate void OnHealthEventHandler(int healAmount, int currentHealth);

    [Export] private int MaxHealth { get; set; } = 100;

    private int CurrentHealth { get; set; }

    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damageToApply)
    {
        CurrentHealth -= damageToApply;
        EmitSignal(nameof(OnDamageEventHandler), damageToApply, CurrentHealth);
        if (CurrentHealth <= 0) EmitSignal(nameof(OnDeathEventHandler));
    }

    public void Heal(int healAmount)
    {
        CurrentHealth += healAmount;
        EmitSignal(nameof(OnHealthEventHandler), healAmount, CurrentHealth);
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
    }
}