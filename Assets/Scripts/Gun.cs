using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Normal_Gun,
}
public class Gun : MonoBehaviour
{
    [Header("ÃÑ À¯Çü")]
    public WeaponType weaponType;

    [Header("ÃÑ ¿¬»ç¼Óµµ Á¶Á¤")]
    public float fireRate;
    
    [Header("ÃÑ¾Ë °³¼ö")]
    public int bulletCount;
    public int maxBulletCount;

    [Header("ÃÑ±¸ ¼¶±¤")]
    public ParticleSystem ps_MuzzleFlash;

    [Header("ÃÑ¾Ë ÇÁ¸®ÆÕ")]
    public GameObject go_Bullet_Prefab;

    [Header("ÃÑ¾Ë ½ºÇÇµå")]
    public float speed;

    [Header("¾Ö´Ï¸ÞÀÌÅÍ")]
    public Animator animator;

    [Header("ÃÑ¾Ë ¹ß»ç »ç¿îµå")]
    public string sound_Fire;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
