## Challenges

### Visual Clutter
Unity's built-in animator, despite being a visual tool, often leads to a cluttered interface due to numerous connections between states. This clutter complicates the readability and comprehension of the overall system.

### Out of Control Dependencies Between States
The intricate web of dependencies between states can result in a dreaded ripple effect when modifications are made. For example, adding or removing a state necessitates the creation or elimination of connections with existing states, complicating maintenance.

### Repeat, Boilerplate Code
States require comprehensive information for each operational tick, encompassing both actions and condition checks for potential state transitions. This often leads to repetitive and boilerplate code, particularly in the case of conditions.

## Solutions

### State Machines to Improve Visual Clutter and Lower Coupling

#### Using State Machines
To mitigate the overwhelming number of connections, state machines can be employed as groups of states. By creating smaller groups and limiting connections to states within the same group, the overall number of connections can be significantly reduced.

State machines are hierarchical, functioning like nested Russian dolls. The program flow enters and exits through these state machines, with the exit from one state machine seamlessly transitioning the flow back to the parent state machine.

#### Transitioning Between States from Different State Machines
To further limit connections, transitions should target a different state machine rather than a specific state. Since state machines have default entry states, transitioning to a state machine effectively means starting from this default state.

#### Decoupled State Machines
Transitioning towards a state machine rather than a specific state reduces coupling between states. The originating state remains unaware of specific states within the target state machine, allowing for internal modifications without necessitating adjustments in transitions.

Further decoupling can be achieved by transitioning to the exit state of a state machine. This approach abstracts the transition process, as the originating state does not specify the target state machine.

While this approach can reduce maintenance efforts, it is not without potential pitfalls. For instance, changing the entry state might inadvertently introduce bugs.

#### Removing Visual Links to Entry and Exit States
Eliminating visual links in the animator controller (e.g., using `Animator.Play` instead of `Animator.SetTrigger`) can help reduce clutter. The entry state's role is to determine the appropriate starting state when re-entering a state machine, especially useful when returning to a set of tasks represented by different states.

However, implementing this architecture in code can be complex. The entry state and other states share common setup processes but differ in actions and transition methods. Creating different child state classes to account for these differences could lead to the pitfalls of inheritance. A simpler structure with a single parent class and one level of child classes is more manageable.

#### Favoring Sequences of States
Adopting a sequential approach to state transitions, where each state leads to a predetermined next state, simplifies the design. For example, a state machine with five states interconnected would result in 20 connections, whereas a sequential approach would only require five connections.

#### Limitations
All proposed solutions have their trade-offs, and in some cases, they can significantly limit the system's capabilities.

### Reusable Conditions to Limit Repeat and Boilerplate Code

#### Pros
Encapsulating conditions into individual, reusable components is an effective strategy. By creating an abstract class with a boolean method `ConditionIsTRUEorFALSE()`, and having child classes implement this method, conditions become modular and reusable.

Alternatively, Unity events could be used to eliminate the need for new child Condition classes. However, this approach is more prone to errors, as any MonoBehaviour can be assigned to a Unity Event field, whereas only Condition classes are suitable for a Condition field.

Conditions can be shared across multiple pairs of condition-target state. States are assigned lists of these pairs, with the first true condition triggering a state change. The ability to reorder pairs in the editor allows for prioritization of conditions.

#### Cons
The main drawback of this approach is the increased coupling due to the need for conditions to access public methods and properties in other classes.

Additionally, the nature of `StateMachineBehaviour` differs from `MonoBehaviour`, preventing direct assignment of class instances in the script. A workaround involves using a `ConditionStatePairGroup` MonoBehaviour attached to the GameObject with the animator and linking states to their corresponding groups via string keys. This method, however, is error-prone.

### Limiting the amount of transition triggers with the one transition trigger for multiple states approach

#### One Trigger for One State approach

##### Pros:
- **Readability**: Each trigger is clearly named after the state it's linked to, enhancing understanding of its function.
- **Reduced Bug Risk**: The direct mapping between triggers and states minimizes the chance of unintended interactions within the state machine.

##### Cons:
- **Higher Maintenance Cost**: Requires updates to transitions when adding or removing states, which can be laborious and error-prone in complex systems.

#### One Trigger for Multiple States approach

##### Pros:
- **Lower Maintenance Cost**: Transitions are not tied to specific states, so adding or removing states doesn't necessarily entail modifications to the transitions, simplifying state machine management.

##### Cons:
- **Reduced Readability**: Triggers are linked to events or conditions rather than specific states, potentially complicating the understanding of the state machine's flow.
- **Increased Bug Risk**: Triggers linked to conditions can lead to unintended effects across multiple states if changes are made to accommodate one state. This interconnectedness can result in complex and unpredictable behavior, heightening the likelihood of bugs.





