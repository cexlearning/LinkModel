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

    private int eyeIndex = 0;
    private int eyeBrowIndex = 0;
    private int _maskIndex = 0;

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
        _maskIndex = Shader.PropertyToID("_EyeMaskTex");
    }
	
	// Update is called once per frame
	void Update ()
    {
	
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
            eyeIndex++;
            eyeIndex = eyeIndex % eyes.Length;
            _eyeMtl1.SetTexture(_mainTexId, eyes[eyeIndex]);
            _eyeMtl2.SetTexture(_mainTexId, eyes[eyeIndex]);
            _pupilMtl1.SetTexture(_maskIndex, eyes[eyeIndex]);
            _pupilMtl2.SetTexture(_maskIndex, eyes[eyeIndex]);
        }

        if (GUILayout.Button("更换Eyebrow"))
        {
            eyeBrowIndex++;
            eyeBrowIndex = eyeBrowIndex % eyebrows.Length;
            _eyebrowMtl1.SetTexture(_mainTexId, eyebrows[eyeBrowIndex]);
            _eyebrowMtl2.SetTexture(_mainTexId, eyebrows[eyeBrowIndex]);
        }
    }
}
