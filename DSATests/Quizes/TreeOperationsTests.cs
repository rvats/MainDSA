using MainDSA.DataStructures.Trees;
using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class TreeOperationsTests
    {
        private TreeNode root;

        /// <summary>
        /// Always Get Called Once The Test is Executed
        /// </summary>
        [TestInitialize]
        public void CreateData()
        {
            root= new TreeNode(4);
            root.Left = new TreeNode(2);
            root.Left.Left = new TreeNode(1);
            root.Left.Right = new TreeNode(3);
            root.Right = new TreeNode(6);
            root.Right.Left = new TreeNode(5);
            root.Right.Right = new TreeNode(7);
        }
        
        [TestMethod]
        public void TestBinaryTreePaths1()
        {
            // Arrange 
            // Was just contemplating whether we need to call the method explicitly after we have marked it with TestInitialize Attribute
            // Turns Out :- No :-)

            // Act
            TreeOperations treeOperations = new TreeOperations();
            var results = treeOperations.BinaryTreePaths(root);

            // Assert
            Assert.AreEqual(4, results.Count, "Wrong Value");
            Assert.AreEqual("4->2->1", results[0], "Wrong Value");
            Assert.AreEqual("4->2->3", results[1], "Wrong Value");
            Assert.AreEqual("4->6->5", results[2], "Wrong Value");
            Assert.AreEqual("4->6->7", results[3], "Wrong Value");
        }

        [TestMethod]
        public void TestBinaryTreePaths2()
        {
            // Arrange 
            var root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Left.Right = new TreeNode(5);
            root.Right = new TreeNode(3);

            // Act
            TreeOperations treeOperations = new TreeOperations();
            var results = treeOperations.BinaryTreePaths(root);

            // Assert
            Assert.AreEqual(2, results.Count, "Wrong Value");
            Assert.AreEqual("1->2->5", results[0], "Wrong Value");
            Assert.AreEqual("1->3", results[1], "Wrong Value");
        }

        [TestMethod]
        public void TestIsValidBinarySearchTree1()
        {
            // Arrange 
            // Was just contemplating whether we need to call the method explicitly after we have marked it with TestInitialize Attribute
            // Turns Out :- No :-)

            // Act
            TreeOperations treeOperations = new TreeOperations();
            var result = treeOperations.IsValidBinarySearchTree(root);

            // Assert
            Assert.AreEqual(true, result, "Wrong Value");
        }

        [TestMethod]
        public void TestIsValidBinarySearchTree2()
        {
            // Arrange 
            var root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Left.Right = new TreeNode(5);
            root.Right = new TreeNode(3);

            // Act
            TreeOperations treeOperations = new TreeOperations();
            var result = treeOperations.IsValidBinarySearchTree(root);

            // Assert
            Assert.AreEqual(false, result, "Wrong Value");
        }

        [TestMethod]
        public void TestGetDiameterOfBinaryTree1()
        {
            // Arrange

            // Act
            TreeOperations treeOperations = new TreeOperations();
            var result = treeOperations.GetDiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(4, result, "Wrong Value");
        }

        [TestMethod]
        public void TestGetDiameterOfBinaryTree2()
        {
            // Arrange 
            var root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Left.Right = new TreeNode(5);
            root.Right = new TreeNode(3);

            // Act
            TreeOperations treeOperations = new TreeOperations();
            var result = treeOperations.GetDiameterOfBinaryTree(root);

            // Assert
            Assert.AreEqual(3, result, "Wrong Value");
        }

        /// <summary>
        /// Always Get Called Once The Test is Over
        /// </summary>
        [TestCleanup]
        public void DestroyData()
        {
            root = null;
        }
    }
}
