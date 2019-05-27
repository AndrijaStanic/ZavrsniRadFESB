using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class PlayerHealthBar : MonoBehaviour
{
    
    public int driedTreesCut;
    public int friendlyTreesCut;
    public Text driedTreesCutText;
    public Text friendlyTreesCutText;
    public Text treesCut;
    public GameObject gameOverPanel;
    public GameObject driedTreesCutPanel;
    public GameObject friendlyTreesCutPanel;
    public GameObject TimeLeftPanel;
    public GameObject HealthBarPanel;
    public GameObject HealthMaskPanel;
    public Text GameOverText;

    AudioSource audioSource;
    RawImage healthBarRawImage;
    Player player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        healthBarRawImage = GetComponent<RawImage>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        driedTreesCutText.text = "Dried trees cut: " + driedTreesCut;
        friendlyTreesCutText.text = "Friendly trees cut: " + friendlyTreesCut;
        float xValue = -(player.healthAsPercentage / 2f) - 0.5f;
        healthBarRawImage.uvRect = new Rect(xValue, 0f, 0.5f, 1f);
        SetGameOverPanel();
    }
    void SetGameOverPanel()
    {
        if (player.isDead)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            // Cursor.visible = true;
            gameOverPanel.SetActive(true);
            treesCut.text = "" + (friendlyTreesCut + driedTreesCut);
            driedTreesCutPanel.SetActive(false);
            friendlyTreesCutPanel.SetActive(false);
            TimeLeftPanel.SetActive(false);
            HealthBarPanel.SetActive(false);
            HealthMaskPanel.SetActive(false);
            
        }
    }
}
