using System.Collections.Generic;
using UnityEngine;

public class TeleportOnCollision : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> tpObjects;
    private CharacterController characterController;
    void Start()
    {
        // Initialize the list
        tpObjects = new List<GameObject>();
        characterController = player.GetComponent<CharacterController>();
        // Iterate through all game objects and check their tags
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            
            if (obj.CompareTag("Untagged"))
            {
                continue;
            }

            if (obj.tag.Contains("TP"))
            {
                //Debug.Log("Object name: " + obj.name);
                tpObjects.Add(obj);
            }
        }
    }


    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("HHOLA");
            characterController.enabled = false;
            int randomIndex = Random.Range(0, tpObjects.Count);
            player.transform.position = tpObjects[randomIndex].transform.position;
            characterController.enabled = true;   
    }

}

