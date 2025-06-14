/*
 * File: Jeep 02 Speedometer (New Input System)
 * Name: Jeep02Speedometer.cs
 * Author: DeathwatchGaming
 * License: MIT
 * Unity Version(s): Unity 2021+ - 2022+
 */

// using
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

// namespace VehiclesControl
namespace VehiclesControl
{
    // public enum Jeep02SpeedUnit
	public enum Jeep02SpeedUnit
	{
		mph,
		kmh	

	} // close public enum Jeep02SpeedUnit

	// public class Jeep02Speedometer 
	public class Jeep02Speedometer : MonoBehaviour
	{
		// Speedometer
		[Header("Speedometer")]

			[Tooltip("The speedometer needle")]
			// GameObject _needle
			[SerializeField] private GameObject _needle;

			[Tooltip("The start position")]
			// float _startPosition
			[SerializeField] private float _startPosition = 220f;

			[Tooltip("The end position")]
			// float _endPosition
			[SerializeField] private float _endPosition = -41f;

			[Tooltip("The desired position")]
			// float _desiredPosition
			[SerializeField] private float _desiredPosition;

			[Tooltip("The vehicle speed")]
			// float _vehicleSpeed
			[SerializeField] private float _vehicleSpeed = 0f;

 		// Speed Text       
		[Header("Speed Text")]

			[Tooltip("The decimal places")]
			// int _decimalPlaces 
			[SerializeField] private int _decimalPlaces = 0;

			[Tooltip("The previous text string")]
			//  string _previousText		
			[SerializeField] private string _previousText;

			[Tooltip("The speed measurement unit")]
			// Jeep02SpeedUnit _speedUnit	
			[SerializeField] private Jeep02SpeedUnit _speedUnit;

			[Tooltip("The interface speed amount text")]
			// TMP_Text speedText
			[SerializeField] private TMP_Text _speedText;

		// Game Objects
		[Header("Game Objects")]

			[Tooltip("The interface parent game object")]
			// GameObject _interfaceParentObject
			[SerializeField] private GameObject _interfaceParentObject;
			
			[Tooltip("The interface image01 speedometer guage game object")]
			// GameObject _interfaceIMG01Object
			[SerializeField] private GameObject _interfaceIMG01Object;

			[Tooltip("The interface image02 speedometer needle game object")]
			// GameObject _interfaceIMG02Object
			[SerializeField] private GameObject _interfaceIMG02Object;

			[Tooltip("The interface text speed text game object")]
			// GameObject _interfaceTextObject
			[SerializeField] private GameObject _interfaceTextObject;

		// Active State
		[Header("Active State")]

			[Tooltip("The active state bool")]
			// bool _inJeep02 is false
			[SerializeField] private bool _inJeep02 = false;

		// Input  Actions
		[Header("Input Actions")] 

			[Tooltip("The input action asset")]
			// InputActionAsset _carControls;
			[SerializeField] private InputActionAsset _carControls;	

		// InputAction _carEnterAction
		private InputAction _carEnterAction;

		// InputAction _carExitAction
		private InputAction _carExitAction;

		// bool _enterButton
		private bool _enterButton;

		// bool _exitButton
		private bool _exitButton;

		// float _currentSpeed
		float _currentSpeed;

		// Jeep02Controller _jeep02Script
		private Jeep02Controller _jeep02Script;

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
			// _jeep02Script is GetComponent Jeep02Controller
			_jeep02Script = GetComponent<Jeep02Controller>();

			// _rigidbody
			_rigidbody = GetComponent<Rigidbody>();

			// GameObject _interfaceIMG01Object is FindInActiveObjectByName Jeep02_SpeedoGuage
			GameObject _interfaceIMG01Object = FindInActiveObjectByName("Jeep02_SpeedoGuage");

			// _interfaceIMG01Object SetActive is false
			_interfaceIMG01Object.SetActive(false);

			// GameObject _interfaceIMG02Object is FindInActiveObjectByName Jeep02_SpeedoNeedle
			GameObject _interfaceIMG02Object = FindInActiveObjectByName("Jeep02_SpeedoNeedle");

			// _interfaceIMG02Object SetActive is false
			_interfaceIMG02Object.SetActive(false);	

			// GameObject _interfaceTextObject is FindInActiveObjectByName Jeep02_SpeedText
			GameObject _interfaceTextObject = FindInActiveObjectByName("Jeep02_SpeedText");

			// _interfaceTextObject SetActive is false
			_interfaceTextObject.SetActive(false);			

