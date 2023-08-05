using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip _clickSound;
    [SerializeField] AudioClip _placeSound;
    private static SoundManager _instance;

    AudioSource ac;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);

            ac = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundManager>();
            }
            return _instance;
        }
    }

    public void PlayClickSound()
    {
        ac.clip = _clickSound;
        ac.Play();
    }

    public void PlayPlaceSound()
    {
        ac.clip = _placeSound;
        ac.Play();
    }
}
