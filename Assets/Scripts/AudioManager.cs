using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    // Group A persistent scenes: these scenes share one persistent track.
    public string[] persistentGroupA = { "Main Menu", "Dialogue 1" };

    // Group B persistent scenes: these scenes share another persistent track.
    public string[] persistentGroupB = { "Day 1", "Day 2" };

    void Awake()
    {
        // Singleton pattern: only one AudioManager should exist.
        if (instance == null)
        {
            instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject); // Persist across scenes.
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Set up AudioSources for each sound.
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;

            //for pause menu volume slider
            sound.source.outputAudioMixerGroup = sound.mixer_group;
        }

        // Subscribe to scene loaded events.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);

        // If the loaded scene is part of persistent Group A,
        if (persistentGroupA.Contains(scene.name))
        {
            if (!IsPlaying("Main & Game Obj")) //**see sounds list in the inspector
            {
                StopAllMusic();
                Play("Main & Game Obj");
            }
        }
        // If the loaded scene is part of persistent Group B,
        else if (persistentGroupB.Contains(scene.name))
        {
            if (!IsPlaying("Farm & Kitchen"))
            {
                StopAllMusic();
                Play("Farm & Kitchen");
            }
        }
        else
        {
            // For any scene not in Group A or B, stop all music.
            StopAllMusic();
            // Optionally, play scene-specific music. For example:
            if (scene.name == "Credits")
            {
                Play("Credits");
            }
        }
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }
        if (sound.source == null)
        {
            Debug.LogWarning($"AudioSource for sound {name} is null!");
            return;
        }
        sound.source.Play();
    }

    public void Stop(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }
        if (sound.source != null)
        {
            sound.source.Stop();
        }
    }

    public void StopAllMusic()
    {
        // Loop through all sounds and stop any that are playing.
        foreach (Sound sound in sounds)
        {
            if (sound.source != null && sound.source.isPlaying)
            {
                sound.source.Stop();
            }
        }
    }

    public bool IsPlaying(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null) return false;
        return sound.source != null && sound.source.isPlaying;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}