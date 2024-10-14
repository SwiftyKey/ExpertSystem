using System;
using System.IO;
using System.Text.Json;

namespace ExpertSystem;

public class TreeSerializer
{
	private static readonly string _path = @"C:\Users\Swifty\source\repos\ExpertSystem\questions.json";

	private static readonly JsonSerializerOptions _options = new()
	{
		WriteIndented = true
	};

	public static void Serialize(BinaryTree bt)
	{
		using (FileStream fs = new(_path, FileMode.OpenOrCreate))
			JsonSerializer.Serialize(fs, bt, _options);
	}

	public static BinaryTree Deserialize()
	{
		using (FileStream fs = new(_path, FileMode.Open))
			return JsonSerializer.Deserialize<BinaryTree>(fs);
	}
}
