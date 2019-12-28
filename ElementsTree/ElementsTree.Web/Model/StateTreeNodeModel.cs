using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElementsTree.Web.Model
{
    /// <summary>
    /// Состояние узла TreeNodeModel.
    /// </summary>
    public class StateTreeNodeModel
    {
        /// <summary>
		/// Инициализирует новый экземпляр класса StateTreeNodeModel.
        /// </summary>
		/// <param name="disabled">Показатель, доступности узла для пользователя.</param>
		/// <param name="opened">Показатель, развёрнут узел или нет.</param>
		/// <param name="selected">Показатель, выбран узел или нет.</param>
        public StateTreeNodeModel(bool disabled = false, bool opened = true, bool selected = false)
        {
            this.opened = opened;
            this.selected = selected;
            this.disabled = disabled;
        }

        /// <summary>
        /// Показатель, развёрнут узел или нет.
        /// </summary>
        public bool opened { get; set; } = true;

        /// <summary>
        /// Показатель, выбран узел или нет.
        /// </summary>
        public bool selected { get; set; } = false;

        /// <summary>
        /// Показатель, доступности узла для пользователя.
        /// </summary>
        public bool disabled { get; set; }
    }
}
