using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyController : MonoBehaviour
{
    [SerializeField]private Animator Baby_Animator;
    private int BabyComfort = 0;

    public void UpdateComfort(int i) {
        BabyComfort += i;
        Baby_Animator.SetInteger("Comfort",BabyComfort);
        Debug.Log("Baby comfort is: "+BabyComfort);

    }


}
