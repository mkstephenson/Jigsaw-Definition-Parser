using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace ParsePuzzles
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			BinaryTree organiser = new BinaryTree();
			Dictionary<string, List<string>> puzzlesList = new Dictionary<string, List<string>>();
			System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
			dialog.Multiselect = true;
			dialog.ShowDialog();
			string[] files = dialog.FileNames;
			foreach (string item in files)
			{
				string currentGroupName = string.Empty;
				XmlTextReader reader = new XmlTextReader(item);
				while (reader.Read())
				{
					switch (reader.NodeType)
					{
						case XmlNodeType.Element:
							{
								if (reader.Name == "Group")
								{
									currentGroupName = reader.GetAttribute("title");
									organiser.Add(currentGroupName);
									puzzlesList.Add(currentGroupName, new List<string>());
								}
								else if (reader.Name == "Puzzle")
								{
									puzzlesList[currentGroupName].Add(reader.GetAttribute("title"));
								}
								break;
							}
						default: break;
					}
				}
			}

			List<string> orderedList = new List<string>();

			organiser.Read(orderedList);

			StringBuilder builder = new StringBuilder();

			foreach (string item in orderedList)
			{
				builder.AppendLine("--------------------------------------------------------------------------------");
				builder.AppendLine(item);
				builder.AppendLine("--------------------------------------------------------------------------------");
				foreach (string puzzle in puzzlesList[item])
				{
					builder.AppendLine(puzzle);
				}
				builder.AppendLine();
			}

			result.Text = builder.ToString();
		}
	}

	public class BinaryTree
	{
		string rootNode;
		BinaryTree leftTree, rightTree;

		public BinaryTree()
		{
			rootNode = null;
		}

		public BinaryTree(string newName)
		{
			rootNode = newName;
		}

		public void Read(List<string> stringsToReturn)
		{
			if (rightTree != null)
			{
				rightTree.Read(stringsToReturn);
			}

			stringsToReturn.Add(this.rootNode);

			if (leftTree != null)
			{
				leftTree.Read(stringsToReturn);
			}
		}

		public void Add(string newName)
		{
			if (rootNode == null)
			{
				rootNode = newName;
			}
			else
			{
				if (newName[0] == rootNode[0])
				{
					if (newName[1] > rootNode[1])
					{
						if (leftTree == null)
						{
							leftTree = new BinaryTree(newName);
						}
						else
						{
							leftTree.Add(newName);
						}
					}
					else
					{
						if (rightTree == null)
						{
							rightTree = new BinaryTree(newName);
						}
						else
						{
							rightTree.Add(newName);
						}
					}
				}
				else
				{
					if (newName[0] > rootNode[0])
					{
						if (leftTree == null)
						{
							leftTree = new BinaryTree(newName);
						}
						else
						{
							leftTree.Add(newName);
						}
					}
					else
					{
						if (rightTree == null)
						{
							rightTree = new BinaryTree(newName);
						}
						else
						{
							rightTree.Add(newName);
						}
					}
				}
			}
		}
	}
}
