using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMusicController : MonoBehaviour {

    private AudioSource ingameMusic;

    void Awake()
    {
        //SE CAPTURA EL AUDIOSOURCE, SE PONE EL AUTOLOOP Y SE REPRODUCE EL CLIP DE SONIDO
        ingameMusic = GetComponent<AudioSource>();
        ingameMusic.loop = true;
        ingameMusic.Play();
    }

}
