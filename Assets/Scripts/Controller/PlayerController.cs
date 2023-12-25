using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerState curState;
    public Animator animator;
    public float speed;

    public PlayerState CurState
    {
        get { return this.curState; }
        set
        {
            curState = value;
            switch (curState)
            {
                case PlayerState.Idle:
                    PlayAnimation("Idle");
                    break;
                case PlayerState.Move:
                    PlayAnimation("Move");
                    break;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CurState = PlayerState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        switch (curState)
        {
            case PlayerState.Idle:
                if (h != 0 || v != 0) CurState = PlayerState.Move;
                break;
            case PlayerState.Move:
                if (h == 0 && v == 0) CurState = PlayerState.Idle;
                break;
        }
        this.transform.Translate(speed * Time.deltaTime * new Vector3(h, v, 0));
        if (h > 0) transform.localScale = Vector3.one;
        else if (h < 0) transform.localScale = new Vector3(-1, 1, 1);
    }


    private void PlayAnimation(string name)
    {
        animator.CrossFadeInFixedTime(name, 0);
    }

}

public enum PlayerState
{
    Idle, Move
}
