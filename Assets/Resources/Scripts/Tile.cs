using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[SerializeField]
public class Tile : MonoBehaviour
{
    Renderer tileSurface;
    GameObject[] Squaddies;
    GameObject TestPlayer;
    string miniPlayer = "miniPlayers";
    string mainPlayer = "Player";

    int roomStashCount = 5;
    bool isRoomFullySearched = false;

    // Start is called before the first frame update
    void Start()
    {
        tileSurface = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == mainPlayer)
        {
            tileSurface.material.color = Color.gray;
        }
    }

    public bool CheckIsFullySearched(bool searchingObject, int Stashes)
    {
        if (searchingObject && Stashes <= 0)
        {
            tileSurface.material.color = Color.green;
            return true;
        }

        roomStashCount--;
        return false;
    }
}
