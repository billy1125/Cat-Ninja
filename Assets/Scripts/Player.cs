using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject MainCamera;
    private GameObject gameManager;
    public AudioClip[] EffectSounds;

    // Start is called before the first frame update
    void Start()
    {
        this.MainCamera = GameObject.Find("Main Camera");
        this.gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-2, 0, 0);
            PlayEffectSound(EffectSounds[0]);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(2, 0, 0);
            PlayEffectSound(EffectSounds[0]);
        }        
    }

    public void LButtonDown()
    {
        transform.Translate(-2, 0, 0);
        PlayEffectSound(EffectSounds[0]);
    }

    public void RButtonDown()
    {
        transform.Translate(2, 0, 0);
        PlayEffectSound(EffectSounds[0]);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            gameManager.GetComponent<GameManager>().ChangeHP(-0.1f);
            PlayEffectSound(EffectSounds[1]);
        }
        else if (collision.gameObject.tag == "Cat Food")
        {
            gameManager.GetComponent<GameManager>().ChangeHP(0.1f);
            PlayEffectSound(EffectSounds[2]);
        }
      
        MainCamera.GetComponent<CameraShake>().isShake = true;
    }

    private void PlayEffectSound(AudioClip _sound)
    {
        GetComponent<AudioSource>().clip = _sound;
        GetComponent<AudioSource>().Play();
    }
}
