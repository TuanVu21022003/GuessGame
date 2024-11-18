using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioSource audioSource;
    public float volumeStep = 0.1f; // Mức tăng/giảm âm lượng
    public float maxVolume = 1.0f;
    public float minVolume = 0.0f;

    //void Update()
    //{
    //    // Tăng âm lượng khi nhấn phím "UpArrow"
    //    if (Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        IncreaseVolume();
    //    }

    //    // Giảm âm lượng khi nhấn phím "DownArrow"
    //    if (Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        DecreaseVolume();
    //    }
    //}

    public void IncreaseVolume()
    {
        audioSource.volume += volumeStep;
        audioSource.volume = Mathf.Clamp(audioSource.volume, minVolume, maxVolume);
        Debug.Log("Volume Increased: " + audioSource.volume);
    }

    public void DecreaseVolume()
    {
        audioSource.volume -= volumeStep;
        audioSource.volume = Mathf.Clamp(audioSource.volume, minVolume, maxVolume);
        Debug.Log("Volume Decreased: " + audioSource.volume);
    }
}
