# Comp140 Assignment 1
[Link to the GitHub Repository](https://github.com/thomasoleary/Comp140-Maze)

## The brief
In this assignment, you are required to **create** a game or other playful experience which **interfaces** with a custom controller.

## The Game and Custom Controller
[Link to Poster](https://falmouthac-my.sharepoint.com/:b:/r/personal/to231922_falmouth_ac_uk/Documents/Comp140/Part%20B.pdf?csf=1&e=QhmGzC)
[Link to video explaining the controller and how ControllerCode.ino works with it](https://falmouthac-my.sharepoint.com/:v:/r/personal/to231922_falmouth_ac_uk/Documents/Comp140/Controller%20Video.mp4?csf=1&e=iw7OoS)

The Game:
> Maze Roller is a simple game in which the player has to roll a ball through a maze from its start to finish!
>To do this, all the player needs to do is tilt the controller! If the ball collides with a wall, a small haptic vibration alerts the player!

The Controller:
>Built within a small box, the controller uses the MPU6050 accelerometer to calculate pitch and roll! Along with this, it utilises the HC-05 module to allow the controller to be wireless. One additional feature of the controller is that it uses 4 disk motors for the haptic feedback.

## Sources used to create the project
### MPU6050 Library created by GitHub user [Jarzebski](https://github.com/jarzebski)
This library was used for calculating the pitch and roll values for my MPU6050 accelerometer.
This open source library made it much easier for me to obtain correct values from this module.
[Link to Jarzebski's MPU6050 Repository](https://github.com/jarzebski/Arduino-MPU6050)

## License Justification
I have chosen to use the GNU GPL-3.0 licesnse as I felt it was the best for my needs. I had decided that I wanted my code to be open source but to whoever will want to use this code, will have to reference myself and the GNU GPL-3.0 license in their work. This license also makes sure that I am not liable for any errors or bugs that may be within the repository.