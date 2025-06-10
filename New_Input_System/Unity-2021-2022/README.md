# Unity-BasicVehiclesControl_ForSyntyExplorer
 
Description:
------------


Create basic Vehicle(s) Controller(s) by Example(s) for your Unity projects using vehicle models from Synty Polygon Explorers Asset. 


Note: As this uses the vehicles from such and due to licensing of such asset the said vehicles cannot be included in this repository obviously, so, as such the provided scripts thus require having / purchasing the Synty Polygon Explorers Asset:  https://assetstore.unity.com/packages/3d/characters/humanoids/humans/polygon-explorer-low-poly-3d-art-by-synty-128996


Synty Explorer Vehicles (total: 4)
----------------------------------


* Jeep (total: 4)


![Preview](https://raw.githubusercontent.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/refs/heads/main/Previews/Asset/SyntyPolygonExplorers.png)


Release Intentions Note:
------------------------


The intention of these releases due to only being scripts for usage with models one must already own or opt to purchase and as such was known that one could not release such models with the package here the intent was to provide basic vehicle functionality as a start point as fully functional in terms of an opinion of basic but leave out optional continuances in the hopes that these will be used as starting points for folks to continue on with and improve upon. Now, some of the things intentionally left out, umm, while all simply easy to add, lets see: say, audio sources, audio clips, particle systems for exhausts, etc, etc... as leaving these initializations of such aforementioned suggestions out was indeed intentional in the hopes that the end user will continue to add those as desired and continue to improve upon the provided start points. Also note that while yes, these are great hints, tips and or suggestions, if you were thinking say of what to add next, please note though, that is not to say if and or when I may find myself to have free time say I just may or may not opt to add such or some of such at later dates if desire or free time allows. Another thing to note is that I intentionally left out adding a fuel system to these at this time because again the intent was to provide basic functional vehicle controllers as starting points.


NOTE: This project was / is being developed while / for using Unity 2021+ & 2022+


ON THE NO DOCUMENTATIONS PRESENT NOTE: Currently as this is still being worked on / in dev, there are no documentations provided as of yet though upon completion of adding others vehicles ie: 1-4 jeeps for each variant and then getting around to the tedious task of writing various docs for each such will then be added, so for now if you are familiar with other similar repos of mine then you might already know how to set these up, if not and noting that there is no documentations currently provided nor created, one without such previous knowledges should probably not attempt to setup the currently in progress repository files...


New_Input_System Variant Directory NOTE:

Provided variants: (Unity 2021+ / 2022+ variant)


NOTE: This currently uses the "New Input System", so as such depending on what version of Unity you may be using it may be necessary to make sure such or both is enabled in project settings.


New_Input_System Directory NOTE: If there is any confusion with "Input Actions", just note the following "Input Action Assets" found below:

For player:

Input Actions:

Player Controls: PlayerControls (Input Action Asset)

For vehicles:

Input Actions:

Car Controls: CarControls (Input Action Asset)


Vehicles Currently "Completed" & Included:
------------------------------------------


* Jeep (x4) (controller, speedometer, entry, compass) - [Functional]


Other Currently "Completed" & Included:
---------------------------------------


* Player & Vehicles Compass - [Functional]


Other Current "In Progress" & Not Yet Included:
-----------------------------------------------


* Related Documentations (in progress)


Player Controls: 
----------------


* Player Forward:   W [Keyboard] / Left Stick [Gamepad]
* Player Reverse:   S [Keyboard] / Left Stick [Gamepad]
* Player Left:      A [Keyboard] / Left Stick [Gamepad]
* Player Right:     D [Keyboard] / Left Stick [Gamepad]
* Player Jump:      Space [Keyboard] / Button South [Gamepad] 
* Player Sprint:    Shift [Keyboard] / Left Shoulder [Gamepad]
* Player Look:      Delta [Mouse] / Right Stick [Gamepad]


Vehicle Controls: 
-----------------

  Note: The following below are related to both variations either standalone vehicle controller usage and entry script usage.


Jeeps:

* Vehicle Forward:   W [Keyboard] / Left Stick [Gamepad]
* Vehicle Reverse:   S [Keyboard] / Left Stick [Gamepad]
* Vehicle Left:      A [Keyboard] / Left Stick [Gamepad]
* Vehicle Right:     D [Keyboard] / Left Stick [Gamepad]
* Vehicle Brake:     Space [Keyboard] / Right Trigger [Gamepad]


Entry Script: 


  Note: The following found below are specific only when entry script is applied.


* Enter Vehicle:      E [Keyboard] / Button North [Gamepad] 
* Exit Vehicle:       F [Keyboard] / Button South [Gamepad] 


Manual Setup Instruction:
-------------------------


Simply follow the linkages found below for documentation information / instruction....


PlayerControl:
--------------

* Example player control documentation: https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/PlayerControl/Documentation/PlayerControl-Documentation.txt


Vehicles Control:
-----------------


* All vehicles with entry in scene setup: coming soon...



Jeep: (total: 4)
----------------

CONTROLLER ONLY USAGE:

Jeep 01 "Controller Only" usage:

* Jeep 01 controller only in scene setup:  https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/VehiclesControl/Jeep/Jeep01/Documentation/Jeep01Controller-Only-Documentation.txt

* Jeep 01 controller only in scene speedometer setup:  https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/VehiclesControl/Jeep/Jeep01/Documentation/Jeep01Controller-Only-Speedometer-Documentation.txt

* Jeep 01 controller only in scene vehicle compass setup: https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/NavigationControl/Compass/Scripts/Jeep/Documentation/Jeep01-Controller-Only-Compass-Documentation.txt


Jeep 02 "Controller Only" usage:

* Jeep 02 controller only in scene setup:  https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/VehiclesControl/Jeep/Jeep02/Documentation/Jeep02Controller-Only-Documentation.txt

* Jeep 02 controller only in scene speedometer setup:  https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/VehiclesControl/Jeep/Jeep02/Documentation/Jeep02Controller-Only-Speedometer-Documentation.txt

* Jeep 02 controller only in scene vehicle compass setup: https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/NavigationControl/Compass/Scripts/Jeep/Documentation/Jeep02-Controller-Only-Compass-Documentation.txt


Jeep 03 "Controller Only" usage:

* Jeep 03 controller only in scene setup:  https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/VehiclesControl/Jeep/Jeep03/Documentation/Jeep03Controller-Only-Documentation.txt

* Jeep 03 controller only in scene speedometer setup:  https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/VehiclesControl/Jeep/Jeep03/Documentation/Jeep03Controller-Only-Speedometer-Documentation.txt

* Jeep 03 controller only in scene vehicle compass setup: https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/NavigationControl/Compass/Scripts/Jeep/Documentation/Jeep03-Controller-Only-Compass-Documentation.txt


Jeep 04 "Controller Only" usage:

* Jeep 04 controller only in scene setup:  https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/VehiclesControl/Jeep/Jeep04/Documentation/Jeep04Controller-Only-Documentation.txt

* Jeep 04 controller only in scene speedometer setup:  https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/VehiclesControl/Jeep/Jeep04/Documentation/Jeep04Controller-Only-Speedometer-Documentation.txt

* Jeep 04 controller only in scene vehicle compass setup: https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/NavigationControl/Compass/Scripts/Jeep/Documentation/Jeep04-Controller-Only-Compass-Documentation.txt


INDIVIDUAL VEHICLES WITH ENTRY USAGE:

Jeep 01 "Controller With Player Entry" usage:

* Jeep 01 controller with entry in scene setup: https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/VehiclesControl/Jeep/Jeep01/Documentation/Jeep01Controller-wEntry-Documentation.txt

* Jeep 01 controller with entry in scene speedometer setup: https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/VehiclesControl/Jeep/Jeep01/Documentation/Jeep01Controller-Speedometer-Documentation.txt

* Jeep 01 controller with entry in scene player and vehicle compass setup: https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/NavigationControl/Compass/Scripts/Jeep/Documentation/Jeep01-Individual-Compass-Documentation.txt


Jeep 02 "Controller With Player Entry" usage:

* Jeep 02 controller with entry in scene setup: https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/VehiclesControl/Jeep/Jeep02/Documentation/Jeep02Controller-wEntry-Documentation.txt

* Jeep 02 controller with entry in scene speedometer setup: https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/VehiclesControl/Jeep/Jeep02/Documentation/Jeep02Controller-Speedometer-Documentation.txt

* Jeep 02 controller with entry in scene player and vehicle compass setup: https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/NavigationControl/Compass/Scripts/Jeep/Documentation/Jeep02-Individual-Compass-Documentation.txt


Jeep 03 "Controller With Player Entry" usage:

* Jeep 03 controller with entry in scene setup: https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/VehiclesControl/Jeep/Jeep03/Documentation/Jeep03Controller-wEntry-Documentation.txt

* Jeep 03 controller with entry in scene speedometer setup: https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/VehiclesControl/Jeep/Jeep03/Documentation/Jeep03Controller-Speedometer-Documentation.txt

* Jeep 03 controller with entry in scene player and vehicle compass setup: https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/NavigationControl/Compass/Scripts/Jeep/Documentation/Jeep03-Individual-Compass-Documentation.txt


Jeep 04 "Controller With Player Entry" usage:

* Jeep 04 controller with entry in scene setup: https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/VehiclesControl/Jeep/Jeep04/Documentation/Jeep04Controller-wEntry-Documentation.txt

* Jeep 04 controller with entry in scene speedometer setup: https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/VehiclesControl/Jeep/Jeep04/Documentation/Jeep04Controller-Speedometer-Documentation.txt

* Jeep 04 controller with entry in scene player and vehicle compass setup: https://github.com/deathwatchgaming/Unity-BasicVehiclesControl_ForSyntyExplorer/blob/main/New_Input_System/Unity-2021-2022/Assets/NavigationControl/Compass/Scripts/Jeep/Documentation/Jeep04-Individual-Compass-Documentation.txt
