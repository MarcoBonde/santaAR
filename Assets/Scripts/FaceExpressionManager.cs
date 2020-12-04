using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FaceExpressionManager : MonoBehaviour
{
    public static FaceExpressionManager Singleton;

    public FaceExpressionInstance CurrentFaceInstance;

    public float MouthOpenValue;

    public Text DebugText;

    public UnityEvent ShouldFly;

    public GameObject Santagame;
    public GameObject bottone1;
    public GameObject Camera1;
    public GameObject Camera2;

    private void OnEnable()
    {
        Singleton = this;
    }


    public void SetStandardFaceData()
    {
        if (CurrentFaceInstance != null)
        {
            CurrentFaceInstance.SetStandardFaceData();
           
        }
        Santagame.SetActive(true);
        bottone1.SetActive(false);
        Camera1.SetActive(false);
        Camera2.SetActive(true);
    }

    public void SetOpenMouthFaceData()
    {
        if (CurrentFaceInstance != null)
        {
            CurrentFaceInstance.SetOpenMouthFaceData();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FlySanta());
    }

    // Update is called once per frame
    void Update()
    {
        DebugText.text = MouthOpenValue.ToString();
    }

    IEnumerator FlySanta()
    {
        while (true)
        {
            if (MouthOpenValue == 1)
            {
                ShouldFly.Invoke();
            }
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }
}
