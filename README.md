# Ejemplo de Plataformas 2D
En este ejemplo tomamos el repo de [Input System basico con arquitectura distribuida](https://github.com/Programacion-III-Unity/Input-con-arquitectura-distribuida), y construimos un juego de plataformas en 2D simple.

El juego cuenta con los siguientes componentes:
- Sprites de personaje, y mundo
- Tilesheets y tilemaps para el mundo donde se interactua
- Enemigos (estaticos), que generan daño al personaje al tocarlos
- 3 vidas (el personaje se genera dinamicamente desde un prefab)
- Animaciones del personaje
- Debug para ver status del personaje
- Deteccion de colisiones
- Implementamos un Game Manager, en forma de Singleton.

La fisica implementada en este juego es de tipo Kinematica en lugar de Dinamica (que usa el sistema de fisica de Unity) para que tenga un feeling mas arcade.

Aplicamos tambien el principio de la responsabilidad unica en los componentes, segun el siguiente diagrama: 

![imagen](https://github.com/Programacion-III-Unity/Ejemplo-Plataformas-2D/raw/main/docs/Diagram.png)
