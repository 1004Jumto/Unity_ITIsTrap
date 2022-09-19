using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{

    int currentScore;       // ���� ����
    public static int extraScore;       // ������ ����
    int distanceScore;      // �Ÿ� ����
    float maxDistance;      // �÷��̾ �̵��� �ִ� �Ÿ�
    float originPosZ;       // �÷��̾��� ���� ��ġ�� z��


    [SerializeField] Text txt_Score;
    [SerializeField] Transform tf_Player;       // �÷��̾��� ��ġ ����


    private void Start()
    {
        originPosZ = tf_Player.position.z;
    }

    // Update is called once per frame
    void Update()
    {

        if(tf_Player.position.z > maxDistance)
        {
            maxDistance = tf_Player.position.z;
            distanceScore = Mathf.RoundToInt(maxDistance - originPosZ);
        }
        currentScore = extraScore + distanceScore;
        txt_Score.text = string.Format("{0:000,000}", currentScore);
    }
}
