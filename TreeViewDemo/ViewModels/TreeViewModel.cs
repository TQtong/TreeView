using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TreeViewDemo.Common.BaseModels;
using TreeViewDemo.Common.Commond;
using TreeViewDemo.Models;

namespace TreeViewDemo.ViewModels
{
    public class TreeViewModel : BindableObject
    {
        #region 属性
        /// <summary>
        /// 目录树
        /// </summary>
        public ObservableCollection<TreeModel> TreeModels { get; set; } = new ObservableCollection<TreeModel>();

        /// <summary>
        /// 当前选择的节点
        /// </summary>
        public TreeModel SelectedNode { get; private set; }

        #endregion

        #region 命令
        /// <summary>
        /// 添加根节点
        /// </summary>
        public DelegateCommand AddRootNode { get; private set; }

        /// <summary>
        /// 添加子节点
        /// </summary>
        public DelegateCommand<TreeModel> AddChildNode { get; private set; }

        /// <summary>
        /// 删除节点(根节点、子节点)
        /// </summary>
        public DelegateCommand<TreeModel> DeleteNode { get; private set; }

        /// <summary>
        /// 重命名节点(根节点、子节点)
        /// </summary>
        public DelegateCommand<TreeModel> ReNameNode { get; private set; }

        /// <summary>
        /// 完成重命名节点(根节点、子节点)
        /// </summary>
        public DelegateCommand<TreeModel> FinishReNameNode { get; private set; }

        /// <summary>
        /// 获取当前选择的节点
        /// </summary>
        public DelegateCommand<TreeView> MouseRightButtonUp { get; private set; }

        /// <summary>
        /// 实时更新节点名字
        /// </summary>
        public DelegateCommand<TextBox> TextChanged { get; private set; }
        #endregion

        public TreeViewModel()
        {
            AddRootNode = new DelegateCommand(AddRoot);
            AddChildNode = new DelegateCommand<TreeModel>(AddChild);
            DeleteNode = new DelegateCommand<TreeModel>(Delete);
            ReNameNode = new DelegateCommand<TreeModel>(ReName);
            FinishReNameNode = new DelegateCommand<TreeModel>(FinishReName);
            TextChanged = new DelegateCommand<TextBox>(Changed);
            MouseRightButtonUp = new DelegateCommand<TreeView>(RightUp);
            InitTree();
        }

        #region 方法
        /// <summary>
        /// 初始化目录树
        /// </summary>
        private void InitTree()
        {
            TreeModels.Add(new TreeModel()
            {
                Name = "我是根节点",
                NodeType = Common.Enums.TreeNodeType.RootNode
            });
        }

        /// <summary>
        /// 添加根节点
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void AddRoot()
        {
            TreeModels.Add(new TreeModel()
            {
                Name = "我是根节点",
            }); ;
        }

        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="obj"></param>
        private void AddChild(TreeModel obj)
        {
            obj.Children.Add(new TreeModel()
            {
                Name = $"{obj.Name}的孩子",
                NodeType = Common.Enums.TreeNodeType.ChildNode,
                ParentNode = obj
            });
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="obj"></param>
        private void Delete(TreeModel obj)
        {
            if (obj.NodeType == Common.Enums.TreeNodeType.RootNode)
            {
                TreeModels.Remove(obj);
                return;
            }

            obj.ParentNode.Children.Remove(obj);
        }

        /// <summary>
        /// 重命名节点
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void ReName(TreeModel obj)
        {
            SelectedNode.IsTextBoxVisibility = Visibility.Visible;
            SelectedNode.IsTextBlockVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// 完成重命名节点
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void FinishReName(TreeModel obj)
        {
            SelectedNode.IsTextBoxVisibility = Visibility.Collapsed;
            SelectedNode.IsTextBlockVisibility = Visibility.Visible;
        }

        /// <summary>
        /// 获取当前选择的节点
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void RightUp(TreeView obj)
        {
            SelectedNode = obj.SelectedItem as TreeModel;
        }

        /// <summary>
        /// 实时更新节点名称
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Changed(TextBox obj)
        {
            SelectedNode.Name = obj.Text;
        }

        #endregion

    }
}
