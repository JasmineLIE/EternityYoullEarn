using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevelationsContainer : MonoBehaviour
{
    public GameObject[] rows;
    public int[] rowsCount;
    GameObject player;
    public GameObject revelationPrefab;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SpawnRevelations();
    }

    private void SpawnRevelations()
    {
        if (player.GetComponent<Player>().saveData.ActivatedCount > 0)
        {
            //load in the revelations
        } else
        {
            print("we have no revelations!");
        }
    }
}
