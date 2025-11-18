using UnityEngine;

public class Potion : Item
{
    public override void Use(Player player)
    {
        if (player != null)
        {
            player.Heal(itemValue);
        }
    }
}
