using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileSelection : MonoBehaviour {

    public Text nameText;
    public Text jobText;
    public Text companyText;

    public Image profileImage;

    public GameObject buttonClicked;

    public void UpdateProfileInfo(string fullName, string job, string company, Sprite profileImg, GameObject clickOrigin)
    {
        nameText.text = fullName;
        jobText.text = job;
        companyText.text = company;

        profileImage.sprite = profileImg;

        if(buttonClicked != null)
             buttonClicked.SetActive(true);

        buttonClicked = clickOrigin;
        buttonClicked.SetActive(false);
    }
}
