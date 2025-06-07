/*
 * File: Jeep 01 Entry 
 * Name: Jeep01Entry.cs
 * Author: DeathwatchGaming
 * License: MIT
 * Unity Version(s): Unity 6+
 */

// using
using UnityEngine;
using System.Collections;
using NavigationControl;

// namespace VehiclesControl
namespace VehiclesControl
{
    // RequireComponent typeof BoxCollider
    [RequireComponent(typeof(BoxCollider))]

    // public class Jeep01Entry 
    public class Jeep01Entry : MonoBehaviour
    {  
        // Input Customizations
        [Header("Input Customizations")] 

            [Tooltip("The vehicle entry key code")]
            // KeyCode _enterKey
            [SerializeField] private KeyCode _enterKey = KeyCode.E;

            [Tooltip("The vehicle exit key code")]
            // KeyCode _exitKey
            [SerializeField] private KeyCode _exitKey = KeyCode.F;

        // Game Objects
        [Header("Game Objects")]

            [Tooltip("The jeep 01 game object")]
            // GameObject _jeep01
            [SerializeField] private GameObject _jeep01;

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
            // bool _inJeep01 is false
            [SerializeField] private bool _inJeep01 = false;
        
        // Jeep01Controller _jeep01Script
        private Jeep01Controller _jeep01Script;
        
        // Camera _jeep01Camera
        private Camera _jeep01Camera;

        // AudioListener _jeep01CameraAudioListener
        private AudioListener _jeep01CameraAudioListener; 

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

        // Compass
        [Header("Compass")]

            [Tooltip("The player compass")]
            // PlayerCompass _playerCompass
            [SerializeField] private PlayerCompass _playerCompass;
            
            [Tooltip("The jeep 01 compass")]
            // Jeep01Compass _jeep01Compass
            [SerializeField] private Jeep01Compass _jeep01Compass;  

        //public static Jeep01Entry _jeep01Entry;
        
        // private void Start
        private void Start() 
        {
            //_jeep01Entry = this;
            
            // _jeep01Script is GetComponent Jeep01Controller
            _jeep01Script = GetComponent<Jeep01Controller>();

            // _jeep01Script enabled is false
            _jeep01Script.enabled = false;
            
            // _jeep01Camera is GetComponentInChildren Camera
            _jeep01Camera = GetComponentInChildren<Camera>();
            
            // _jeep01Camera enabled is false
            _jeep01Camera.enabled = false;

            // _jeep01CameraAudioListener is GetComponentInChildren AudioListener
            _jeep01CameraAudioListener = GetComponentInChildren<AudioListener>();
            
            // _jeep01CameraAudioListener enabled is false
            _jeep01CameraAudioListener.enabled = false; 

            // _rigidbody
            _rigidbody = GetComponent<Rigidbody>();

            // GameObject _interfaceTextObject is FindInActiveObjectByName Jeep01_EntryKey
            GameObject _interfaceTextObject = FindInActiveObjectByName("Jeep01_EntryKey");

            // _interfaceTextObject SetActive is false
            _interfaceTextObject.SetActive(false);

            // Compass

            // _playerCompass enabled is true
            _playerCompass.enabled = true;

            // _playerCompass compassEnabled is true
            _playerCompass.compassEnabled = true;

            // Debug Log
            //Debug.Log("The Player compass is enabled");

            // _jeep01Compass enabled is false
            _jeep01Compass.enabled = false;

            // _jeep01Compass compassEnabled is false
            _jeep01Compass.compassEnabled = false;

            // Debug Log
            //Debug.Log("The Jeep01 compass is disabled");

    	} // close private void Start

        // Update is called once per frame

        // private void Update
        private void Update()
        {
            // if _inJeep01 and Input GetKey KeyCode _exitKey
            if (_inJeep01 && Input.GetKey(_exitKey))
            {
                // _player SetActive is true
                _player.SetActive(true);

                // _player transform parent is null
                _player.transform.parent = null;

                // _jeep01Script enabled is false
                _jeep01Script.enabled = false;
                
                // _jeep01Camera enabled is false
                _jeep01Camera.enabled = false;

                // _jeep01CameraAudioListener enabled is false
                _jeep01CameraAudioListener.enabled = false;                 

                // _inJeep01 is false
                _inJeep01 = false;

                // Compass

                // _playerCompass enabled is true
                _playerCompass.enabled = true;

                // _playerCompass compassEnabled is true 
                _playerCompass.compassEnabled = true;

                // Debug Log
                //Debug.Log("The Player compass is enabled");

                // _jeep01Compass enabled is false
                _jeep01Compass.enabled = false;

                // _jeep01Compass compassEnabled is false
                _jeep01Compass.compassEnabled = false;

                // Debug Log
                //Debug.Log("The Jeep01 compass is disabled");         

            } // close if _inJeep01 and Input GetKey KeyCode _exitKey

        } // close private void Update         

        // private void OnTriggerStay Collider other
        private void OnTriggerStay(Collider other)
        {
        	// if not _inJeep01 and gameObject tag is Player
            if (!_inJeep01 && other.gameObject.tag == "Player")
            {
            	// _interfaceTextObject SetActive is true
                _interfaceTextObject.SetActive(true);

            } // close if not _inJeep01 and gameObject tag is Player
            
            // if not _inJeep01 and gameObject tag is Player and Input GetKey KeyCode _enterKey
            if (!_inJeep01 && other.gameObject.tag == "Player" && Input.GetKey(_enterKey))
            {
                // _interfaceTextObject SetActive is false
                _interfaceTextObject.SetActive(false);

                // _player SetActive is false 
                _player.SetActive(false);

                // _player transform parent is _jeep01 transform
                _player.transform.parent = _jeep01.transform;

                // _jeep01Script enabled is true
                _jeep01Script.enabled = true;
                
                // _jeep01Camera enabled is true
                _jeep01Camera.enabled = true;

                // _jeep01CameraAudioListener enabled is true
                _jeep01CameraAudioListener.enabled = true; 

                // _inJeep01 is true
                _inJeep01 = true;

                // Compass

                // _playerCompass enabled is false
                _playerCompass.enabled = false;

                // _playerCompass compassEnabled is false
                _playerCompass.compassEnabled = false;

                // Debug Log
                //Debug.Log("The Player compass is disabled"); 

                // _jeep01Compass enabled is true
                _jeep01Compass.enabled = true;

                // _jeep01Compass compassEnabled is true
                _jeep01Compass.compassEnabled = true;

                // Debug Log
                //Debug.Log("The Jeep01 compass is enabled");                

            } // close if not _inJeep01 and gameObject tag is Player and Input GetKey KeyCode _enterKey

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
        
    } // close public class Jeep01Entry  

} // close namespace VehiclesControl
