using System;

namespace ExpertSystem;

public class BinaryTree(string data, bool isAnswer=false, string imagePath="")
{
	public string Data { get; set; } = data;
	public bool IsAnswer { get; set; } = isAnswer;
	public BinaryTree? Left { get; set; } = null;
	public BinaryTree? Right { get; set; } = null;
	public string ImagePath { get; set; } = imagePath;
}

