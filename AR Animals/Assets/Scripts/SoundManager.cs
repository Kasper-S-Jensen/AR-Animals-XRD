using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    private const string VolumeKey = "Volume";

    [SerializeField] private List<AudioInfo> audioClips;
    [SerializeField] private AudioMixerGroup mixerGroup;

    private List<AudioSource> audioSources;

    private Dictionary<string, AudioClip> clipDictionary;
  

    private void Awake()
    {

        //create list of audioinfos
        clipDictionary = new Dictionary<string, AudioClip>();
        foreach (var clip in audioClips)
        {
            if (clipDictionary.ContainsKey(clip.clipName))
            {
                Debug.LogWarning($"Duplicated clip name: {clip.clipName}");
            }
            else
            {
                clipDictionary.Add(clip.clipName, clip.clip);
            }
        }

        // Create AudioSources for each clip
        audioSources = new List<AudioSource>();
        foreach (var info in audioClips)
        {
            var source = gameObject.AddComponent<AudioSource>();
            source.clip = info.clip;
            source.outputAudioMixerGroup = mixerGroup;
            audioSources.Add(source);
        }

     //   PlayAudioClip("Background");
    }

    private void Start()
    {
     
    }
    
    public void ButtonSound(Component sender, object data)
    {
        PlayAudioClip("Test");
    }
    
    
    


    private void PlayAudioClip(string clipName)
    {
        //check if renamed
        if (!clipDictionary.TryGetValue(clipName, out var clip))
        {
            Debug.LogError($"Audio clip '{clipName}' not found.");
            return;
        }

        // Find an available AudioSource to play the clipp
        foreach (var source in audioSources)
        {
            if (source.isPlaying)
            {
                continue;
            }

            source.clip = clip;
            source.Play();
            return;
        }
    }

    private void StopAudioClip(string clipName)
    {
        // Find the index of the clip in the array using its naame
        var clipIndex = -1;
        for (var i = 0; i < audioClips.Count; i++)
        {
            if (audioClips[i].clipName != clipName)
            {
                continue;
            }

            clipIndex = i;
            break;
        }

        // If the clip index is valid, stop the audio source
        if (clipIndex >= 0)
        {
            audioSources[clipIndex].Stop();
        }
    }


    [Serializable]
    public struct AudioInfo
    {
        public string clipName;
        public AudioClip clip;
    }
}