			// GameObject _interfaceParentObject is FindInActiveObjectByName Jeep02Speedometer
			GameObject _interfaceParentObject = FindInActiveObjectByName("Jeep02Speedometer");

			// _interfaceParentObject SetActive is false
			_interfaceParentObject.SetActive(false);

		} // close private void Start

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
						
			// if _speedUnit equals Jeep02SpeedUnit.mph
			if (_speedUnit == Jeep02SpeedUnit.mph)
			{
				// 2.23694 is the constant to convert a value from m/s to mph

				// _currentSpeed
				_currentSpeed = (float)Math.Round(_rigidbody.velocity.magnitude * 2.23694f, _decimalPlaces);

				// _speedText.text
				_speedText.text = _previousText + _currentSpeed.ToString() + " mph";

			} // close if _speedUnit equals Jeep02SpeedUnit.mph

			// else 
			else 
			{
				// 3.6 is the constant to convert a value from m/s to km/h

				// _currentSpeed
				_currentSpeed = (float)Math.Round(_rigidbody.velocity.magnitude * 3.6f, _decimalPlaces);

				// _speedText.text
				_speedText.text = _previousText + _currentSpeed.ToString() + " km/h";

			} // close else

			// if _inJeep02 and Input GetKey KeyCode _exitKey
			if (_inJeep02 && _exitButton == true)
			{
				// _inJeep02 is false
				_inJeep02 = false;

			} // close if _inJeep02 and Input GetKey KeyCode _exitKey

		} // close private void Update

		// private void FixedUpdate
		private void FixedUpdate()
		{
			// _vehicleSpeed
			_vehicleSpeed = _currentSpeed;

			// UpdateSpeedoNeedle
			UpdateSpeedoNeedle();

		} // close private void FixedUpdate

		// private void UpdateSpeedoNeedle
		private void UpdateSpeedoNeedle()
		{
			// _desiredPosition
			_desiredPosition = _startPosition - _endPosition;

			// float _temp 
			float _temp = _vehicleSpeed / 180;

			// _needle.transform.eulerAngles
			_needle.transform.eulerAngles = new Vector3(0, 0, (_startPosition -_temp * _desiredPosition));

		} // close private void UpdateSpeedoNeedle

		// private void OnTriggerStay Collider other
		private void OnTriggerStay(Collider other)
		{
			// if not _inJeep02 and gameObject tag is Player
			if (!_inJeep02 && other.gameObject.tag == "Player")
			{
				// _interfaceIMG01Object SetActive is false
				_interfaceIMG01Object.SetActive(false);

				// _interfaceIMG02Object SetActive is false
				_interfaceIMG02Object.SetActive(false);

				// _interfaceTextObject SetActive is false
				_interfaceTextObject.SetActive(false);	

				// _interfaceParentObject SetActive is false
				_interfaceParentObject.SetActive(false);

			} // close if not _inJeep02 and gameObject tag is Player

			// if not _inJeep02 and gameObject tag is Player and Input GetKey KeyCode _enterKey
			if (!_inJeep02 && other.gameObject.tag == "Player" && _enterButton == true)
			{
				// _interfaceIMG01Object SetActive is true
				_interfaceIMG01Object.SetActive(true);

				// _interfaceIMG02Object SetActive is true
				_interfaceIMG02Object.SetActive(true);

				// _interfaceTextObject SetActive is true
				_interfaceTextObject.SetActive(true);

				// _interfaceParentObject SetActive is true
				_interfaceParentObject.SetActive(true);

				// _inJeep02 is true
				_inJeep02 = true;					

			} // close if not _inJeep02 and gameObject tag is Player and Input GetKey KeyCode _enterKey

		} // close private void OnTriggerStay Collider other

		// private void OnTriggerExit Collider other
		private void OnTriggerExit(Collider other)
		{
			// if gameObject tag is Player
			if (other.gameObject.tag == "Player")
			{
				// _interfaceIMG01Object SetActive is false
				_interfaceIMG01Object.SetActive(false);

				// _interfaceIMG02Object SetActive is false
				_interfaceIMG02Object.SetActive(false);

				// _interfaceTextObject SetActive is false
				_interfaceTextObject.SetActive(false);			

				// _interfaceParentObject SetActive is false
				_interfaceParentObject.SetActive(false);

			} // close if gameObject tag is Player

		} // close private void OnTriggerExit Collider other

	} // close public class Jeep02Speedometer

} // close namespace VehiclesControl
