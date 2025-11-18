using UnityEngine;

public class Bomb : Item
{
    public override void Use(Player player)
    {
        if (player != null)
        {
            player.DecreaseHealth(itemValue);
        }
    }
}
