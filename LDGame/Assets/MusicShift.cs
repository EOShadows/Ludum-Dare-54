using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicShift : MonoBehaviour
{
    static public void Playmusic(GameObject obj, AudioClip clip)
    {
        obj.GetComponent<AudioSource>().PlayOneShot(clip);
    }
    static public void changeMusic(GameObject obj, AudioClip clip)
    {
        obj.GetComponent <AudioSource>().Stop();
        obj.GetComponent<AudioSource>().PlayOneShot(clip);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    static IEnumerator Loop(int track, float cliplength)
    {
        yield return new WaitForSeconds(cliplength);
    }
}
