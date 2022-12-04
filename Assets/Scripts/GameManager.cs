using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject hpUI;    
    public GameObject GameOverUI;
    public float HealthAmount = 10.0f;
    public int PointAmount = 0;

    public GameObject Player;

    public AudioClip HurtSound;
    public AudioClip GameOverSound;
    public AudioClip GetPoint;

    private AudioSource ASaudio;

    public Text SocreText;

    public GameObject ArrowPrefab;
    public GameObject CatfoodPrefab;

    // Start is called before the first frame update
    void Start()
    {
        this.hpUI = GameObject.Find("HP");
        ASaudio = GetComponent<AudioSource>();
        InvokeRepeating("GenerateArrow", 0, 1);
        InvokeRepeating("GenerateCatfood", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateArrow()
    {
        float px = Random.Range(-6.0f, 7.0f);
        Instantiate(ArrowPrefab, new Vector3(px, 7, 0), Quaternion.identity);
    }

    void GenerateCatfood()
    {
        float px = Random.Range(-6.0f, 7.0f);
        Instantiate(CatfoodPrefab, new Vector3(px, 7, 0), Quaternion.identity);
    }

    public void ChangeHP(float _number)
    {
        if (this.HealthAmount != 10.0f)
        {
            this.hpUI.GetComponent<Image>().fillAmount += _number;
            this.HealthAmount += _number * 10.0f;        
        }

        if (this.HealthAmount == 0)
        {
            ShowGameOver();
            Player.SetActive(false);
        }
    }

    private void ShowGameOver()
    {
        this.GameOverUI.SetActive(true);
    }

    public void IncreasePonit()
    {
        this.PointAmount += 10;
        SocreText.text = this.PointAmount.ToString();
        this.ASaudio.clip = GetPoint;
        this.ASaudio.Play();
    }
}
