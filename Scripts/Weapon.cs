using Godot;

namespace ChikenGun.Scripts;

[GlobalClass]
public partial class Weapon : Resource
{
    [Export] public int Damage { get; private set; }
    [Export] public Texture2D Texture { get; private set; }
}