using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeRoom : MonoBehaviour
{

    public static ChangeRoom changeRoomInst;

    public MeshRenderer[] skyboxPositionsList;

    private Image blackScreen;
    private DialogueManager dialogManag;

    // Use this for initialization
    void Awake()
    {
        dialogManag = DialogueManager.dialogueManagerInstance;

        changeRoomInst = this;

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }


        skyboxPositionsList = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer skyB in skyboxPositionsList)
        {
            skyB.gameObject.SetActive(false);
        }
        skyboxPositionsList[0].gameObject.SetActive(true);

        blackScreen = PlayerManager.playerManagerInst.blackScreen;

    }

    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.DpadUp) || Input.GetKeyDown(KeyCode.X))
        {
            GoToRoom(1);
        }


        if (OVRInput.GetDown(OVRInput.Button.DpadDown) || Input.GetKeyDown(KeyCode.W))
        {
            GoToRoom(0);
        }

    }

    public void GoToRoom(int i)
    {
        StartCoroutine(FadeInOut(i));
    }


   IEnumerator FadeInOut(int i)
    {

        // Fade In
        while (blackScreen.color.a < 1)
        {
            var tempcolor = blackScreen.color;
            tempcolor.a += 0.025f;
            blackScreen.color = tempcolor;
            yield return new WaitForSeconds(0.025f);
        }

        // Téléportation
        foreach (MeshRenderer skyB in skyboxPositionsList)
        {
            skyB.gameObject.SetActive(false);
        }

        skyboxPositionsList[i].gameObject.SetActive(true);
        PlayerManager.playerManagerInst.playerController.transform.position = skyboxPositionsList[i].transform.position;
        dialogManag.transform.position = skyboxPositionsList[i].transform.position;

        // Fade Out
        while (blackScreen.color.a > 0)
        {
            var tempcolor = blackScreen.color;
            tempcolor.a -= 0.025f;
            blackScreen.color = tempcolor;
            yield return new WaitForSeconds(0.025f);
        }

       
        yield break;
    }
}
