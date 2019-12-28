using ElementsTree.Web.Model;
using System.Collections.Generic;

namespace ElementsTree.Web.Converters
{
	/// <summary>
	/// Конвертер для деревьев и их узлов
	/// </summary>
    public class TreeConverter
	{
		/// <summary>
		/// Конвертирует дерево в список <see cref="TreeNodeModel">TreeNodeModel</see>.
		/// </summary>
		/// <param name="tree">Дерево для конвертации.</param>
		/// <returns>Возвращает список <see cref="TreeNodeModel">TreeNodeModel</see>.</returns>
		public static List<TreeNodeModel> TreeToTreeNodeModelList(Tree tree)
		{
			var treeNodeModels = new List<TreeNodeModel>();

			if (tree == null)
				return treeNodeModels;

			foreach (var node in tree.GetTreeRoots())
				treeNodeModels.Add(TreeNodeToModel(node));

			return treeNodeModels;
		}

		/// <summary>
		/// Конвертирует узел и все его дочерние узлы в список <see cref="TreeNodeModel">TreeNodeModel</see>.
		/// </summary>
		/// <param name="tree">Узел для конвертации.</param>
		/// <returns>Возвращает список <see cref="TreeNodeModel">TreeNodeModel</see>.</returns>
		public static TreeNodeModel TreeNodeToModel(TreeNode node)
		{
			var newTreeNodeModel = new TreeNodeModel(node.Id, node.Value, node.IsDeleted);

			foreach (var child in node.Childrens)
			{
				var childItemModel = TreeNodeToModel(child);
				newTreeNodeModel.children.Add(childItemModel);
			}

			return newTreeNodeModel;
		}
	}
}
