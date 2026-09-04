// NGPB OBT SHOP + INVENTORY + CLAN - PC+HP+iOS v1.0.105
public class ShopSystem {
 public string[] Weapons = {"AUG A3","AK-47","M4A1","AWP","KRISS","P90"};
 public int[] Prices = {0,1000,1200,2000,1500,1300};
 public string Buy(string weapon) => $"Bought {weapon} - 30 days!";
}
public class InventorySystem {
 public string Equipped = "AUG A3 28/120";
 public string CharacterRED = "RED Team Female";
 public string CharacterBLUE = "BLUE Team Male Soldier";
}
public class ClanSystem {
 public string ClanName = "NGPB_BOSS";
 public int Level = 5; public int Members = 8;
 public string ClanWar() => "Clan War RED Yard 8v8 Ready! Server 127.0.0.1:39190";
}
