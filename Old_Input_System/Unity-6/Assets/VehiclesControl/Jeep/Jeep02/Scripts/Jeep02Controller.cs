/*
 * File: Jeep 02 Controller
 * Name: Jeep02Controller.cs
 * Author: DeathwatchGaming
 * License: MIT
 * Unity Version(s): Unity 6+ 
 */

// Wheel radius 0.4938253
// Wheel Collider Position Y: 0.6139312 (0.4639312+0.15)

// using
using System;
using UnityEngine;

// namespace VehiclesControl
namespace VehiclesControl
{
	// public enum Jeep02SpeedType
	public enum Jeep02SpeedType
	{
		mph,
		kmh	

	} // close public enum Jeep02SpeedType

	// RequireComponent typeof MeshCollider
	[RequireComponent(typeof(MeshCollider))]

	// RequireComponent typeof Rigidbody
	[RequireComponent(typeof(Rigidbody))]

	// public class Jeep02Controller
	public class Jeep02Controller : MonoBehaviour
	{
		// Input Customizations
		[Header("Input Customizations")]

			[Tooltip("The vertical movement input string")]
			// string _verticalMoveInput
			[SerializeField] private string _verticalMoveInput = "Vertical";	

			[Tooltip("The horizontal movement input string")]
			// string _horizontalMoveInput
			[SerializeField] private string _horizontalMoveInput = "Horizontal";

			[Tooltip("The brake input keycode key")]
			// KeyCode _brakeKey
			[SerializeField] private KeyCode _brakeKey = KeyCode.Space;

		// Require Components
		[Header("Require Components")]

			[Tooltip("The rigidbody component")]
			// Rigidbody _rigidbody
			[SerializeField] private Rigidbody _rigidbody;

			[Tooltip("The mesh collider component")]
			// MeshCollider _meshCollider
			[SerializeField] private MeshCollider _meshCollider;	

		// Wheel Transforms
		[Header("Wheel Transforms")]

			[Tooltip("The front left wheel transform")]
			// Transform _frontLeftTransform
			[SerializeField] private Transform _frontLeftTransform;

			[Tooltip("The front right wheel transform")]
			// Transform _frontRightTransform
			[SerializeField] private Transform _frontRightTransform;

			[Tooltip("The rear left wheel transform")]
			// Transform _rearLeftTransform
			[SerializeField] private Transform _rearLeftTransform;

			[Tooltip("The rear right wheel transform")]
			// Transform _rearRightTransform
			[SerializeField] private Transform _rearRightTransform;

		// Wheel Colliders
		[Header("Wheel Colliders")]

			[Tooltip("The front left wheel collider")]
			// WheelCollider _frontLeft
			[SerializeField] private WheelCollider _frontLeft;

			[Tooltip("The front right wheel collider")]
			// WheelCollider _frontRight
			[SerializeField] private WheelCollider _frontRight;

			[Tooltip("The rear left wheel collider")]
			// WheelCollider _rearLeft
			[SerializeField] private WheelCollider _rearLeft;

			[Tooltip("The rear right wheel collider")]
			// WheelCollider _rearRight
			[SerializeField] private WheelCollider _rearRight;

		// Amounts
		[Header("Amounts")]

			[Tooltip("The acceleration amount")]
			// _acceleration  is 500
			[SerializeField] private float _acceleration = 500f;

			[Tooltip("The braking force amount")]
			// _brakingForce is 300
			[SerializeField] private float _brakingForce = 300f; 

			[Tooltip("The maximum turn angle amount")]
			// _maxTurnAngle is 15
			[SerializeField] private float _maxTurnAngle = 15f;

			[Tooltip("The center of gravity amount")]	    
			// _centerOfGravityOffset is -1
			[SerializeField] private float _centerOfGravityOffset = -1f;

			[Tooltip("The rigidbody component mass")]
			// float _rigidbodyMass is 2000
			[SerializeField] private float _rigidbodyMass = 2000f;

		// Speed
		[Header("Speed")]

			[Tooltip("The speed measurement unit")]
			// Jeep02SpeedType _speedType	
			[SerializeField] private Jeep02SpeedType _speedType;			
	    
