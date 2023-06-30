//----------------------------------------------
//            Realistic Car Controller
//
// Copyright © 2014 - 2017 BoneCracker Games
// http://www.bonecrackergames.com
// Buğra Özdoğanlar
//
//----------------------------------------------
using System.Collections;
using UnityEngine;
/// <summary>
/// Sets new camera settings to RCC Camera per vehicle.
/// </summary>
[AddComponentMenu("BoneCracker Games/Realistic Car Controller/Camera/RCC Camera Config")]
public class RCC_CameraConfig : MonoBehaviour
{
    public static RCC_CameraConfig instance;
    public bool automatic = true;
    private Bounds combinedBounds;
    public float distance = 10f;
    public float height = 5f;
    [HideInInspector] public bool isEnter;
    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {

        if (automatic)
        {
            Quaternion orgRotation = transform.rotation;
            transform.rotation = Quaternion.identity;

            distance = MaxBoundsExtent(transform) * 2.75f;
            height = MaxBoundsExtent(transform) * .6f;

            if (height < 1)
            {
                height = 1;
            }

            transform.rotation = orgRotation;

        }
        isEnter = false;
    }

    public void SetCameraSettings()
    {

        RCC_Camera cam = RCC_SceneManager.Instance.activePlayerCamera;

        if (!cam)
        {
            return;
        }

        cam.TPSDistance = distance;
        cam.TPSHeight = height;

    }

    public static float MaxBoundsExtent(Transform obj)
    {

        // get the maximum bounds extent of object, including all child renderers,
        // but excluding particles and trails, for FOV zooming effect.

        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();

        Bounds bounds = new Bounds();
        bool initBounds = false;
        foreach (Renderer r in renderers)
        {
            if (!((r is TrailRenderer) || (r is ParticleSystemRenderer)))
            {
                if (!initBounds)
                {
                    initBounds = true;
                    bounds = r.bounds;
                }
                else
                {
                    bounds.Encapsulate(r.bounds);
                }
            }
        }
        float max = Mathf.Max(bounds.extents.x, bounds.extents.y, bounds.extents.z);
        return max;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "GripEnter")
        {
            GetComponent<HandleTyreGrip>().enabled = true;
            if (GetComponent<RCC_CarControllerV3>().speed < 40f)
            {
                isEnter = true;
            }

        }
        else if (other.GetComponent<Collider>().tag == "GripExit")
        {
            GetComponent<HandleTyreGrip>().enabled = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            StartCoroutine(EnableCameras());
        }
        else if (other.GetComponent<Collider>().tag == "Death")
        {
            Camera.main.GetComponentInParent<RCC_Camera>().enabled = false;
           // LeanTween.move(UIManager.instance.gameFailed.GetComponent<RectTransform>(), Vector3.zero, 1.0f).setIgnoreTimeScale(true).setEaseSpring();
         //   UIManager.instance.controls.alpha = 0.0f;
         //   UIManager.instance.controls.blocksRaycasts = false;
         //   LeanTween.delayedCall(2.0f, GameFailed).setIgnoreTimeScale(true);
        }
        else if (other.GetComponent<Collider>().tag == "Win")
        {
         //   LeanTween.move(UIManager.instance.gameComplete.GetComponent<RectTransform>(), Vector3.zero, 1.0f).setIgnoreTimeScale(true).setEaseSpring();
         //   UIManager.instance.controls.alpha = 0.0f;
        //    UIManager.instance.controls.blocksRaycasts = false;
        //    LeanTween.delayedCall(2.0f, GameComplete).setIgnoreTimeScale(true);
        }
    }

    private IEnumerator EnableCameras()
    {
        yield return new WaitForSeconds(1.5f);
      //  UIManager.instance.sideCamera.SetActive(true);
    }

    private void GameFailed()
    {
      //  UIManager.instance.gameOver = true;
    }
    private void GameComplete()
    {
      //  UIManager.instance.gamecomplete = true;
    }
}
