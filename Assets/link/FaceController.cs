using UnityEngine;
using System.Collections;

public class FaceController : MonoBehaviour
{
    public Texture[] mouths;
    public Texture[] eyes;
    public Texture[] eyebrows;
    public GameObject mouthObj;
    public GameObject eyeObj1;
    public GameObject eyebrowObj1;
    public GameObject eyeObj2;
    public GameObject eyebrowObj2;
    public GameObject pupilObj1;
    public GameObject pupilObj2;
    private int mouthIndex = 0;
    private Material _mouthMtl = null;
    private int _mainTexId = 0;
    private Material _eyeMtl1 = null;
    private Material _eyeMtl2 = null;
    private Material _pupilMtl1 = null;
    private Material _pupilMtl2 = null;
    private Material _eyebrowMtl1 = null;
    private Material _eyebrowMtl2 = null;

    private int _eyeIndex = 0;
    private int _eyeBrowIndex = 0;
    private int _maskId = 0;
    private float _pupilX = 0;
    private float _pupilY = 0;
    private float _pupilS = 1;
    private int _XOffsetId = 0;
    private int _YOffsetId = 0;
    private int _ScaleId = 0;

    // Use this for initialization
    void Start ()
    {
        _mouthMtl = mouthObj.GetComponent<MeshRenderer>().material;
        _mainTexId = Shader.PropertyToID("_MainTex");
        _eyeMtl1 = eyeObj1.GetComponent<MeshRenderer>().material;
        _eyeMtl2 = eyeObj2.GetComponent<MeshRenderer>().material;
        _eyebrowMtl1 = eyebrowObj1.GetComponent<MeshRenderer>().material;
        _eyebrowMtl2 = eyebrowObj2.GetComponent<MeshRenderer>().material;
        _pupilMtl1 = pupilObj1.GetComponent<MeshRenderer>().material;
        _pupilMtl2 = pupilObj2.GetComponent<MeshRenderer>().material;
        _maskId = Shader.PropertyToID("_EyeMaskTex");
        _XOffsetId = Shader.PropertyToID("_XOffset");
        _YOffsetId = Shader.PropertyToID("_YOffset");
        _ScaleId = Shader.PropertyToID("_Scale");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("更换Mouth"))
        {
            mouthIndex++;
            mouthIndex = mouthIndex % mouths.Length;
            _mouthMtl.SetTexture(_mainTexId, mouths[mouthIndex]);
        }

        if (GUILayout.Button("更换Eye"))
        {
            _eyeIndex++;
            _eyeIndex = _eyeIndex % eyes.Length;
            _eyeMtl1.SetTexture(_mainTexId, eyes[_eyeIndex]);
            _eyeMtl2.SetTexture(_mainTexId, eyes[_eyeIndex]);
            _pupilMtl1.SetTexture(_maskId, eyes[_eyeIndex]);
            _pupilMtl2.SetTexture(_maskId, eyes[_eyeIndex]);
        }

        if (GUILayout.Button("更换Eyebrow"))
        {
            _eyeBrowIndex++;
            _eyeBrowIndex = _eyeBrowIndex % eyebrows.Length;
            _eyebrowMtl1.SetTexture(_mainTexId, eyebrows[_eyeBrowIndex]);
            _eyebrowMtl2.SetTexture(_mainTexId, eyebrows[_eyeBrowIndex]);
        }

        GUILayout.Label("瞳孔位置X");
        float pupilX = GUILayout.HorizontalSlider(_pupilX, -0.5f, 0.5f);
        if (pupilX != _pupilX)
        {
            _pupilX = pupilX;
            _pupilMtl1.SetFloat(_XOffsetId, _pupilX);
            _pupilMtl2.SetFloat(_XOffsetId, _pupilX);
        }
       
        GUILayout.Label("瞳孔位置Y");
        float pupilY = GUILayout.HorizontalSlider(_pupilY, -0.5f, 0.5f);
        if (pupilY != _pupilY)
        {
            _pupilY = pupilY;
            _pupilMtl1.SetFloat(_YOffsetId, _pupilY);
            _pupilMtl2.SetFloat(_YOffsetId, _pupilY);
        }
        GUILayout.Label("瞳孔放大");
        float pupilS = GUILayout.HorizontalSlider(_pupilS, 0, 2);
        if (pupilS != _pupilS)
        {
            _pupilS = pupilS;
            _pupilMtl1.SetFloat(_ScaleId, 2 - _pupilS);
            _pupilMtl2.SetFloat(_ScaleId, 2 - _pupilS);
        }
    }
}
