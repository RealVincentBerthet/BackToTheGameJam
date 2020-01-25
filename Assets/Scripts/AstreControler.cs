using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class AstreControler : MonoBehaviour
{
    public bool isRotate = false;
    private bool isSun = true;

    public GameObject Sun;
    public GameObject Moon;

    public Light2D Lum_Background;

    private float RotateSpeed = 5f;
    private float Radius = 7.0f;

    private Vector2 _centre;
    private float _angle;




    // Start is called before the first frame update
    void Start()
    {
        print(Lum_Background.color);
        _centre = transform.position;
        _angle = 0;
        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        Sun.transform.position = _centre + offset;
        Moon.transform.position = _centre - offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotate && isSun)
        {

            _angle += RotateSpeed * Time.deltaTime;
            print(_angle);
            if (_angle % (2 * Mathf.PI) < Mathf.PI )
            {
                var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
                Sun.transform.position = _centre + offset;
                Moon.transform.position = _centre - offset;
            }
            else
            {
                isSun = false;
                isRotate = false;
                Lum_Background.color = new Color(0 / 255f, 19 / 255f, 183 / 255f);
            }

        }

        if (isRotate && !isSun)
        {

            _angle += RotateSpeed * Time.deltaTime;
            print(_angle);
            if (_angle % (2 * Mathf.PI) > Mathf.PI)
            {
                var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
                Sun.transform.position = _centre + offset;
                Moon.transform.position = _centre - offset;
            }
            else
            {
                Lum_Background.color = new Color(1, 1, 1);
                isSun = true;
                isRotate = false;
            }

        }

    }
}
