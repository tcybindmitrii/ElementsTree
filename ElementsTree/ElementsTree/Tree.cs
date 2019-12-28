using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsTree
{
	/// <summary>
	/// Дерево, содержащее один или несколько корней.
	/// </summary>
	public class Tree
	{
		/// <summary>
		/// Инициализирует новое дерево.
		/// </summary>
		public Tree()
		{
			rootNodes = new List<TreeNode>();
			idToNodes = new Dictionary<Guid, TreeNode>();
		}

		/// <summary>
		/// Получить новое(тестовое) дерево по умолчанию.
		/// </summary>
		/// <returns>Дерево(тестовое) по умолчанию.</returns>
		public static Tree GetDefaultTree()
		{
			var root = new TreeNode("root");
			var node1 = new TreeNode("node1");
			var node2 = new TreeNode("node2");

			var node11 = new TreeNode("node11");
			var node12 = new TreeNode("node12");
			var node21 = new TreeNode("node21");

			var node111 = new TreeNode("node111");
			var node112 = new TreeNode("node112");
			var node121 = new TreeNode("node121");
			var node211 = new TreeNode("node211");
			var node212 = new TreeNode("node212");

			var node1111 = new TreeNode("node1111");
			var node2111 = new TreeNode("node2111");

			var node11111 = new TreeNode("node11111");
			var node21111 = new TreeNode("node21111");

			var tree = new Tree();

			tree.AddNode(root.Id, root.Parent?.Id, root.Value, root.IsDeleted, null);

			tree.AddNode(node1.Id, root.Id, node1.Value, node1.IsDeleted, null);
			tree.AddNode(node2.Id, root.Id, node2.Value, node2.IsDeleted, null);

			tree.AddNode(node11.Id, node1.Id, node11.Value, node11.IsDeleted, null);
			tree.AddNode(node12.Id, node1.Id, node12.Value, node12.IsDeleted, null);
			tree.AddNode(node21.Id, node2.Id, node21.Value, node21.IsDeleted, null);

			tree.AddNode(node111.Id, node11.Id, node111.Value, node111.IsDeleted, null);
			tree.AddNode(node112.Id, node11.Id, node112.Value, node112.IsDeleted, null);
			tree.AddNode(node121.Id, node12.Id, node121.Value, node121.IsDeleted, null);
			tree.AddNode(node211.Id, node21.Id, node211.Value, node211.IsDeleted, null);
			tree.AddNode(node212.Id, node21.Id, node212.Value, node212.IsDeleted, null);

			tree.AddNode(node1111.Id, node111.Id, node1111.Value, node1111.IsDeleted, null);
			tree.AddNode(node2111.Id, node211.Id, node2111.Value, node2111.IsDeleted, null);

			tree.AddNode(node11111.Id, node1111.Id, node11111.Value, node11111.IsDeleted, null);
			tree.AddNode(node21111.Id, node2111.Id, node21111.Value, node21111.IsDeleted, null);

			return tree;
		}

		/// <summary>
		/// Получить все узлы-корни дерева.
		/// </summary>
		/// <returns>Все узлы-корни дерева.</returns>
		public List<TreeNode> GetTreeRoots()
		{
			var treeNodes = new List<TreeNode>();

			foreach (var rootNode in rootNodes)
				treeNodes.Add(rootNode);

			return treeNodes;
		}

		/// <summary>
		/// Получить плоский список узлов начиная с указанного.
		/// </summary>
		/// <param name="node">Узел дерева от которого следует строить плоский список.</param>
		/// <returns>Плоский список узлов начиная с указанного. При отсутствии указанного узла возвращает все узлы дерева.</returns>
		public List<TreeNode> GetForest(TreeNode node = null)
		{
			var treeNodes = new List<TreeNode>();

			if (node == null)
			{
				foreach (var rootNode in rootNodes)
					treeNodes.AddRange(GetForestForNode(rootNode));
			}
			else
			{
				treeNodes.AddRange(GetForestForNode(node));
			}

			return treeNodes;
		}

		/// <summary>
		/// Получить узел дерева по его уникальному идентификатору.
		/// </summary>
		/// <param name="id">Уникальный идентификатор узла.</param>
		/// <returns>Возвращает узел дерева. В случае, если узел не найден возвращает null.</returns>
		public TreeNode GetNode(Guid id)
		{
			if (idToNodes.TryGetValue(id, out TreeNode node))
				return node;
			return null;
		}

		/// <summary>
		/// Добавляет узел в дерево. Автоматически добавляется к родителю если такой есть, иначе записывается в корни дерева. 
		/// Автоматически к нему присоединяются дочерние узлы. 
		/// Если добавляется удалённый узел или в дереве есть удалённый родитель, то сам узел и его дочерние узлы так же удаляются.
		/// </summary>
		/// <param name="id">Уникальный идентификатор.</param>
		/// <param name="parentId">Идентификатор родителя. Если равен null, то узел добавляется в корень дерева.</param>
		/// <param name="value">Значение узла.</param>
		/// <param name="isDeleted">Признак, указывающий удалён узел или нет.</param>
		/// <param name="childIds">Уникальные идентификаторы дочерних объектов узла.</param>
		/// <exception cref="TreeException">Каждый id должен быть уникальным в дереве.</exception>  
		public void AddNode(Guid id, Guid? parentId, string value, bool isDeleted = false, List<Guid> childIds = null)
		{
			if (idToNodes.ContainsKey(id))
				throw new TreeException(string.Format("В дереве уже содержится элемент с таким идентификатором: {0}", id));

			var newNode = new TreeNode(id, value, isDeleted);

			//Если родитель содержится в дереве, то присоединяем новый узел к нему
			//Если у узла нет родителя или в текущем дереве нет узла-родителя, то добавляем узел в корень дерева
			if (parentId.HasValue && idToNodes.TryGetValue(parentId.Value, out var parent))
				parent.AddChild(newNode);
			else
				rootNodes.Add(newNode);

			//Проверяем в дереве наличие дочерних узлов. Если находим, то присоединяем их к новому узлу
			if (childIds != null)
			{
				foreach (var childId in childIds)
				{
					if (idToNodes.TryGetValue(childId, out TreeNode child))
					{
						if (rootNodes.Contains(child))
							rootNodes.Remove(child);
						newNode.AddChild(child);
					}
				}
			}

			//Если удалён новый узел или родитель нового узла, то все его дочерние узлы
			if ((newNode.Parent != null && newNode.Parent.IsDeleted) || newNode.IsDeleted)
				RemoveNode(newNode);
			
			idToNodes.Add(id, newNode);
		}

		/// <summary>
		/// Обновить узлы в дереве. Обновление касается значений узлов, а так же их удаление вместе со всеми дочерними узлами.
		/// </summary>
		/// <param name="newNodes">Узлы дерева, которые требуется обновить.</param>
		/// <exception cref="TreeException">Значение узлов дерева должны иметь от 1 до 10 символов.</exception>  
		public void UpdateTree(List<TreeNode> newNodes)
		{
			if (newNodes == null)
				return;

			foreach (var node in newNodes)
			{
				if (string.IsNullOrEmpty(node.Value) || node.Value.Length > 10)
					throw new TreeException(string.Format("Значение узла с идентификатором {0} должен иметь от 1 до 10 символов.", node.Id));
			}

			foreach (var newNode in newNodes)
			{
				if (newNode == null)
					continue;

				var curNode = GetNode(newNode.Id);
				if (curNode != null)
				{
					ChangeNodeValue(curNode, newNode.Value);
					if (newNode.IsDeleted)
						RemoveNode(curNode);
				}
				else
				{
					AddNode(newNode.Id, newNode.Parent?.Id, newNode.Value, newNode.IsDeleted, newNode.Childrens.Select(x => x.Id).ToList());
				}
			}
		}

		/// <summary>
		/// Проверить наличие узла.
		/// </summary>
		/// <param name="id">Уникальный идентификатор узла.</param>
		/// <returns>Если узел найден, то возвращает true. Иначе false.</returns>
		public bool IsHaveNode(Guid id)
		{
			if (idToNodes.ContainsKey(id))
				return true;
			return false;
		}

		/// <summary>
		/// Изменить значение узла дерева по его уникальному идентификатору.
		/// </summary>
		/// <param name="nodeId">Уникальный идентификатор узла.</param>
		/// <param name="newValue">Новое значение.</param>
		/// <returns>Если удаление произошло удачно возвращает true. Иначе false.</returns>
		/// <exception cref="TreeException">Узел должен присутствовать в дереве, а значение узла должно иметь от 1 до 10 символов.</exception>  
		public bool ChangeNodeValue(Guid nodeId, string newValue)
		{
			var node = GetNode(nodeId);
			if (node == null)
				throw new TreeException("Изменяемый узел отсутствует в дереве");

			return ChangeNodeValue(node, newValue);
		}

		/// <summary>
		/// Удаление узла. Если узел имеет дочерние объекты, то они тоже удаляются. Удаление происходит с помощью установки свойства IsDeleted=true.
		/// </summary>
		/// <param name="nodeId">Уникальный идентификатор узла.</param>
		/// <returns>Если узел был найден и удалён, возвращает true. Иначе false.</returns>
		public bool RemoveNode(Guid nodeId)
		{
			var node = GetNode(nodeId);
			if (node == null)
				return false;

			return RemoveNode(node);
		}

		/// <summary>
		/// Изменить значение узла дерева.
		/// </summary>
		/// <param name="node">Узел дерева.</param>
		/// <param name="newValue">Новое значение.</param>
		/// <returns>Если изменение произошло удачно возвращает true. Иначе false.</returns>
		/// <exception cref="TreeException">Значение узла должно иметь от 1 до 10 символов.</exception>  
		private bool ChangeNodeValue(TreeNode node, string newValue)
		{
			if (string.IsNullOrEmpty(newValue) || newValue.Length > 10)
				throw new TreeException("Значение узла должно иметь от 1 до 10 символов.");
			if (node == null)
				return false;
			
			node.Value = newValue;
			return true;
		}

		/// <summary>
		/// Удаление узла. Если узел имеет дочерние объекты, то они тоже удаляются. Удаление происходит с помощью установки свойства IsDeleted=true.
		/// </summary>
		/// <param name="node">Узел дерева.</param>
		/// <returns>Если узел был найден и удалён, возвращает true. Иначе false.</returns>
		private bool RemoveNode(TreeNode node)
		{
			if (node == null)
				return false;

			var removeNodes = GetForest(node);
			foreach (var removeNode in removeNodes)
				removeNode.IsDeleted = true;

			return true;
		}

		/// <summary>
		/// Получить плоский список узлов начиная с указанного.
		/// </summary>
		/// <param name="node">Плоский список узлов начиная с указанного.</param>
		/// <returns>Возвращает плоский список узлов начиная с указанного.</returns>
		private List<TreeNode> GetForestForNode(TreeNode node)
		{
			var treeNodes = new List<TreeNode>();

			if (node == null)
				return treeNodes;

			treeNodes.Add(node);
			foreach (var child in node.Childrens)
				treeNodes.AddRange(GetForest(child));

			return treeNodes;
		}

		private readonly List<TreeNode> rootNodes;
		private readonly Dictionary<Guid, TreeNode> idToNodes;
	}
}
