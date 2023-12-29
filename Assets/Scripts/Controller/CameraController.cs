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
    private Vector3 screenXY;

    private void Awake()
    {
        main = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        //ÆÁÄ»×ø±ê×ª»»
        screenXY = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 res = Vector3.SmoothDamp(main.transform.position, target.transform.position, ref speed, Time.deltaTime * smoothCoefficient);
        res.x = Mathf.Clamp(res.x,BattleController.instance.rangeX.x + screenXY.x, BattleController.instance.rangeX.y - screenXY.x);
        res.y = Mathf.Clamp(res.y,BattleController.instance.rangeY.x + screenXY.y, BattleController.instance.rangeY.y - screenXY.y);
        res.z = -10;
        main.transform.position = res;
    }
}
