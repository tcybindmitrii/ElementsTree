using System;
using System.Collections.Generic;

namespace ElementsTree.Web.Model
{
	/// <summary>
	/// Модель TreeNode для отображения на форме.
	/// </summary>
	public class TreeNodeModel
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса TreeNode.
		/// </summary>
		/// <param name="id">Уникальный идентификатор.</param>
		/// <param name="text">Текст узла.</param>
		/// <param name="disabled">Доступность узла для пользователя.</param>
		public TreeNodeModel(Guid id, string text, bool disabled)
		{
			this.id = id.ToString();
			this.text = text;
			children = new HashSet<TreeNodeModel>();
			state = new StateTreeNodeModel(disabled);
		}

		/// <summary>
		/// Уникальный идентификатор.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Текст узла.
		/// </summary>
		public string text { get; set; }

		/// <summary>
		/// Состояние узла.
		/// </summary>
		public StateTreeNodeModel state { get; set; }

		/// <summary>
		/// Дочерние объекты узла.
		/// </summary>
		public HashSet<TreeNodeModel> children { get; set; }
	}
}
