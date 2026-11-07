using UnityEngine;
using UnityEngine.InputSystem; // Unity 6 uses the new Input System by default

public class SaberScript : MonoBehaviour
{
    public float extendSpeed = 0.1f;

    public GameObject blade;


    private bool weaponActive;

    private const float SCALE_MIN = 0f;
    private float scaleMax;

    private float extendDelta;

    private float scaleCurrent;

    private float localScaleX;
    private float localScaleZ;

    private AudioSource audioSource;

    void Start()
    {
        localScaleX = transform.localScale.x;
        localScaleZ = transform.localScale.z;

        scaleMax = transform.localScale.y;
        scaleCurrent = scaleMax;

        extendDelta = scaleMax / extendSpeed;

        weaponActive = true;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            extendDelta = weaponActive ? -Mathf.Abs(extendDelta) : Mathf.Abs(extendDelta);

        }

        scaleCurrent += extendDelta * Time.deltaTime;
        scaleCurrent = Mathf.Clamp(scaleCurrent, SCALE_MIN, scaleMax);
        transform.localScale = new Vector3(localScaleX, scaleCurrent, localScaleZ);

        weaponActive = scaleCurrent > 0;

        if (weaponActive && !blade.activeSelf)
        {
            blade.SetActive(true);
        }
        else if (!weaponActive && blade.activeSelf)
        {
            blade.SetActive(false);
        }
    }
}
