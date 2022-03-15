using System;
using System.Collections;
using System.Collections.Generic;

public class LeetCodeProgram {
    public void Start() {
        var node1 = new TreeNode(1);
        var node2 = new TreeNode(2);
        var node3 = new TreeNode(3);
        var node4 = new TreeNode(4);
        node1.left = node2;
        node1.right = node3;
        node2.left = node4;

        LastOrderTraversal(node1);
    }

    #region 二叉树的遍历

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    // 前序遍历 中左右
    public void FirstOrderTraversal(TreeNode root) {
        // 递归法
        FirstGetTreeNode(root);

        // 迭代法
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode nowNode = root;
        while (null != nowNode || stack.Count != 0) {
            if (null != nowNode) {
                Console.WriteLine(nowNode.val);
                stack.Push(nowNode);
                nowNode = nowNode.left;
            } else {
                var node = stack.Pop();
                nowNode = node.right;
            }
        }
    }

    private void FirstGetTreeNode(TreeNode node) {
        if (null == node) {
            return;
        }

        ReadNode(node);
        FirstGetTreeNode(node.left);
        FirstGetTreeNode(node.right);
    }

    // 中序遍历 左中右
    public void InorderTraversal(TreeNode root) {
        // 递归法
        MidGetTreeNode(root);

        // 迭代法
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode nowNode = root;
        while (null != nowNode || stack.Count != 0) {
            if (null != nowNode) {
                stack.Push(nowNode);
                nowNode = nowNode.left;
            } else {
                var node = stack.Pop();
                Console.WriteLine(node.val);
                nowNode = node.right;
            }
        }
    }

    private void MidGetTreeNode(TreeNode node) {
        if (null == node) {
            return;
        }

        MidGetTreeNode(node.left);
        ReadNode(node);
        MidGetTreeNode(node.right);
    }

    // 后序遍历 左右中
    public void LastOrderTraversal(TreeNode root) {
        // 递归法
        LastGetTreeNode(root);

        // 迭代法
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode nowNode = root;
        while (null != nowNode || stack.Count != 0) {
            if (null != nowNode) {
                stack.Push(nowNode);
                nowNode = nowNode.left;
            } else {
                var node = stack.Pop();
                if (node.right == null) {
                    Console.WriteLine(node.val);
                }
                nowNode = node.right;
            }
        }
    }

    private void LastGetTreeNode(TreeNode node) {
        if (null == node) {
            return;
        }

        LastGetTreeNode(node.left);
        LastGetTreeNode(node.right);
        ReadNode(node);
    }
    
    private void ReadNode(TreeNode treeNode) {
        Console.WriteLine(treeNode.val);
    }

    #endregion
}