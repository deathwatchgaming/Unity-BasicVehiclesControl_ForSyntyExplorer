/*
 * File: Jeep 02 Entry (New Input System) 
 * Name: Jeep02Entry.cs
 * Author: DeathwatchGaming
 * License: MIT
 * Unity Version(s): Unity 6+
 */

// using
using UnityEngine;
using NavigationControl;
using System.Collections;
using UnityEngine.InputSystem;

// namespace VehiclesControl
namespace VehiclesControl
{
    // RequireComponent typeof BoxCollider
    [RequireComponent(typeof(BoxCollider))]

    // public class Jeep02Entry 
    public class Jeep02Entry : MonoBehaviour
    {  
        // Game Objects
        [Header("Game Objects")]

            [Tooltip("The jeep 02 game object")]
            // GameObject _jeep02
            [SerializeField] private GameObject _jeep02;

            [Tooltip("The player game object")]
            // GameObject _player
            [SerializeField] private GameObject _player;

            [Tooltip("The interface text game object")]
            // GameObject _interfaceTextObject
            [SerializeField] private GameObject _interfaceTextObject;

        // Rigidbody Sleep
        [Header("Rigidbody Sleep")]

            [Tooltip("The rigidbody sleep wait for seconds duration")]
            // float duration is 0.0001
            [SerializeField] private float duration = 0.0001f; 
        
        // Active State
        [Header("Active State")]

            [Tooltip("The active state bool")]
            // bool _inJeep02 is false
            [SerializeField] private bool _inJeep02 = false;

        // Compass
        [Header("Compass")]

            [Tooltip("The player compass")]
            // PlayerCompass _playerCompass
            [SerializeField] private PlayerCompass _playerCompass;
            
            [Tooltip("The jeep 02 compass")]
            // Jeep02Compass _jeep02Compass
            [SerializeField] private Jeep02Compass _jeep02Compass;

        // Input Actions
        [Header("Input Actions")] 

            [Tooltip("The input action asset")]
            // InputActionAsset _carControls
            [SerializeField] private InputActionAsset _carControls;

        // InputAction _carEnterAction
        private InputAction _carEnterAction;

        // InputAction _carExitAction
        private InputAction _carExitAction;

        // bool _enterButton
        private bool _enterButton;

        // bool _exitButton
        private bool _exitButton;

        // Jeep02Controller _jeep02Script
        private Jeep02Controller _jeep02Script;
        
        // Camera _jeep02Camera
        private Camera _jeep02Camera;

        // AudioListener _jeep02CameraAudioListener
        private AudioListener _jeep02CameraAudioListener; 

        // Rigidbody _rigidbody
        private Rigidbody _rigidbody;

        // GameObject FindInActiveObjectByName
        GameObject FindInActiveObjectByName(string name)
        {
            // Transform[] objs
            Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];

            // for
            for (int i = 0; i < objs.Length; i++)
            {
                // if
                if (objs[i].hideFlags == HideFlags.None)
                {
                    // if
                    if (objs[i].name == name)
                    {
                        // return
                        return objs[i].gameObject;

                    } // close if

                } // close if

            } // close for

            // return
            return null;

        } // close GameObject FindInActiveObjectByName  

        //public static Jeep02Entry _jeep02Entry;

        // private void Awake
        private void Awake()
        {
            // _carEnterAction
            _carEnterAction = _carControls.FindActionMap("Car").FindAction("Enter");

            // _carExitAction
            _carExitAction = _carControls.FindActionMap("Car").FindAction("Exit");

        } // close private void Awake

        // private void OnEnable
        private void OnEnable()
        {
            // _carEnterAction Enable
            _carEnterAction.Enable();

            // _carExitAction Enable
            _carExitAction.Enable();

        } // close private void OnEnable

        // private void OnDisable
        private void OnDisable()
        {
            // _carEnterAction Disable
            _carEnterAction.Disable();

            // _carExitAction Disable
            _carExitAction.Disable();  

        } // close private void OnDisable

        // private void Start
        private void Start() 
        {
            //_jeep02Entry = this;
            
            // _jeep02Script is GetComponent Jeep02Controller
            _jeep02Script = GetComponent<Jeep02Controller>();

            // _jeep02Script enabled is false
            _jeep02Script.enabled = false;
            
            // _jeep02Camera is GetComponentInChildren Camera
            _jeep02Camera = GetComponentInChildren<Camera>();
            
            // _jeep02Camera enabled is false
            _jeep02Camera.enabled = false;

            // _jeep02CameraAudioListener is GetComponentInChildren AudioListener
            _jeep02CameraAudioListener = GetComponentInChildren<AudioListener>();
            
            // _jeep02CameraAudioListener enabled is false
            _jeep02CameraAudioListener.enabled = false; 

            // _rigidbody
            _rigidbody = GetComponent<Rigidbody>();

            // GameObject _interfaceTextObject is FindInActiveObjectByName Jeep02_EntryKey
            GameObject _interfaceTextObject = FindInActiveObjectByName("Jeep02_EntryKey");

            // _interfaceTextObject SetActive is false
            _interfaceTextObject.SetActive(false);

            // Compass

            // _playerCompass enabled is true
            _playerCompass.enabled = true;

            // _playerCompass compassEnabled is true
            _playerCompass.compassEnabled = true;

            // Debug Log
            //Debug.Log("The Player compass is enabled");

            // _jeep02Compass enabled is false
            _jeep02Compass.enabled = false;

            // _jeep02Compass compassEnabled is false
            _jeep02Compass.compassEnabled = false;

            // Debug Log
            //Debug.Log("The Jeep02 compass is disabled");

    	} // close private void Start

