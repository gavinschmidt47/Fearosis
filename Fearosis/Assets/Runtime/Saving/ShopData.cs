using MemoryPack;
using System.Collections.Generic;

[MemoryPackable]
public partial class ShopData
{
    public List<byte[]> purchasedThemes;
    public List<byte[]> purchasedMonsters;
    public List<byte[]> purchasedModes;

    [MemoryPackConstructor]
    public ShopData()
    {
        purchasedThemes = new List<byte[]>();
        purchasedMonsters = new List<byte[]>();
        purchasedModes = new List<byte[]>();
    }
}