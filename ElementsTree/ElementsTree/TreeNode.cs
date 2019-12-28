using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ElementsTree
{
	/// <summary>
	/// Узел дерева.
	/// </summary>
    public class TreeNode
	{
		/// <summary>
		/// Инициализирует новый узел дерева. Автоматически задаётся уникальный идентификатор, родитель равный null и помечается как не удалённый.
		/// </summary>
		/// <param name="value">Значение узла.</param>
		internal TreeNode(string value)
		{
			Id = Guid.NewGuid();
			Value = value;
			Parent = null;
			IsDeleted = false;
			childrens = new List<TreeNode>();
			Childrens = childrens.AsReadOnly();
		}

		/// <summary>
		/// Инициализирует новый узел дерева. Автоматически задаётся родитель равный null и помечается как не удалённый.
		/// </summary>
		/// <param name="id">Уникальный идентификатор.</param>
		/// <param name="value">Значение узла.</param>
		/// <param name="isDeleted">Признак, указывающий удалён узел или нет.</param>
		internal TreeNode(Guid id, string value, bool isDeleted)
		{
			Id = id;
			Value = value;
			Parent = null;
			IsDeleted = isDeleted;
			childrens = new List<TreeNode>();
			Childrens = childrens.AsReadOnly();
		}

		/// <summary>
		/// Добавление дочернего узла.
		/// </summary>
		/// <param name="child">Дочерний узел.</param>
		internal void AddChild(TreeNode child)
		{
			child.Parent = this;
			childrens.Add(child);
		}

		/// <summary>
		/// Уникальный идентификатор
		/// </summary>
		public Guid Id { get; internal set; }

		/// <summary>
		/// Родитель
		/// </summary>
		public TreeNode Parent { get; internal set; }

		/// <summary>
		/// Значение узла
		/// </summary>
		public string Value { get; internal set; }

		/// <summary>
		/// Признак, указывающий удалён узел или нет
		/// </summary>
		public bool IsDeleted { get; internal set; }

		/// <summary>
		/// Список дочерних элементов
		/// </summary>
		public ReadOnlyCollection<TreeNode> Childrens { get; private set; }
		private List<TreeNode> childrens;
	}
}
