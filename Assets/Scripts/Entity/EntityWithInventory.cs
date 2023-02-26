public class EntityWithInventory : Entity, IInventoryHolder
{
    public Inventory Inventory;

    new void Awake()
    {
        this.Inventory = new Inventory(16, this);
        base.Awake();
    }

    public Inventory GetInventory()
    {
        return this.Inventory;
    }
}