        // Update is called once per frame

        // private void Update
        private void Update()
        {
            // if_carEnterAction triggered
            if (_carEnterAction.triggered)
            {
                // _enterButton is true
                _enterButton = true;

                // _exitButton is false
                _exitButton = false;

            } // close if_carEnterAction triggered

            // if _carExitAction triggered
            if (_carExitAction.triggered)
            {
                // _enterButton is false
                _enterButton = false;

                // _exitButton is true
                _exitButton = true;

            } // close if _carExitAction triggered
            
            // if _inJeep02 and Input GetKey KeyCode _exitKey
            if (_inJeep02 && _exitButton == true)
            {
                // _player SetActive is true
                _player.SetActive(true);

                // _player transform parent is null
                _player.transform.parent = null;

                // _jeep02Script enabled is false
                _jeep02Script.enabled = false;
                
                // _jeep02Camera enabled is false
                _jeep02Camera.enabled = false;

                // _jeep02CameraAudioListener enabled is false
                _jeep02CameraAudioListener.enabled = false;                 

                // _inJeep02 is false
                _inJeep02 = false;

                // Compass

                // _playerCompass enabled is true
                _playerCompass.enabled = true;

                // _playerCompass compassEnabled is true 
                _playerCompass.compassEnabled = true;

                // Debug Log
                //Debug.Log("The Player compass is enabled");

                // _jeep02Compass enabled is false
                _jeep02Compass.enabled = false;

                // _jeep02Compass compassEnabled is false
                _jeep02Compass.compassEnabled = false;

                // Debug Log
                //Debug.Log("The Jeep02 compass is disabled");         

            } // close if _inJeep02 and Input GetKey KeyCode _exitKey

        } // close private void Update         

        // private void OnTriggerStay Collider other
        private void OnTriggerStay(Collider other)
        {
        	// if not _inJeep02 and gameObject tag is Player
            if (!_inJeep02 && other.gameObject.tag == "Player")
            {
            	// _interfaceTextObject SetActive is true
                _interfaceTextObject.SetActive(true);

            } // close if not _inJeep02 and gameObject tag is Player
            
            // if not _inJeep02 and gameObject tag is Player and Input GetKey KeyCode _enterKey
            if (!_inJeep02 && other.gameObject.tag == "Player" && _enterButton == true)
            {
                // _interfaceTextObject SetActive is false
                _interfaceTextObject.SetActive(false);

                // _player SetActive is false 
                _player.SetActive(false);

                // _player transform parent is _jeep02 transform
                _player.transform.parent = _jeep02.transform;

                // _jeep02Script enabled is true
                _jeep02Script.enabled = true;
                
                // _jeep02Camera enabled is true
                _jeep02Camera.enabled = true;

                // _jeep02CameraAudioListener enabled is true
                _jeep02CameraAudioListener.enabled = true; 

                // _inJeep02 is true
                _inJeep02 = true;

                // Compass

                // _playerCompass enabled is false
                _playerCompass.enabled = false;

                // _playerCompass compassEnabled is false
                _playerCompass.compassEnabled = false;

                // Debug Log
                //Debug.Log("The Player compass is disabled"); 

                // _jeep02Compass enabled is true
                _jeep02Compass.enabled = true;

                // _jeep02Compass compassEnabled is true
                _jeep02Compass.compassEnabled = true;

                // Debug Log
                //Debug.Log("The Jeep02 compass is enabled");                

            } // close if not _inJeep02 and gameObject tag is Player and Input GetKey KeyCode _enterKey

        } // close private void OnTriggerStay Collider other
        
        // private void OnTriggerExit Collider other
        private void OnTriggerExit(Collider other)
        {
            // if gameObject tag is Player
            if (other.gameObject.tag == "Player")
            {
            	// _interfaceTextObject SetActive is false
                _interfaceTextObject.SetActive(false);
                
                // StartCoroutine RigidbodySleep duration
                StartCoroutine(RigidbodySleep(duration)); 

            } // close if gameObject tag is Player

        } // close private void OnTriggerExit Collider other

        // private IEnumerator RigidbodySleep float duration
        private IEnumerator RigidbodySleep(float duration) 
        {
            // WaitForSeconds duration
            yield return new WaitForSeconds(duration);
            
            // _rigidbody Sleep
            _rigidbody.Sleep();

        } // close private IEnumerator RigidbodySleep float duration  
        
    } // close public class Jeep02Entry  

} // close namespace VehiclesControl