			[Tooltip("The maximum speed amount")]
			// float _maxSpeed
			[SerializeField] private float _maxSpeed = 180;		

		// _currentAcceleration is 0
		private float _currentAcceleration = 0f;

		// _currentBrakeForce is 0 
		private float _currentBrakeForce = 0f;
		    
		// _currentTurnAngle is 0 
		private float _currentTurnAngle = 0f;

		// private void Awake
		private void Awake()
		{
			// _rigidbody is GetComponent Rigidbody
			_rigidbody = GetComponent<Rigidbody>();
	        
			// _rigidbody mass is _rigidbodyMass
			_rigidbody.mass = _rigidbodyMass;

			// Adjust the center of mass vertically to help prevent the truck from rolling
			// _rigidbody centerOfMass
			_rigidbody.centerOfMass += Vector3.up * _centerOfGravityOffset;

			// _meshCollider is GetComponent MeshCollider
			_meshCollider = GetComponent<MeshCollider>();

			// _meshCollider convex is true
			_meshCollider.convex = true;

			// Cursor lockState is CursorLockMode Locked
			Cursor.lockState = CursorLockMode.Locked;

			// Cursor visible is false
			Cursor.visible = false;

		} // close private void Awake

		// private void Update
		private void Update()
		{
			// Handle Speed
			HandleSpeed();

		} // close private void Update
		
		// private void FixedUpdate
		private void FixedUpdate()
		{
			// Handle Acceleration
			HandleAcceleration();

			// Handle Braking
			HandleBraking();

			// Handle Steering
			HandleSteering();

			// Update Wheel Meshes
			UpdateWheelMeshes();

		} // close private void FixedUpdate

		// private void HandleSpeed
		private void HandleSpeed()
		{
			// Take care of speed unit type and max speed

			// float _speed
			float _speed = _rigidbody.linearVelocity.magnitude;

			// _speedType equals Jeep02SpeedType.mph
			if (_speedType == Jeep02SpeedType.mph)
			{
				// 2.23694 is the constant to convert a value from m/s to mph

				// _speed
				_speed *= 2.23694f;

				// if _speed > _maxSpeed
				if (_speed > _maxSpeed)
				{
					// _rigidbody.velocity
					_rigidbody.linearVelocity = (_maxSpeed/2.23694f) * _rigidbody.linearVelocity.normalized;

				} // close if _speed > _maxSpeed
                        
			} // close if _speedType equals Jeep02SpeedType.mph

			// else if _speedType equals Jeep02SpeedType.kmh
			else if (_speedType == Jeep02SpeedType.kmh)
			{
				// 3.6 is the constant to convert a value from m/s to km/h
				
				// _speed
				_speed *= 3.6f;

				// if _speed > _maxSpeed
				if (_speed > _maxSpeed)
				{
					// _rigidbody.velocity
					_rigidbody.linearVelocity = (_maxSpeed/3.6f) * _rigidbody.linearVelocity.normalized;

				} // close if _speed > _maxSpeed
                       
			} // close else if _speedType equals Jeep02SpeedType.kmh

		} // close private void HandleSpeed
		
		// private void HandleAcceleration
		private void HandleAcceleration()
		{
			// Get the forward and reverse acceleration from vertical axis (W and S keys)
	        
			// _currentAcceleration is _acceleration times Input GetAxis Vertical
			_currentAcceleration = _acceleration * Input.GetAxis(_verticalMoveInput);

			// Apply acceleration to all of the wheels
	        
			// frontLeft motorTorque is _currentAcceleration
			_frontLeft.motorTorque = _currentAcceleration;

			// _frontRight motorTorque is _currentAcceleration
			_frontRight.motorTorque = _currentAcceleration;

			// _rearLeft motorTorque is _currentAcceleration
			_rearLeft.motorTorque = _currentAcceleration;

			// _rearRight motorTorque is _currentAcceleration
			_rearRight.motorTorque = _currentAcceleration;

		} // close private void HandleAcceleration

