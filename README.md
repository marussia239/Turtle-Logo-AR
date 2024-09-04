# Unity Augmented Reality Project
### Made by Marina Grigoreva

**Libraries used**: ARFoundation (for the floor detection), Google ARCore (for Android development)

**Assets used**: [ToonyTurtle](https://assetstore.unity.com/packages/3d/characters/animals/toonyturtle-95526) (for the turtle figure prefab), 
[Simple Button Set 02](https://assetstore.unity.com/packages/2d/gui/icons/simple-button-set-02-184903) (for the buttons design)

**The project description**: using ARCore and AR Foundation, the app detects surfaces in the real world and allows the turtle to be placed on these detected planes. 
A UI toggle is provided to show or hide the AR plane and point cloud visualization. 
The user can tap on the detected plane to place the turtle model. When placed on a surface, the turtle can be moved through UI buttons. 
The buttons allow the turtle to move forward, rotate left, and rotate right, while it draws a line behind it to visualize its movement path. 
Another tap on a surface repositions the turtle and removes the line drawn before.

**Scripts**:
- PlaceContent.cs: 
  - Detects user taps on AR-detected planes (detected with an ARRaycastManager).
  - Positions the turtle at the tapped location.
  - Resets the turtle's drawing line when repositioned.
  - Prevents placement when interacting with UI elements.

- ToggleAR.cs:
  - Allows users to toggle the visibility of AR-detected horizontal planes and point clouds.
    
- TurtleController.cs:
  - Moves the turtle forward in response to UI forward button presses.
  - Rotates the turtle 90 degrees left or right based on user input.
  - Draws a line representing the turtle's path using a LineRenderer component.
  - Implements the logic for line erasure after turtle repositioning.
