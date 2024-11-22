using Godot;
using System;

public partial class Main : Node
{
	private Player player;
	private ParallaxLayer parallaxLayer;

	public override void _Ready()
	{
		player = GetNode<Player>("Player");
		parallaxLayer = GetNode<ParallaxLayer>("Background/ParallaxLayer");

		ConnectObstacleEvents();
		new_game();
	}

	private void ConnectObstacleEvents()
	{
		foreach (Node child in parallaxLayer.GetChildren())
		{
			if (child is Obstacles obstacle)
			{
				obstacle.Hit += OnObstacleHit; 
				GD.Print($"Subscribed to obstacle: {obstacle.Name}");
			}
		}
	}

	private void OnObstacleHit()
	{
		GD.Print("Game Over! Collision detected.");
		stop_game();
	}

	public void stop_game()
	{
		GD.Print("Game Stopped.");
	}

	public void new_game()
	{
		GD.Print("New Game Started.");
	}
}
