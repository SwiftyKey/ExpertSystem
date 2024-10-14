using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace ExpertSystem;

public sealed partial class MainWindow : Window
{
	private BinaryTree _questions = new("Вам нужен смартфон?");

	private void SetQuestions()
	{
		_questions.Left = new BinaryTree("Nokia 3310", true, "Images/Nokia3310.jpg");
		_questions.Right = new BinaryTree("У вас большой бюджет? Больше 60.000 руб.")
		{
			Left = new BinaryTree("Ваш бюджет средний? 30.000-60.000 руб.")
			{
				Left = new BinaryTree("Вам важна производительность устройства?")
				{
					Left = new BinaryTree("Samsung A14", true, "Images/SamsungA14.jpg"),
					Right = new BinaryTree("Xiaomi Redmi Note 13", true)
				},
				Right = new BinaryTree("Вам важны материалы корпуса?")
				{
					Left = new BinaryTree("Телефон должен держать заряд дольше дня?")
					{
						Left = new BinaryTree("Google Pixel 8", true, "Images/GooglePixel8.jpg"),
						Right = new BinaryTree("Realme GT 6", true, "Images/RealmeGT6.jpg")
					},
					Right = new BinaryTree("Вам важна защита от воды и пыли?")
					{
						Left = new BinaryTree("CMF Phone 1", true, "Images/CMFPhone1.jpg"),
						Right = new BinaryTree("Xiaomi 13T Pro", true, "Images/Xiaomi13TPro.jpg")
					}
				}
			},
			Right = new BinaryTree("Вам нужен компактный смартфон?")
			{
				Left = new BinaryTree("Вам нужен камерофон?")
				{
					Left = new BinaryTree("Вы планируете играть на телефоне?")
					{
						Left = new BinaryTree("Вам нужен складной телефон?")
						{
							Left = new BinaryTree("Nothing Phone 2", true, "Images/NothingPhone2.jpg"),
							Right = new BinaryTree("Это телефоны fold?")
							{
								Left = new BinaryTree("Samsung Galaxy Z Flip 6", true, "Images/SamsungGalaxyZFlip6.jpg"),
								Right = new BinaryTree("Samsung Galaxy Z Fold 6", true, "Images/SamsungGalaxyZFold6.jpg")
							}
						},
						Right = new BinaryTree("Asus ROG Phone 8", true, "Images/AsusROGPhone8.jpg")
					},
					Right = new BinaryTree("Вам нужен оптический зум с увеличением больше 3?")
					{
						Left = new BinaryTree("Samsung Galaxy S24 Ultra", true, "Images/SamsungGalaxyS24Ultra.jpg"),
						Right = new BinaryTree("Xiaomi 14 Ultra", true, "Images/Xiaomi14Ultra.jpg")
					}
				},
				Right = new BinaryTree("Вам нравятся телефоны Apple?")
				{
					Left = new BinaryTree("Samsung Galaxy S24", true, "Images/SamsungGalaxyS24.jpg"),
					Right = new BinaryTree("Вам нужна диагональ 5.4?")
					{
						Right = new BinaryTree("iPhone 13 mini", true, "Images/iPhone13mini.jpg"),
						Left = new BinaryTree("iPhone 15", true, "Images/iPhone15.jpg")
					}
				}
			}
		};

		TreeSerializer.Serialize(_questions);
	}

	private void ChangedChoice()
	{
		if (_questions.IsAnswer)
		{
			TbQuestion.Text = "Ваш выбор: " + _questions.Data;
			BtnNo.IsEnabled = false;
			BtnYes.IsEnabled = false;
			ImgBox.Source = new BitmapImage(new Uri(ImgBox.BaseUri, _questions.ImagePath));
		}
		else
		{
			TbQuestion.Text = _questions.Data;
			ImgBox.Source = null;
			if (!BtnNo.IsEnabled) BtnNo.IsEnabled = true;
			if (!BtnYes.IsEnabled) BtnYes.IsEnabled = true;
		}
	}

	public MainWindow()
	{
		this.InitializeComponent();

		//SetQuestions();
		_questions = TreeSerializer.Deserialize();
		ChangedChoice();
	}


	private void ClickedNo(object sender, RoutedEventArgs e)
	{
		_questions = _questions.Left;
		ChangedChoice();
	}

	private void ClickedYes(object sender, RoutedEventArgs e)
	{
		_questions = _questions.Right;
		ChangedChoice();
	}

	private void ClickedRetry(object sender, RoutedEventArgs e)
	{
		_questions.Data = "Вам нужен смартфон?";
		_questions.IsAnswer = false;
		//SetQuestions();
		_questions = TreeSerializer.Deserialize();
		ChangedChoice();
	}
}
