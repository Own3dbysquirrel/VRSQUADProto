using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMicrophone : StateMachineBehaviour {

    public int recordDuration;
    private int _sampleWindow = 128;

    public string companyName;
    public string userName;
    public string formationName;

    private DialogueManager npcDialogueManager;

    private AudioClip newAudioClip;

    private string fileName;

    /*
    float LevelMax()
    {

        float levelMax = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1); // null means the first microphone
        if (micPosition < 0) return 0;
        newAudioClip.GetData(waveData, micPosition);
     //   Debug.Log(micPosition);
        // Getting a peak on the last 128 samples
        for (int i = 0; i < _sampleWindow; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return levelMax;
    }
    */

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npcDialogueManager = animator.gameObject.GetComponent<DialogueManager>();
        npcDialogueManager.micParent.SetActive(true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*
        // Decibel conversion
        npcDialogueManager.microphoneVolume = 20 * Mathf.Log10(Mathf.Abs(LevelMax()));
        */

     }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
