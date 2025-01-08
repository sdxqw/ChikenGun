using Godot;
using GodotUtilities;
using GodotUtilities.Util;

namespace ChikenGun.Scripts.Components;

[GlobalClass]
[Scene]
public partial class HurtBoxComponent : Area2D
{
    [Node] public HealthComponent HealthComponent { get; private set; }

    public override void _Notification(int what)
    {
        if (what == NotificationSceneInstantiated) WireNodes();
    }

    public override void _Ready()
    {
        if (HealthComponent == null)
            Logger.Error($"HurtBoxComponent on {Name} does not have a HealthComponent assigned!");
    }
}