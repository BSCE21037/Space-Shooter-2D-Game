using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.BulletShot, 
            Resources.Load<AudioClip>("BulletShot"));
        audioClips.Add(AudioClipName.ShipHit,
            Resources.Load<AudioClip>("metal_hit"));
        audioClips.Add(AudioClipName.AsteroidHit,
            Resources.Load<AudioClip>("rock_destroy"));
        audioClips.Add(AudioClipName.MenuButtonClick,
             Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.PauseGame,
             Resources.Load<AudioClip>("pop"));
        audioClips.Add(AudioClipName.GameOver,
            Resources.Load<AudioClip>("GameOver"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
