using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class PlayerHealthBar : MonoBehaviour
{
    RawImage healthBarRawImage;
    Player player;
    public int driedTreesCut;
    public Text driedTreesCutText;
    public int friendlyTreesCut;
    public Text friendlyTreesCutText;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        healthBarRawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        driedTreesCutText.text = "Dried trees cut: " + driedTreesCut;
        friendlyTreesCutText.text = "Friendly trees cut: " + friendlyTreesCut;
        float xValue = -(player.healthAsPercentage / 2f) - 0.5f;
        healthBarRawImage.uvRect = new Rect(xValue, 0f, 0.5f, 1f);
    }
    

}
