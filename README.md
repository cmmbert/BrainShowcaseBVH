# Creating and implementing a simple, performance respecting AI system
## Requirements
 - The system must be simple enough that anyone can configure it
 - It must be able to be configured/tweaked within the editor
 - It must be performant enough to support multiple agents at the same time
 - It must be easily expandable

# Intro
For a game jam I had to come up with an AI system that could control several possessed furniture pieces. My previous experience entailed FSM, Behaviour trees and [GOAP](https://github.com/cmmbert/ZombieGame_GPP_Exam) and I quickly recognised that the AI I was about to create needed to be configurable by someone other than me that most likely had little to no experience coding. I also recognised that GOAP would not work in these circumstances considering the need for a lot of agents running at the same time (making graphs and pathfinding those at every frame is expensive!).
I thus set off on a path to create a version of GOAP that did not employ the graph making and pathfinding in order to conserve precious CPU cycles. If you know (or have read [my article](https://github.com/cmmbert/ZombieGame_GPP_Exam) on) GOAP you will notice a lot of similarities.

# How does it work?
## Conditions
A condition gets defined as a state that something in the world currently resides in. For example, if one object is currently closer than 2 units to the player. These conditions can be anything, as long as there is a predicate.
The conditions get updated every time the attached goal is checked, this means every frame unless the condition is not relevant (yet).

## Actions
An action is something our AI will be able to execute. For example, using the navmesh to move to a certain place. It is a script that has 3 methods:
### OnEntry()
This function gets executed every time this action gets chosen. This is typically only once.

### OnExecute()
This function gets put in the update loop for as long as this action is selected. This means this is in the hot code path and should be treated as such.

### OnExit()
This function gets executed every time this action finishes. This is typically only once.

## Goals
A goal is simply a dataset that holds a collection for Conditions, Actions and one for Completion Conditions.
Completion Conditions are the exact same as a Condition, they only get used to see if the action has finished its execution. In most cases this is the inverse of the Conditions.
This defines a behaviour of our AI. For example, a goal could be to move to the player for which you would need a goal with: 
- A IsInRangeOfPlayer condition set to desired state false (in other words, is not in range).
- An action to move to the player.
- The reverse of the IsInRangeOfPlayer in its completion conditions

## Brain
The 'Brain' is the glue that keeps everything together and executes the right goal. 
It does so by checking every goal in its collection and checking their conditions. if every condition is fulfilled, it will start executing the attached Action(s). This will continue every frame until the Completion Conditions of the selected goal are fulfilled.
The collection of Goals are ordered in priority this means that as long as both goals can be executed (read: their conditions are fulfilled), the first goal will always be executed over the second in the list.

# Conclusion
The 'Brain' sacrifices a chunk of smartness of the goap to allow for more performance. It also enables the user to mix and match the conditions and actions to achieve a new behaviour.
In practice it seems to work pretty well to apply to a lot more agents than traditional GOAP can.
