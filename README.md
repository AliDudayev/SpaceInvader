# Space Invader Game

A classic Space Invaders clone built in C# for the console/terminal.

## 🎮 Game Overview

Defend Earth from waves of alien invaders! Control your spaceship, dodge enemy fire, and shoot down all aliens before they reach you. The game features multiple waves of enemies with increasing difficulty.

## 🚀 How to Play

### Controls
- **Arrow Keys (← →)**: Move your spaceship left and right
- **Spacebar**: Fire bullets at the aliens
- **Enter**: Start the game from the main menu

### Game Elements
- **Y**: Your spaceship
- **M**: Enemy aliens
- **|**: Your bullets (traveling upward)
- **\***: Enemy bullets (traveling downward)
- **■**: Protective barriers
- **♥**: Your remaining lives (displayed at bottom)

### Objective
- Destroy all aliens before they reach your position
- Avoid enemy bullets
- Survive through all 3 waves to win
- You have 3 lives - the game ends when you lose them all

## 📋 Requirements

- .NET Framework or .NET Core/5/6+
- Visual Studio or any C# compatible IDE
- Windows Console (for best compatibility)

## 🔧 Installation & Setup

1. Clone or download all the game files:
   - `Program.cs`
   - `Space.cs`
   - `Speler.cs`
   - `Enemies.cs`
   - `Bullets.cs`

2. Open the project in Visual Studio:
   - Create a new Console Application project
   - Add all the .cs files to your project
   - Ensure all files are in the same namespace: `SpaceInvader`

3. Build and run the project (F5 in Visual Studio)

## 🎯 Game Features

- **3 Progressive Waves**: Each wave has more enemies and increased difficulty
- **Smart Enemy AI**: Enemies move in formation and shoot randomly
- **Collision Detection**: For bullets, enemies, and barriers
- **Lives System**: Start with 3 lives, displayed as hearts
- **Win/Loss Conditions**: Clear all waves to win, or lose all lives
- **Protective Barriers**: Use them as cover from enemy fire
- **Visual Feedback**: Screen flashes red when you take damage

## 🐛 Troubleshooting

### Enemies Not Visible
If you can't see the enemies, ensure your console supports the characters used. The game uses standard ASCII characters:
- M (enemies)
- \* (enemy bullets)
- Y (player)
- | (player bullets)

### Console Window Issues
- Make sure your console window is large enough (at least 20 rows x 16 columns)
- Run in full-screen mode for best experience
- If characters appear garbled, check your console's encoding settings

### Performance Issues
- The game runs at ~20 FPS (50ms delay between frames)
- Close other applications if experiencing lag
- Ensure your console buffer settings are optimized

## 🎨 Customization

You can easily modify the game by editing the following:

- **Game Speed**: Change `System.Threading.Thread.Sleep(50)` in Program.cs
- **Player Lives**: Modify `private int health = 3` in Speler.cs
- **Enemy Speed**: Adjust `timerWave` values in Enemies.cs
- **Difficulty**: Change `randomMax` values in Enemies.cs for enemy fire rate

## 📝 Code Structure

- **Program.cs**: Main game loop and entry point
- **Space.cs**: Game map/board management and rendering
- **Speler.cs**: Player spaceship logic and input handling
- **Enemies.cs**: Enemy AI, movement, and wave spawning
- **Bullets.cs**: Bullet spawning logic

## 🏆 Tips for Success

1. Use the barriers for cover - they block enemy bullets
2. Focus on clearing one column of enemies at a time
3. Enemy fire rate increases with each wave
4. Watch for patterns in enemy movement
5. Don't waste shots - you can only have one bullet on screen at a time

## 👨‍💻 Author

Magomed-Ali Dudayev

## 📄 License

This is an educational project inspired by the classic Space Invaders arcade game.

---

Enjoy defending Earth from the alien invasion! 🛸👾s
