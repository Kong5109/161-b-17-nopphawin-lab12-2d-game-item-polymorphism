using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [field: SerializeField] protected int itemValue{ get; set;}

    public abstract void Use(Player player);
    public void PickUp(Player player)
    {
        Use(player);
        Destroy(this.gameObject);
    }
}
