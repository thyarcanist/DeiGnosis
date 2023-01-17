using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour
{
    public Point[] points;
    public List<CardData> locations;
    public List<CardData> createdLocations;
    public CardData selectedLocation;
    public bool isGenerating;

    public GameObject locRef;


    public int locationCount;

    // Start is called before the first frame update
    void Start()
    {
        locationCount = Random.Range(5, locations.Count);
        locRef = GameObject.Find("Location");
    }

    private void Update()
    {
        // Use LocationGen.cs to randomize a location based on a random pick from locations.
        if (isGenerating)
        {
            foreach (Point spot in points)
            {
                if (spot != null)
                {

                    // Use method in LocationGen.cs to Generate @ selectedLocation
                    locRef.GetComponent<LocationGen>().Generate();

                    // Remove the selectedLocation AFTER generation
                    locations.Remove(selectedLocation);

                    // Now populate createdLocations with the Generated Ones
                    createdLocations.Add(selectedLocation);
                }
                else
                {
                    // exits loop
                    isGenerating = false;
                }
            }
        }
    }
}