		// private void HandleBraking
		private void HandleBraking()
		{
			// If we are pressing the _brakeKey give _currentBrakingForce a value

			// if Input GetKey KeyCode _brakeKey
			if (Input.GetKey(_brakeKey))
			{
				// _currentBrakeForce is _brakingForce
				_currentBrakeForce = _brakingForce;

			} // close if Input GetKey KeyCode _brakeKey
	        
			// else 
			else
			{
				// _currentBrakeForce is 0
				_currentBrakeForce = 0f;

			} // close else

			// Apply braking force to all of the wheels

			// _frontLeft brakeTorque is _currentBrakeForce
			_frontLeft.brakeTorque = _currentBrakeForce;

			// _frontRight brakeTorque is _currentBrakeForce
			_frontRight.brakeTorque = _currentBrakeForce;

			// _rearLeft brakeTorque is _currentBrakeForce
			_rearLeft.brakeTorque = _currentBrakeForce;

			// _rearRight brakeTorque is _currentBrakeForce
			_rearRight.brakeTorque = _currentBrakeForce;

		} // close private void HandleBraking

		// private void HandleSteering
		private void HandleSteering()
		{
			// Take care of the front wheels steering

			// _currentTurnAngle is _maxTurnAngle times Input GetAxis Horizontal
			_currentTurnAngle = _maxTurnAngle * Input.GetAxis(_horizontalMoveInput);

			// _frontLeft steerAngle is _currentTurnAngle
			_frontLeft.steerAngle = _currentTurnAngle;

			// _frontRight steerAngle is _currentTurnAngle
			_frontRight.steerAngle = _currentTurnAngle;

		} // close private void HandleSteering

		// private void UpdateWheelMeshes
		private void UpdateWheelMeshes()
		{
 			// Update the wheel meshes

			// UpdateLeftWheel _frontLeft _frontLeftTransform
			UpdateLeftWheel(_frontLeft, _frontLeftTransform);

			// UpdateRightWheel _frontRight _frontRightTransform
			UpdateRightWheel(_frontRight, _frontRightTransform);

			// UpdateLeftWheel _rearLeft _rearLeftTransform
			UpdateLeftWheel(_rearLeft, _rearLeftTransform);  
	        
			// UpdateRightWheel _rearRight _rearRightTransform
			UpdateRightWheel(_rearRight, _rearRightTransform);

		} // close private void UpdateWheelMeshes

		// private void UpdateLeftWheel WheelCollider _leftCollider Transform _leftTransform
		private void UpdateLeftWheel(WheelCollider _leftCollider, Transform _leftTransform)
		{
			// Get the left wheels collider states

			// Vector3 _leftPosition
			Vector3 _leftPosition;

			// Quaternion _leftRotation
			Quaternion _leftRotation;

			// _leftCollider GetWorldPose out _leftPosition out _leftRotation
			_leftCollider.GetWorldPose(out _leftPosition, out _leftRotation);

			// Set the left wheels transform states

			// _leftTransform position is _leftPosition
			_leftTransform.position = _leftPosition;

			// _leftTransform rotation is _leftRotation
			_leftTransform.rotation = _leftRotation;

		} // close private void UpdateLeftWheel WheelCollider _leftCollider Transform _leftTransform   
	    
		// private void UpdateRightWheel WheelCollider _rightCollider Transform _rightTransform
		private void UpdateRightWheel(WheelCollider _rightCollider, Transform _rightTransform)
		{
			// Get the right wheels collider states

			// Vector3 _rightPosition
			Vector3 _rightPosition;

			// Quaternion _rightRotation
			Quaternion _rightRotation;

			// _rightCollider GetWorldPose out _rightPosition out _rightRotation
			_rightCollider.GetWorldPose(out _rightPosition, out _rightRotation);

			// Set the right wheels transform states

			// _rightTransform position is _rightPosition
			_rightTransform.position = _rightPosition;

			// _rightTransform rotation is _rightRotation
			_rightTransform.rotation = _rightRotation;

		} // close private void UpdateRightWheel WheelCollider _rightCollider Transform _rightTransform

	} // close public class Jeep02Controller

} // close namespace VehiclesControl
