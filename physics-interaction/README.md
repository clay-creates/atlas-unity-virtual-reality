# VR Physics-Based Interaction Project

## Overview

This project demonstrates a set of advanced physics-based interactions in Virtual Reality (VR), designed to enhance immersion and realism. Inspired by VR games like Boneworks and BoneLab, this project features realistic multi-point object grabbing, throwing mechanics, distance selection and force grabbing, and various other physics interactions.

## Features

- **Multi-Point Grabbing**: Objects, such as a sword, can be grabbed at multiple points (e.g., hilt and blade) to enable both one-handed and two-handed control.
- **Realistic Object Throwing**: Objects like bowling balls can be picked up and thrown with realistic weight and velocity calculations.
- **Telekinetic Force Grab**: Allows the player to grab and pull objects from a distance using raycasting and force application.
- **Lever and Domino Interactions**: Includes physics-based lever mechanics and a dynamic domino effect showcasing collision dynamics.

## Planning and Design

### Initial Goals

- Implement realistic **multi-point grabbing** for a sword, allowing players to switch seamlessly between one-handed and two-handed grips.
- Design a **throwing mechanic** that accurately reflects the weight, size, and velocity of the object being thrown.
- Create a **distance-based grabbing system** to allow players to interact with objects from afar, simulating telekinetic abilities.
- Experiment with other **physics-based interactions**, such as levers, balancing objects, and domino chain reactions, ensuring realistic behavior and physics simulation.

### Technical Decisions

- **Rigidbody Components**: All interactive objects in the scene (sword, balls, levers) utilize Unity's `Rigidbody` component to ensure they behave according to the laws of physics, including gravity, mass, and collision responses.
- **XR Interaction Toolkit**: Unity's XR Interaction Toolkit was used to manage player interactions, such as grabbing and releasing objects, tracking controller velocity, and detecting distance-based interactions.
- **Physics Joints**: Various physics joints (e.g., FixedJoints, HingeJoints) were applied to control the interaction of objects like the sword and lever, ensuring smooth and intuitive object manipulation.
  
## Challenges

1. **Handling Smooth Transitions Between One-Handed and Two-Handed Grabbing**:
   Initially, the sword's physics behaved unnaturally when switching between one-handed and two-handed grips. The center of mass and constraints needed to be dynamically adjusted based on the number of hands holding the object.

2. **Realistic Throwing Dynamics**:
   Throwing objects like the bowling ball felt inconsistent due to the difficulty in accurately calculating the release velocity of the VR controller. Fine-tuning the force applied to the object's Rigidbody and synchronizing with the controller's velocity were necessary to make throwing feel realistic.

3. **Telekinetic Grabbing**:
   Implementing a smooth telekinetic grab required precise raycasting and force calculation. Initially, the objects snapped into the player's hand too quickly or moved too slowly. We had to balance the force applied and use coroutines to smoothly pull objects toward the player.

## Solutions

1. **Two-Handed Grip Physics**:
   The solution was to adjust the **center of mass** when two hands were holding the sword. Constraints were added to limit unnatural rotations, creating a more realistic and balanced sword-handling experience.

2. **Velocity-Based Throwing**:
   By capturing the velocity of the VR controller at the moment of release and applying that velocity to the object’s Rigidbody, throwing became more intuitive. The mass of the object was factored into the calculation to ensure heavier objects were more difficult to throw.

3. **Smooth Force Grabbing**:
   To solve the snapping issue during telekinetic grabbing, a coroutine was used to apply a gradual force over time, giving the player more control over how quickly the object was pulled toward them. Additionally, raycasting was refined to ensure only objects within a certain range could be selected.

## Optimization

To maintain performance and ensure smooth gameplay, the following optimization techniques were applied:

- **Simplifying Object Meshes**: Complex objects were replaced with simpler mesh colliders, reducing the computational cost of collision detection without compromising the visual fidelity of the scene.
- **Batch Physics Calculations**: By grouping similar objects together and reducing the number of active physics calculations, we minimized the performance impact of complex simulations, especially in scenes with many interacting objects (e.g., domino chain reactions).
- **Using LOD (Level of Detail)**: For objects far from the player, lower-polygon models were used to reduce rendering overhead, especially in large VR scenes.

### Potential Performance Bottlenecks:

- **Multiple Rigidbody Objects**: Since many objects in the scene have Rigidbodies (e.g., the dominoes, balls, and sword), there is a higher computational load for physics calculations. Reducing unnecessary physics simulations by disabling Rigidbodies when objects are not in use improved performance.
- **Collision Detection**: Complex interactions like domino chains can lead to performance issues due to the number of collisions being calculated simultaneously. We optimized this by fine-tuning the friction and mass of the dominoes to ensure smoother interactions.

## Unity Profiler Usage

Unity's **Profiler** tool was used to identify performance bottlenecks, including excessive physics calculations during intense interaction scenarios (e.g., domino chain reactions). Here's how the performance was optimized:

1. **Mesh Optimization**: Reduced the poly count on interactive objects to lower the impact on the physics engine.
2. **Physics Material Adjustments**: Applied physics materials with appropriate friction and bounce values to balance realism with performance.
3. **Dynamic Object Deactivation**: Rigidbodies were set to sleep or deactivate when objects were no longer interacting with the player or other objects.

## Conclusion

This project highlights how physics-based interactions can enhance immersion in VR environments. By implementing advanced interaction systems like multi-point grabbing, realistic object throwing, and force grabbing, the player’s ability to interact with the virtual world feels more natural and engaging. Further optimization using Unity’s Profiler ensured that the physics simulations remained performant even in complex scenes.
