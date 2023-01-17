using UnityEngine;
using UnityEditor;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

public class LocationGen : MonoBehaviour
{
    public GameObject LocationRef;

    // Player Specific
    bool locationHasBeenVisited;

    // UI 
    public Material floorPlanBackground;
    public Material floorPlanOutlineColor;
    public int floorPlanWidth;
    public int floorPlanHeight;
    public Font floorPlanFont;

    // Variables For Location Specifics
    bool locationHasPower;
    bool locationHasRunningWater;
    bool locationHasSecretPassages;
    bool locationIsLooted;
    bool locationIsHaunted;

    // tunnel 
    bool locationHasTunnel;
    int tunnelEntryPoints;
    int tunnelExitPoints;

    int numberOfStashies;
    int numberOfSpotsToSearch;

    int numberOfCorridors;

    // Rooms
    int numberOfRooms;
    int minNumberOfRooms;
    int maxNumberOfRooms;

    // # of stories building has
    int minNumberOfStories;
    int maxNumberOfStories;
    int numberOfStories;

    // Floor Plan Specifics
    float WallDimensions;
    float WindowDimensions;
    int numberOfDoorsPerRoom;
    int staircasesToTraverse;
    float staircaseDimensions;
    float staircaseLocation;

    // Obstacle Variables
    int numberOfObstacles;
    string obstacleName;
    int obstacleSize;
    float obstacleLocation;
    bool obstacleCanBeTraversed;

    // Lists
    public List<Room> Rooms;
    public List<ItemContainer> Containers;

    [ContextMenu("Generate Floor Plan")]
    public void GenerateFloorPlan()
    {
        numberOfRooms = Random.Range(minNumberOfRooms, maxNumberOfRooms);

        // Generates Floor Plan
        Debug.Log($"There are {Rooms.Count} rooms in this location with a total of {Containers.Count}");
    }

    private void Awake()
    {
        LocationRef = this.gameObject;
    }

    public void Generate()
    {
        // Generate the rooms
        for (int i = 0; i < numberOfRooms; i++)
        {
            string roomName = "Room " + i;
            int doorAmount = Random.Range(1, numberOfDoorsPerRoom + 1);
            int windowAmount = (int)Random.Range(1, WindowDimensions + 1);

            //Room room = new Room(roomName, doorAmount, windowAmount);
            //Rooms.Add(room);
        }

        // Generate the item containers
        for (int i = 0; i < numberOfStashies; i++)
        {
            string name = "Stash " + i;
            string desc = "A hidden stash of loot.";
            bool isTrapped = false;
            bool hasMoney = false;
            decimal moneyFound = 0.0M;

            ItemContainer container = new ItemContainer(name, desc, isTrapped, hasMoney, moneyFound);
            Containers.Add(container);
        }
    }

}


public class Room
{
    string RoomName;
    string RoomDescription;
    bool isRoomLocked;
    int roomLockLevel;
    int doorCount;
    int windowCount;
    int wallCount = 4;
    int searchSpots = Random.Range(0, 3);

    public Room(string _rname, int doorAmount, bool roomLocked, bool rlockLevel, int doorCount)
    {
        RoomName = _rname;
        doorCount = doorAmount;
    }
}
public class ItemContainer
{

    public string Name;
    public string Description;
    public int containerLockLevel;
    public bool isContainerTrapped;
    public bool hasFoundMoney;
    public decimal moneyFound;
    public ItemData[] Items;
    public int minItemCount = 0;
    public int maxItemCount;
    public int itemCount;

    public ItemContainer(string name, string description, bool isContainerTrapped, bool hasFoundMoney, decimal moneyFound)
    {
        Name = name;
        Description = description;
        this.isContainerTrapped = isContainerTrapped;
        this.hasFoundMoney = hasFoundMoney;
        this.moneyFound = moneyFound;
        Items = new ItemData[itemCount=Random.Range(minItemCount,maxItemCount)];
    }
}

