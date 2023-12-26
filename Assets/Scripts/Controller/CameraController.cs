using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 speed;
    public GameObject target;
    private Camera main;
    public float smoothCoefficient;

    private void Awake()
    {
        main = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 res = Vector3.SmoothDamp(main.transform.position, target.transform.position, ref speed, Time.deltaTime * smoothCoefficient);
        res.x = Mathf.Clamp(res.x,BattleController.instance.rangeX.x + Screen.width / 2 , BattleController.instance.rangeX.y - Screen.width / 2);
        res.y = Mathf.Clamp(res.y,BattleController.instance.rangeY.x + Screen.height / 2, BattleController.instance.rangeY.y - Screen.height / 2);
        res.z = -10;
        main.transform.position = res;
    }
}
