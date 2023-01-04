using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeAnim : MonoBehaviour
{
    private Animator player;
    private void Start()
    {
        player = gameObject.GetComponent<Animator>();
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 140, 100, 30), "ChangeAnim"))
        {
            ChangeAnim(1);
        }

        if (GUI.Button(new Rect(10, 180, 100, 30), "ChangeAnim2"))
        {
            ChangeAnim(2);
        }

        if (GUI.Button(new Rect(10, 220, 100, 30), "default"))
        {
            ChangeAnim(0);
        }
    }
    void ChangeAnim(int num)
    {
        player.SetInteger("animNum", num);
    }
}
