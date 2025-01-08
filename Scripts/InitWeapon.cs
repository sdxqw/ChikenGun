using ChikenGun.Scripts.Components;
using Godot;
using GodotUtilities;

namespace ChikenGun.Scripts;

[Scene]
public partial class InitWeapon : Node2D
{
    [Export] private Weapon Weapon { get; set; }

    [Node] private HitBoxComponent HitBoxComponent { get; set; }
    [Node] public Sprite2D Sprite2D { get; set; }
    [Node] public AnimationPlayer AnimationPlayer { get; set; }

    public override void _Notification(int what)
    {
        if (what == NotificationSceneInstantiated) WireNodes();
    }

    public override void _Ready()
    {
        if (Weapon == null)
        {
            GD.PushError("Weapon does not have a Weapon assigned!");
            return;
        }

        LoadWeapon();
    }

    private void LoadWeapon()
    {
        Sprite2D.Texture = Weapon.Texture;
        HitBoxComponent.Damage = Weapon.Damage;
    }

    public void Attack()
    {
        HitBoxComponent.IsEnabled = true;
        AnimationPlayer.Play("attack");
        HitBoxComponent.IsEnabled = false;
    }
}