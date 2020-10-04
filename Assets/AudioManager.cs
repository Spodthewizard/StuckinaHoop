using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
   void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
