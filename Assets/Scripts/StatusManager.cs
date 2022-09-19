using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatusManager : MonoBehaviour
{
    [SerializeField] int maxHp;     // 최대 체력
    int currentHp;                  // 현재 체력

    [SerializeField] Text[] txt_HpArray;        // 체력 UI


    bool isInvincibleMode = false;      // 현재 무적 상태인지


    [SerializeField] float blinkSpeed;
    [SerializeField] int blinkCount;

    [SerializeField] MeshRenderer mesh_PlayerGraphics;


    private void Start()
    {
        currentHp = maxHp;
        UpdateHpStatus();
    }
    public void DecreaseHp(int _num)
    {
        if (!isInvincibleMode)
        {
            currentHp -= _num;
            UpdateHpStatus();

            if(currentHp <= 0)
            {
                PlayerDead();
            }

            SoundManager.instance.PlaySE("Hurt");
            StartCoroutine(BlinkCoroutine());

        }
    }

    public void IncreaseHp(int _num)
    {
        if (currentHp == maxHp)
            return;
        
        currentHp += _num;
        if(currentHp > maxHp)
        {
            currentHp = maxHp;
        }

        UpdateHpStatus();
    }

    IEnumerator BlinkCoroutine()
    {
        isInvincibleMode = true;
        for (int i=0; i<blinkCount * 2; i++)
        {
            mesh_PlayerGraphics.enabled = !mesh_PlayerGraphics.enabled;
            yield return new WaitForSeconds(blinkSpeed);
        }
        isInvincibleMode = false;
    }

    void UpdateHpStatus()
    {
        for(int i=0; i < txt_HpArray.Length; i++)
        {
            if (i < currentHp)
            {
                txt_HpArray[i].gameObject.SetActive(true);
            }
            else
            {
                txt_HpArray[i].gameObject.SetActive(false);
            }
        }
    }

    void PlayerDead()
    {
        Debug.Log("플레이어가 죽었습니다");
    }
}
