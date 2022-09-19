using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    public static bool canMove = true;

    [Header("속도 관련 변수")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jetPackSpeed;
    Rigidbody myRigid;

    public bool IsJet { get; private set; }

    [Header("파티클 시스템(부스터)")]
    [SerializeField] ParticleSystem ps_LeftEngine;
    [SerializeField] ParticleSystem ps_RightEngine;

    private AudioSource audioSource;

    JetEngineFuelManager theFuel;

    // Start is called before the first frame update
    void Start()
    {
        IsJet = false;
        myRigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        theFuel = FindObjectOfType<JetEngineFuelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        TryMove();
        TryJet();
    }

    void TryJet()
    {
        if (Input.GetKey(KeyCode.Space) && theFuel.IsFuel && canMove)
        {

            if (!IsJet)
            {
                ps_LeftEngine.Play();
                ps_RightEngine.Play();
                audioSource.Play();
                IsJet = true;

            }

            myRigid.AddForce(Vector3.up * jetPackSpeed);
        }
        else
        {
            if (IsJet)
            {
                ps_LeftEngine.Stop();
                ps_RightEngine.Stop();
                audioSource.Stop();
                IsJet = false;

            }
            myRigid.AddForce(Vector3.down * jetPackSpeed);
        }
    }

    void TryMove()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && canMove)
        {
            // D키 = 1, A키 = -1
            Vector3 moveDir = new Vector3(0, 0, Input.GetAxisRaw("Horizontal"));
            myRigid.AddForce(moveDir * moveSpeed);
        }   

    }
}
