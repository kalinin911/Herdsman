# Herdsman
2D prototype

# Description
## Code Style and Architecture

-Modularity: Each class has a single responsibility,follows SRP principle;
-Event-Driven Communication: Decouples components by using events for communication between "SheepManager" and "UIManager";
-Clear and Consistent Naming: Classes, methods and variables are named clearly to reflect their purpose, improving readability and maintainability;

## OOP and SOLID
-SRP: Each class has one reason to change. For example, "UIManager" handles UI updates and "SheepManager" handles sheep management;
-OCP: Classed are open for extensions, but closed for modification. Example - new sheep behaviors can be added by creating new states without modifying existing code;
-LSP: Subtypes should be substitutable for their base types. Example - "WhiteSheep" can be used wherever "SheepBase" is expected;
-ISP: Clients should not be forced to depend on interfaces they do not use. Separate interfaces for states, factories and movement strategies ensure this.
-DIP: High-level modules should not depend on low-level modules. Both should depend on abstractions. Example - "SheepManager" depends on the abstract "ISheepFactory" rather that 
concrete implementation;

## Design patterns and Best Practices
-State Pattern: allows a sheep to alter its behavior when its internal state changes;
-Factory Method: "ISheepFactory" interface defines 
the factory method "CreateSheep". "WhiteSheepFactory" implements "ISheepFactory" to create "WhiteSheep" instances;
-Observer Pattern: "SheepManager" class uses events (Action) to notify when the player enters the yard and when the sheep count in the yard changes. "UIManager" subscribes to the 
"OnSheepInYardChanged" event to update the UI counter;
-Strategy Pattern: "IMovementStrategy" interface defines the movement method. "LinearMovementStrategy" implements "IMovementStrategy" for linear movement. "SheepBase" can switch
between different movement strategies if needed.

