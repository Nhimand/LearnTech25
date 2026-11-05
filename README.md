# Temple of Logic

Temple of Logic is a VR puzzle game designed to teach core logic operators to first-year computer science students. Instead of working through truth tables on paper, players solve spatial puzzles by connecting physical logic gates inside a virtual temple environment.

## Screenshots

![Gameplay - Main Chamber](https://i.postimg.cc/G24wMPYJ/Screenshot-2026-11-05-123507.png)
*Main chamber*

![Gameplay - Task](https://i.postimg.cc/3Rk5Ljp2/Screenshot-2026-11-05-123517.png)
*An example task*

![VR Interaction](https://i.postimg.cc/ydD4fh9m/Screenshot-2026-11-05-123510.png)
*Picking up and placing logic blocks in VR*

## Project Details

- **Target Audience:** First-year Computer Science students (Intro to CS / Discrete Math)
- **Goal:** Make abstract Boolean logic concepts visual and interactive
- **Format:** Single-player VR (playable in campus VR labs or on home headsets)
- **Audio:** Uses AI-generated voice lines for in-game instructions and hints

## Gameplay & Logic Mechanics

Players move through temple rooms where doors, bridges, and mechanisms are controlled by logic circuits. 

Puzzles use **Bloom's Taxonomy** to step through difficulty.

## Architecture & Modular Design

The codebase is structured so new levels and logic mechanics can be added without modifying core game logic.

![Modular Architecture](https://i.postimg.cc/d1hPWRdZ/Screenshot-2026-11-05-123538.png)
*Decoupled logic node architecture*

- **Modular Gate Nodes:** Logic components operate as independent scripts. Any 3D object can become an active logic node by attaching the gate component.
- **Room Prefabs:** Level geometry and socket locations snap to standard grid units for fast room creation.
- **External Data Tables:** Voice prompts and hint triggers are stored in external data sheets rather than hardcoded into level scripts.
