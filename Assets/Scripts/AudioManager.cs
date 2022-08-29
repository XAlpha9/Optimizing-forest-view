using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _bgmAudioSource;
    public bool isAudioEnabled = false;
    private static AudioManager _instance;
    private int RngAudio;

    public static AudioManager Instance { get { return _instance; } }
    private void Awake() 
    {   
       if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }
    public void PlayBgm()
    {
        RngAudio = Random.Range(0, _bgmAudioSource.Count);
        _bgmAudioSource[RngAudio].Play();
    }
    public void UnloadBgm()
    {
        //if (GetComponent<AudioSource>() != _bgmAudioSource[RngAudio])
        //{
        //    Destroy(GetComponent<AudioSource>());
        //}
        for (int i = 0; i < _bgmAudioSource.Capacity; i++)
        {
            GameObject UselessAudio = _bgmAudioSource[i].gameObject;
            if (_bgmAudioSource[i] != _bgmAudioSource[RngAudio] && isAudioEnabled == true)
            {
                Destroy(UselessAudio);
            }
            else if (isAudioEnabled == false)
            {
                Destroy(UselessAudio);
            }
        }
        //foreach (AudioSource audio in _bgmAudioSource)
        //{
        //    if (audio != _bgmAudioSource[RngAudio])
        //    {
        //        Destroy(audio);
        //    }
        //}
    }
}
