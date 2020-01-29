using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class AstreControler : MonoBehaviour
{
    public AudioSource[] tab_audio;
    public bool isRotate = false;
    private bool isSun = true;

    public GameObject Sun;
    public GameObject Moon;

    public Light2D Lum_Background;

    public float RotateSpeed = 5f;
    public float Radius = 7.0f;

    private Vector2 _centre;
    private float _angle;

    public Color color_Jour = new Color(1, 1, 1); 
    public Color color_Nuit = new Color(0 / 255f, 19 / 255f, 183 / 255f);
    public GameObject m_atroGroup;
    public Light2D m_lightRocks;

    public bool GetIsSun()
    {
        return isSun;
    }

    void Start()
    {
        _centre = transform.position;
        _angle = 0;
        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;

        //Pos de base du soleil et de la lune
        Sun.transform.position = _centre + offset;
        Moon.transform.position = _centre - offset;

        Lum_Background.color = color_Jour;
    }

    void Update()
    {
        if (isSun)
            Lum_Background.color = color_Jour;
        else
            Lum_Background.color = color_Nuit;

        if (isRotate && isSun)
        {

            _angle += RotateSpeed * Time.deltaTime; 
            if (_angle % (2 * Mathf.PI) < Mathf.PI )
            {
                var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
                Sun.transform.position = _centre + offset;
                Moon.transform.position = _centre - offset;

                //evolution couleur vers nuit
                float t = _angle % (2 * Mathf.PI) / Mathf.PI;
                Lum_Background.color = Color.Lerp(color_Jour, color_Nuit,t);
                m_lightRocks.intensity = 1-t;
            }
            else //fin passage jour à nuit
            {
                tab_audio[1].Play();
                isSun = false;
                isRotate = false;
                Lum_Background.color = color_Nuit;
                string status = GetIsSun() ? "day" : "night";
                LigthTrigger[] t = m_atroGroup.GetComponentsInChildren<LigthTrigger>();

                for (int i = 0; i < t.Length; i++)
                {
                    t[i].tag = status;
                }
            }
        }

        if (isRotate && !isSun)
        {
            _angle += RotateSpeed * Time.deltaTime;
            if (_angle % (2 * Mathf.PI) > Mathf.PI)
            {
                var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
                Sun.transform.position = _centre + offset;
                Moon.transform.position = _centre - offset;


                float t = 1 - (_angle % (2 * Mathf.PI) - Mathf.PI )/ Mathf.PI;
                Lum_Background.color = Color.Lerp(color_Jour, color_Nuit, t);
                m_lightRocks.intensity = 1-t;
            }
            else //fin passage nuit à jour
            {
                tab_audio[0].Play();
                Lum_Background.color = color_Jour;
                isSun = true;
                isRotate = false;

                string status = GetIsSun() ? "day" : "night";
                LigthTrigger[] t = m_atroGroup.GetComponentsInChildren<LigthTrigger>();

                for (int i = 0; i < t.Length; i++)
                {
                    t[i].tag = status;
                }
            }
        }
    }
}
