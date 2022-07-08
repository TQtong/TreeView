using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace TreeViewDemo.Common.Extensions
{
    public static class TreeViewExtension
    {
        /// <summary>
        /// 获取子控件
        /// </summary>
        public static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);

                if (child != null && child is T)
                {
                    return (T)child;
                }

                T NextChild = FindVisualChild<T>(child);
                if (NextChild != null)
                {
                    return NextChild;
                }
            }
            return null;
        }
    }
}
