public class Inventory
{
    private int _size;
    private IInventoryHolder _holder;

    public Inventory(int size, IInventoryHolder holder)
    {
        this._size = size;
        this._holder = holder;
    }

    public Inventory(int size)
    {
        this._size = size;
    }

    public IInventoryHolder Holder
    {
        get
        {
            return this._holder;
        }
    }

    public int Size
    {
        get
        {
            return this._size;
        }
    }
}