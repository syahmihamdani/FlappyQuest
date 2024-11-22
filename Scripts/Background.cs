using Godot;

public partial class Background : ParallaxBackground
{
	[Export] PackedScene obstacleScene;
	private ParallaxLayer parallaxLayer;

	const float SCROLL_SPEED = 200f; 
	const float MIN_Y = 50f;       
	const float MAX_Y = 450f;        

	public override void _Ready()
	{
		// Get the ParallaxLayer node
		parallaxLayer = GetNode<ParallaxLayer>("Background");
		if (parallaxLayer != null)
		{
			GD.Print("ParallaxLayer found!");
		}
		else
		{
			GD.Print("ParallaxLayer not found!");
		}

		// Timer timer = GetNode<Timer>("Timer");
		// timer.Timeout += () => OnTimeout();
		// timer.Start(); 
	}

	public override void _Process(double delta)
	{
		// Scroll the background
		ScrollOffset = new Vector2(ScrollOffset.X - SCROLL_SPEED * (float)delta, ScrollOffset.Y);
	}

	// private void OnTimeout()
	// {
	// 	// Generate a random Y position for the obstacle
	// 	float randY = (float)GD.RandRange(MIN_Y, MAX_Y);

	// 	// Instantiate the obstacle
	// 	if (obstacleScene == null)
	// 	{
	// 		GD.PrintErr("Obstacle scene is not assigned!");
	// 		return;
	// 	}

	// 	Area2D obstacle = (Area2D)obstacleScene.Instantiate();

	// 	// Set the obstacle's position
	// 	obstacle.Position = new Vector2(parallaxLayer.Position.X + 800, randY);
	// 	parallaxLayer.AddChild(obstacle);

	// 	GD.Print($"Obstacle instantiated at Y: {randY}");
	// }
}
