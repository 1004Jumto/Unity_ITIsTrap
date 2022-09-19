using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{

    [SerializeField] Animation anim;
    [SerializeField] float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        anim.Play();
        Destroy(gameObject, destroyTime);
    }

    
}
