using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatusManager : MonoBehaviour
{
    [SerializeField] int maxHp;     // �ִ� ü��
    int currentHp;                  // ���� ü��

    [SerializeField] Text[] txt_HpArray;        // ü�� UI


    bool isInvincibleMode = false;      // ���� ���� ��������


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
        Debug.Log("�÷��̾ �׾����ϴ�");
    }
}
