using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip coinSound;
    public AudioClip deathSound;

    public void playJump()
    {
        audioSource.PlayOneShot(jumpSound);
    }
    public void playCoin()
    {
        audioSource.PlayOneShot(coinSound);
    }
    public void playDeath()
    {
        audioSource.PlayOneShot(deathSound);
    }
}
