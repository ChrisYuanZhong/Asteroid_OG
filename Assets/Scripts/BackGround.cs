using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public AudioSource audioSource;
    public AudioClip regularMusic;
    public AudioClip druggedMusic;
    public Sprite regular;
    public Sprite drugged;
    public Sprite gameover;

    public void ChangeRegularBG()
    {
        spriteRenderer.sprite = regular;
        audioSource.clip = regularMusic;
        audioSource.Play();
    }

    public void ChangeDruggedBG()
    {
        spriteRenderer.sprite = drugged;
        audioSource.clip = druggedMusic;
        audioSource.Play();
    }

    public void ChangeGameoverBG()
    {
        spriteRenderer.sprite= gameover;
    }
}
