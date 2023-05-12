using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject Maps;
    public GameObject kyMap;
    public GameObject usaMap; // not used yet
    public GameObject localMap;

    public GameObject playerPOS;
    public int maxLocationCount;
    public int minLocationCount;

    public bool bIsTraversing;
    public float travelSpeed;

    public Transform _nextNode;
    public Transform _pastNode;
    public Transform currentNode;
    public Transform[] surroundingNodes;

    private bool isMapOpen = false;
    private void Update()
    {
        OpenMapUI();
        SwitchMaps();
    }
    private void OpenMapUI()
    {
        // Open Maps
        if (Input.GetKeyDown(KeyCode.M))
        {
            isMapOpen = !isMapOpen;
        }

        if (isMapOpen)
        {
            Maps.SetActive(true);
        }
        else
        {
            Maps.SetActive(false);
        }
    }
    private void SwitchMaps()
    {
        // Switch Between Maps
        if (Input.GetKeyDown(KeyCode.U))
        {
            kyMap.SetActive(true);
            usaMap.SetActive(false);
            localMap.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            usaMap.SetActive(true);
            kyMap.SetActive(false);
            localMap.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            localMap.SetActive(true);
            kyMap.SetActive(false);
            usaMap.SetActive(false);
        }
    }

    private int randomNode;
    public void UnitIsTraveling(bool areTheyTraveling)
    {
        if (areTheyTraveling)
        {
            Mathf.Lerp(currentNode.localPosition.x, _nextNode.localPosition.x, travelSpeed);
            if (currentNode.position == _nextNode.position)
            {
                _pastNode = currentNode;
                currentNode = surroundingNodes[randomNode];
            }
        }
    }
}

public enum LocationDimensions
{
    // small lot
    small,
    // medium lot
    medium,
    // large lot
    large,
    // varied lot
    varied
}
public class LocationSize
{
    public string sizeOfLocation = "18x18";
    public LocationDimensions lotSize;
    public LocationDimensions loadedSpace;

    public LocationDimensions LotSizeSelection(bool newLotGeneration)
    {
        bool isGeneratingLot = newLotGeneration;
        int _rInt = Random.Range(0, 3);

        return loadedSpace; 
    }
}
