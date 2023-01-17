using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    // 0 - Void
    // 1 - Tobi
   
    private void Awake()
    {
        // Create Team
        Team VOID = new Team("VOID","General sabatours of the VOID", 5, 10, 100, 0, 0);
        Team TOBI = new Team("TOBI", "Normal inhabitants of the Earth", 5, 10, 250, 0, 1);
    }
}

// TEAM INFO 
public class Team
{
    public string Name;
    public int TeamNumber;
    public string Description;
    public List<Player> PlayerList;
    public int PlayerCount;
    private int maxPlayerCount = 5;
    private int minPlayerCount = 3;
    public int TurnsLeft;
    public decimal MoneyPool;
    public float TeamKarma;

    public Team(string name, string description, int playerCount, int turnsLeft, decimal moneyPool, float teamKarma, int teamNumber)
    {
        Name = name;
        Description = description;
        PlayerCount = playerCount;
        TurnsLeft = turnsLeft;
        MoneyPool = moneyPool;
        TeamKarma = teamKarma;
        TeamNumber = teamNumber;
    }

    // Change Values during Game Run

    public void SelectTeam()
    {
        if (TeamNumber == 0)
        {
            Debug.Log("VOID SELECTED");
        }
        else if (TeamNumber == 1)
        {
            Debug.Log("T.O.B.I. SELECTED");
        }
    }

    public void AddPlayer(Player player)
    {
        PlayerList.Add(player);
        MoneyPool += player.Money;
    }

    public void RemovePlayer(Player player)
    {
        PlayerList.Remove(player);
    }

    public void RandomizeVOIDSquadmate()
    {
        string[] namePool = { "Alice", "Bertham", "David", "Jesse", "Steven", "Douglas", "Lynn", "Ricky", "Lorraine", "Helen", "Ada", "Lovelace" };
        int randomNameIndex = Random.Range(0, namePool.Length);
        string randomName = namePool[randomNameIndex];

        string[] roles = { "Arcanist", "Psionic", "Medic", "Recon", "Security", "Tech-Janitorial" };
        int randomIndex = Random.Range(0, roles.Length);
        string randomRole = roles[randomIndex];

        decimal randomMoney = (decimal)Random.Range(50f, 200f);

        Player _randomName = new Player(randomName, randomRole, 100, randomMoney, "null");

        AddPlayer(_randomName);
    }

    public void RandomizeTOBISquadmate()
    {
        string[] namePool = { "Alice", "Bertham", "David", "Jesse", "Steven", "Douglas", "Lynn", "Ricky", "Lorraine", "Helen", "Ada", "Lovelace" };
        int randomNameIndex = Random.Range(0, namePool.Length);
        string randomName = namePool[randomNameIndex];

        string[] roles = { "Arcanist", "Psionic", "Medic", "Recon", "Security", "Tech-Janitorial" };
        int randomIndex = Random.Range(0, roles.Length);
        string randomRole = roles[randomIndex];

        decimal randomMoney = (decimal)Random.Range(50f, 200f);

        string[] patronSpirits = { "Apollo", "Hel", "Hades", "Belphegor", "Freya", "Saint Sebastian" };
        int randomPatronIndex = Random.Range(0, patronSpirits.Length);
        string randomPatronSpirit = patronSpirits[randomPatronIndex];

        Player _randomName = new Player(randomName, randomRole, 100, randomMoney, randomPatronSpirit);

        AddPlayer(_randomName);
    }

}

public class Player
{
    public string Name;
    public string Role;
    public int Health;
    public decimal Money;
    public List<InventoryItem> Inventory;
    public string PatronSpirit;

    public Player(string name, string role, int health, decimal money, string patronSpirit)
    {
        Name = name;
        Role = role;
        Health = health;
        Money = money;
        PatronSpirit = patronSpirit;
        Inventory = new List<InventoryItem>();
    }

}
