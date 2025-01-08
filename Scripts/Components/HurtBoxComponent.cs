using Godot;
using GodotUtilities.Util;

namespace ChikenGun.Scripts.Components;

[GlobalClass]
public partial class HurtBoxComponent : Area2D
{
    [Export] public HealthComponent HealthComponent { get; private set; }

    public override void _Ready()
    {
        if (HealthComponent == null)
            Logger.Error("HurtBoxComponent does not have a HealthComponent assigned!");
    }
}