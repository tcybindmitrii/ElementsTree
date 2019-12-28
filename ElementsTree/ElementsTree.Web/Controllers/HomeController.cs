using Microsoft.AspNetCore.Mvc;
using ElementsTree.Web.Converters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;

namespace ElementsTree.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly Tree dbTree;
        private readonly Tree localTree;
        private readonly IMemoryCache _cache;

        public HomeController(IMemoryCache memoryCache)
        {
            if (memoryCache == null)
                throw new TreeException("Кэш не был инициализирован. Обратитесь к разработчикам.");
            if (!memoryCache.TryGetValue(Properties.Resources.StrDbTree, out Tree dbTree))
                throw new TreeException("В кеше отсутствует дерево БД. Обратитесь к разработчикам.");
            if (!memoryCache.TryGetValue(Properties.Resources.StrLocalTree, out Tree localTree))
                throw new TreeException("В кеше отсутствует дерево локального кеша. Обратитесь к разработчикам.");

            this._cache = memoryCache;
            this.dbTree = dbTree;
            this.localTree = localTree;
        }

        public IActionResult Index()
        {
            ViewBag.dbTreeJSON = TreeConverter.TreeToTreeNodeModelList(dbTree);
            ViewBag.localTreeJSON = TreeConverter.TreeToTreeNodeModelList(localTree);

            return View();
        }

        /// <summary>
        /// Добавление узла в локальный кэш.
        /// </summary>
        /// <param name="value">Значение узла.</param>
        /// <param name="parentId">Уникальный идентификатор родителя узла.</param>
        public IActionResult Add(string value, Guid? parentId)
        {
            try
            {
                localTree.AddNode(Guid.NewGuid(), parentId, value);
            }
            catch (TreeException ex)
            {
                return new JsonResult(new { success = false, responseText = ex.Message });
            }
            return new JsonResult(new { success = true, localTreeJSON = TreeConverter.TreeToTreeNodeModelList(localTree) });
        }

        /// <summary>
        /// Изменить значение узла в локальном кэше
        /// </summary>
        /// <param name="nodeId">Идентификатор узла.</param>
        /// <param name="newValue">Новое значение узла</param>
        public IActionResult Edit(Guid? nodeId, string newValue)
        {
            if (!nodeId.HasValue)
                return new JsonResult(new { success = false, responseText = "Выберите узел." });
            if (string.IsNullOrEmpty(newValue) || newValue.Length > 10)
                return new JsonResult(new { success = false, responseText = "Имя должно иметь от 1 до 10 символов." });

            try
            {
                localTree.ChangeNodeValue(nodeId.Value, newValue);
            }
            catch(TreeException ex)
            {
                return new JsonResult(new { success = false, responseText = ex.Message });
            }
            return new JsonResult(new { success = true, localTreeJSON = TreeConverter.TreeToTreeNodeModelList(localTree) });
        }

        /// <summary>
        /// Удаление узла в локальном кеше
        /// </summary>
        /// <param name="nodeId">Идентификатор узла.</param>
        public IActionResult Remove(Guid? nodeId)
        {
            if (!nodeId.HasValue)
                return new JsonResult(new { success = false, responseText = "Выберите узел и попытайтесь снова." });

            try
            {
                localTree.RemoveNode(nodeId.Value);
            }
            catch (TreeException ex)
            {
                return new JsonResult(new { success = false, responseText = ex.Message });
            }
            return new JsonResult(new { success = true, localTreeJSON = TreeConverter.TreeToTreeNodeModelList(localTree) });
        }

        /// <summary>
        /// Сохранение всех изменений локального кеша в БД
        /// </summary>
        public IActionResult Apply()
        {
            try
            {
                dbTree.UpdateTree(localTree.GetForest());
            }
            catch (TreeException ex)
            {
                return new JsonResult(new { success = false, responseText = ex.Message });
            }

            _cache.Set(Properties.Resources.StrLocalTree, new Tree());
            return new JsonResult(new { success = true, localTreeJSON = TreeConverter.TreeToTreeNodeModelList(localTree) });
        }

        /// <summary>
        /// Сброс всех изменений в начальное положение.
        /// </summary>
        public IActionResult Reset()
        {
            _cache.Set(Properties.Resources.StrDbTree, Tree.GetDefaultTree());
            _cache.Set(Properties.Resources.StrLocalTree, new Tree());
            return new JsonResult(new { success = true });
        }

        /// <summary>
        /// Копирование узла дерева из БД в локальный кэш.
        /// </summary>
        /// <param name="dbNodeId">Идентификатор узла.</param>
        public IActionResult CopyFromDb(Guid dbNodeId)
        {
            var dbNode = dbTree.GetNode(dbNodeId);
            if (dbNode == null)
                return new JsonResult(new { success = false, responseText = "Выбранный узел отсутствует в БД. Попытайтесь ещё раз или выберите другой узел." });
            if (localTree.IsHaveNode(dbNodeId))
                return new JsonResult(new { success = false, responseText = "Выбранный узел уже добавлен в локальный кэш. Попытайтесь ещё раз или выберите другой узел." });

            try
            {
                localTree.AddNode(dbNodeId, dbNode.Parent?.Id, dbNode.Value, dbNode.IsDeleted, dbNode.Childrens.Select(x => x.Id).ToList());
                ViewBag.localTreeJSON = TreeConverter.TreeToTreeNodeModelList(localTree);
            }
            catch (TreeException ex)
            {
                return new JsonResult(new { success = false, responseText = ex.Message });
            }

            return new JsonResult(new { success = true, localTreeJSON = TreeConverter.TreeToTreeNodeModelList(localTree) });
        }

    }
}