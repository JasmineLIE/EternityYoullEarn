using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartHandler : MonoBehaviour
{
    public SaveData saveData;

    private void Awake()
    {
        saveData.LoadGameStart();
    }
}
