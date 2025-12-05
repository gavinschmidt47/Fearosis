using MemoryPack;
using System;
using System.Collections.Generic;

[MemoryPackable]
public partial class ShopData
{
    public List<String> purchasedThemes;
    public List<String> purchasedMonsters;
    public List<String> purchasedModes;

    [MemoryPackConstructor]
    public ShopData()
    {
        purchasedThemes = new List<String>();
        purchasedMonsters = new List<String>();
        purchasedModes = new List<String>();
    }
}