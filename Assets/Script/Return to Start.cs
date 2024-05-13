using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace LevelUp.GrabInteractions
{
    public class ResetObject : MonoBehaviour
    {
        XRGrabInteractable m_GrabInteractable;

        [Tooltip("The Transform that the object will return to")]
        [SerializeField] Vector3 returnToPosition;
        [SerializeField] Quaternion returnToRotation;
        [SerializeField] float resetDelayTime;
        protected bool shouldReturnHome { get; set; }
        bool isController;

        // Start is called before the first frame update
        void Awake()
        {
            m_GrabInteractable = GetComponent<XRGrabInteractable>();
            returnToPosition = this.transform.position;
            returnToRotation = this.transform.rotation;
            shouldReturnHome = true;
        }

        private void OnEnable()
        {
            m_GrabInteractable.selectExited.AddListener(OnSelectExit);
            m_GrabInteractable.selectEntered.AddListener(OnSelect);
        }

        private void OnDisable()
        {
            m_GrabInteractable.selectExited.RemoveListener(OnSelectExit);
            m_GrabInteractable.selectEntered.RemoveListener(OnSelect);
        }

        private void OnSelect(SelectEnterEventArgs arg0) => CancelInvoke("ReturnHome");
        private void OnSelectExit(SelectExitEventArgs arg0) => Invoke(nameof(ReturnHome), resetDelayTime);

        protected virtual void ReturnHome()
        {

            if (shouldReturnHome)
            {
                transform.position = returnToPosition;
                transform.rotation = returnToRotation;
            }
                
        }

        private void OnTriggerEnter(Collider other)
        {

            if (ControllerCheck(other.gameObject))
                return;

            var socketInteractor = other.gameObject.GetComponent<XRSocketInteractor>();

            if (socketInteractor == null)
                shouldReturnHome = true;

            else if (socketInteractor.CanSelect(m_GrabInteractable))
            {
                shouldReturnHome = false;
            }
            else
                shouldReturnHome = true; //The socket interactor exists and CANNOT select the Grab object
        }

        private void OnTriggerExit(Collider other)
        {
            if (ControllerCheck(other.gameObject))
                return;

            shouldReturnHome = true;
        }

        bool ControllerCheck(GameObject collidedObject)
        {
            //first check that this is not the collider of a controller
            isController = collidedObject.gameObject.GetComponent<XRBaseController>() != null ? true : false;
            return isController;
        }
    }
}

/*
public class ReturntoStart : MonoBehaviour
{
    Vector3 startPosition, driftPosition;
    Quaternion startRotation, driftRotation;

    public float driftSeconds = 3;
    private float driftTimer = 0;
    private bool isDrifting = false;
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        
    }
    private void StartDrift()
    {
        isDrifting = true;
        driftTimer = 0;

        driftPosition = transform.position;
        driftRotation = transform.rotation;

        Rigidbody rb = GetComponent<Rigidbody>(); // Corrected line
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void StopDrift()
    {
        isDrifting = false;
        transform.position = startPosition;
        transform.rotation = startRotation;

        Rigidbody rb = GetComponent<Rigidbody>(); // Corrected line
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartDrift();
        }
        if (Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            StartDrift();
        }

        if (isDrifting)
        {
            driftTimer += Time.deltaTime;
            if (driftTimer > driftSeconds)
            {
                StopDrift();
            }
            else
            {
                float ratio = driftTimer / driftSeconds;
                transform.position = Vector3.Lerp(driftPosition, startPosition, ratio);
                transform.rotation = Quaternion.Slerp(driftRotation, startRotation, ratio);
            }
        }
        
    }
}
*/
