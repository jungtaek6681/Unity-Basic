using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioSource idleSource;
    [SerializeField] AudioSource driveSource;
    [SerializeField] AudioSource fireSource;

    public void PlayFire()
    {
        fireSource.Play();
    }

    public void PlayIdle()
    {
        idleSource.Play();
        driveSource.Stop();
    }

    public void PlayDrive()
    {
        idleSource.Stop();
        driveSource.Play();
    }
}
