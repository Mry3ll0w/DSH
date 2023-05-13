using UnityEngine;

public class AudioDistanceVolumeController : MonoBehaviour
{
    private Transform player;
    public AudioSource audioSource;
    public float maxDistance = 20f;
    public float minDistance = 5f;
    public float bufferDistance = 1f;
    public float minVolume = 0.1f;
    public float maxVolume = 1f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform; 
    }

    void Update()
    {
        AdjustVolumeBasedOnDistance();
    }

    void AdjustVolumeBasedOnDistance()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        float clampedDistance = Mathf.Clamp(distance, minDistance - bufferDistance, maxDistance + bufferDistance);
        float normalizedDistance = (clampedDistance - (minDistance - bufferDistance)) / (maxDistance - minDistance + 2 * bufferDistance);
        float targetVolume = Mathf.Lerp(maxVolume, minVolume, normalizedDistance);

        audioSource.volume = targetVolume;
    }
}
