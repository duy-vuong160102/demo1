using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class diem : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int currentDiem= 0;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        currentDiem++;
        text.text = currentDiem.ToString();
    }
}
