using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    // Start is called before the first frame update

    public static BattleController instance;

    public Vector2 rangeX = new();
    public Vector2 rangeY = new();

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }

    }


    void Start()
    {
        object a = GameObject.Find("/nv/Top");
        rangeY.y = GameObject.Find("/Env/Top").transform.position.y;
        rangeY.x = GameObject.Find("/Env/Bottom").transform.position.y;
        rangeX.y = GameObject.Find("/Env/Right").transform.position.x;
        rangeX.x = GameObject.Find("/Env/Left").transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
