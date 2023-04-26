using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenerationManager : MonoBehaviour
{

    [SerializeField] Transform worldGrid; //room parents
    [SerializeField] List<GameObject> roomTypes;
    [SerializeField] Slider mapSizeSlider;
    [SerializeField] Button generateButton;
    [SerializeField] Button ReloadButton;
    [SerializeField] GameObject eRoom;
    public int mapSize = 16; //map size
    int mapSizeSquare;  //square root of map size
    float currentPosX, currentPosZ, currentPosTracker; //Posicion of the room
    float roomSize = 6;
    int posTracker; //pos of the generator
    Vector3 currentPos; //currentPos of the room to be generated
    public void reloadWorld()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void generateWorld()
    {
        generateButton.interactable = false;
        for (int i = 0; i < mapSize; i++)
        {
            if (currentPosTracker == mapSizeSquare)
            {
                currentPosX = 0;
                currentPosTracker = 0;
                currentPosZ += roomSize;
            }
            currentPos = new(currentPosX, 0, currentPosZ);
            Instantiate(roomTypes[Random.Range(0, roomTypes.Count)], currentPos, Quaternion.identity, worldGrid);
            currentPosTracker++;
            currentPosX += roomSize;
        }
    }

    void Update()
    {
        mapSize = (int)Mathf.Pow(mapSizeSlider.value, 4);
        mapSizeSquare = (int)Mathf.Sqrt(mapSize);
    }
}
