# Temple of Logic

Temple of Logic is a VR puzzle game designed to teach core logic operators to first-year computer science students. Instead of working through truth tables on paper, players solve spatial puzzles by connecting physical logic gates inside a virtual temple environment.

## Screenshots

![Gameplay - Main Chamber](https://postimg.cc/XG6zqCsp)
*Main chamber showing circuit paths on temple walls*

![VR Interaction](https://i.postimg.cc/ydD4fh9m/Screenshot-2026-11-05-123510.png)
*Picking up and placing logic blocks in VR*

## Project Details

- **Target Audience:** First-year Computer Science students (Intro to CS / Discrete Math)
- **Goal:** Make abstract Boolean logic concepts visual and interactive
- **Format:** Single-player VR (playable in campus VR labs or on home headsets)
- **Developed By:** Student project team
- **Audio:** Uses AI-generated voice lines for in-game instructions and hints

## Gameplay & Logic Mechanics

Players move through temple rooms where doors, bridges, and mechanisms are controlled by logic circuits. 

![Signal Flow Diagram](https://via.placeholder.com/1200x400.png?text=Signal+Flow+Diagram)

Puzzles use **Bloom's Taxonomy** to step through difficulty:

1. **Remember / Understand:** Learn basic gate behaviors (`AND`, `OR`, `NOT`) by watching real-time light signals flow through socketed blocks.
2. **Apply:** Complete partial circuits to match target truth tables.
3. **Analyze:** Trace multi-gate networks (`NAND`, `NOR`, `XOR`, `XNOR`) across larger rooms to locate signal bottlenecks.
4. **Evaluate:** Inspect broken circuits in temple traps, identify the faulty logic gate, and replace it.
5. **Create:** Wire complete circuits from scratch to meet specified output conditions.

## Architecture & Modular Design

The codebase is structured so new levels and logic mechanics can be added without modifying core game logic.

![Modular Architecture](https://via.placeholder.com/600x350.png?text=Modular+Logic+Architecture)
*Decoupled logic node architecture*

![Level Building Grid](https://via.placeholder.com/600x350.png?text=Level+Editor+Grid)
*Grid-snapped room prefabrication*

- **Modular Gate Nodes:** Logic components operate as independent scripts. Any 3D object can become an active logic node by attaching the gate component.
- **Room Prefabs:** Level geometry and socket locations snap to standard grid units for fast room creation.
- **External Data Tables:** Voice prompts and hint triggers are stored in external data sheets rather than hardcoded into level scripts.

## Tech Stack

- **Engine:** Unity / Unreal Engine *(update as needed)*
- **SDK:** OpenXR / XR Interaction Toolkit
- **Platform:** PC VR / Standalone VR
- **Audio Tools:** AI Voice Generator (ElevenLabs / Resemble AI)
