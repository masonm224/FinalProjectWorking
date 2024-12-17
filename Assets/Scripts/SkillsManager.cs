using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SkillsManager : MonoBehaviour
{
    public int governmentFunding = 0;

    public TextMeshProUGUI governmentFundingText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        governmentFundingText.text = "Government Funding: " + governmentFunding;
    }
}
