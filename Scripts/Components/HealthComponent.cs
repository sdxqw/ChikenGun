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

    [Export] public int MaxHealth { get; set; } = 100;

    public int CurrentHealth { get; set; }

    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damageToApply)
    {
        if (CurrentHealth > 0)
        {
            CurrentHealth -= damageToApply;
            EmitSignal(nameof(OnDamage), damageToApply, CurrentHealth);
        }
        else
        {
            EmitSignal(nameof(OnDeath));
        }
    }

    public void Heal(int healAmount)
    {
        CurrentHealth += healAmount;
        EmitSignal(nameof(OnHealth), healAmount, CurrentHealth);
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
    }
}