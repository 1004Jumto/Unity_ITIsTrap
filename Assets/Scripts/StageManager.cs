using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] Text txt_CurrentScore;
    [SerializeField] GameObject go_UI;
    [SerializeField] ScoreManager theSM;
    [SerializeField] GameObject[] go_Stages;

    [SerializeField] Rigidbody playerRigid;
    [SerializeField] Transform tf_OriginPos;
    int currentStage = 0;

    public void ShowClearUI()
    {
        PlayerController.canMove = false;
        playerRigid.isKinematic = true;
        go_UI.SetActive(true);
        txt_CurrentScore.text = string.Format("{0:000,000}", theSM.GetCurrentScore());

    }

    public void NextBtn()
    {

        if(currentStage < go_Stages.Length - 1)
        {
            PlayerController.canMove = true;
            playerRigid.isKinematic = false;
            theSM.ResetCurrentScore();
            playerRigid.gameObject.transform.position = tf_OriginPos.position;
            go_Stages[currentStage++].SetActive(false);
            go_Stages[currentStage].SetActive(true);
            go_UI.SetActive(false);

        }
        else
        {
            Debug.Log("모든 스테이지를 클리어 함");
        }
    }
}
