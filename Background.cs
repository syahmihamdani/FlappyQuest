using Godot;

public partial class Background : ParallaxBackground
{
	const float SCROLL_SPEED = 100f;

	public override void _Ready()
	{
		var parallaxLayer = GetNode<ParallaxLayer>("Background");
		if (parallaxLayer != null)
		{
			GD.Print("ParallaxLayer found!");
		}
		else
		{
			GD.Print("ParallaxLayer not found!");
		}
	}

	public override void _Process(double delta)
	{
		ScrollOffset = new Vector2(ScrollOffset.X - SCROLL_SPEED * (float)delta, ScrollOffset.Y);
	}
}
