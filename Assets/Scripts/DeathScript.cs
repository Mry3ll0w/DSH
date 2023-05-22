
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathScript : MonoBehaviour
{
    [SerializeField] private GameObject replacementObjectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Enemy"))
        {
            // Replace the object
            GameObject newObject = Instantiate(replacementObjectPrefab, transform.position, transform.rotation);
            gameObject.SetActive(false);

            // Find the camera in the newObject
            Camera newCamera = newObject.GetComponentInChildren<Camera>();
            if (newCamera != null)
            {
                // Disable the current main camera
                Camera mainCamera = Camera.main;
                if (mainCamera != null)
                {
                    mainCamera.enabled = false;
                }

                // Set the new camera as the main camera
                newCamera.enabled = true;
                newCamera.tag = "MainCamera";
                Invoke("LoadNextScene", 3f);
            }
        }
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene("escena Muerte");
    }
}
