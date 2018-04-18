using MainDSA.DataStructures.Trees;
using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DSATests.DataStructures
{
    [TestClass]
    public class NaryTreeOperationsTests
    {
        NaryTreeNode node;
        [TestInitialize]
        public void CreateData()
        {
            node = new NaryTreeNode();
            node.val = 1;
            node.children = new List<NaryTreeNode>();
            var node3 = new NaryTreeNode(3, new List<NaryTreeNode>());
            var node3Child1 = new NaryTreeNode(5, null);
            var node3Child2 = new NaryTreeNode(6, null);
            node3.children.Add(node3Child1);
            node3.children.Add(node3Child2);
            node.children.Add(node3);
            node.children.Add(new NaryTreeNode(2, null));
            node.children.Add(new NaryTreeNode(4, null));
        }

        [TestMethod]
        public void TestNaryPreOrderTraversal1()
        {
            //Arrange
            NaryTreeOperations naryTreeOperations = new NaryTreeOperations();

            //Act
            var results = naryTreeOperations.PreOrder(node);

            // Assert - Need to be modified stil not complete
            Assert.AreEqual(6, results.Count);
        }

        [TestMethod]
        public void TestNaryPostOrderTraversal1()
        {
            //Arrange
            NaryTreeOperations naryTreeOperations = new NaryTreeOperations();

            //Act
            var results = naryTreeOperations.PostOrder(node);

            // Assert - Need to be modified stil not complete
            Assert.AreEqual(6, results.Count);
        }

        [Ignore]
        [TestMethod]
        public void TestNaryLevelOrderTraversal1()
        {
            //Arrange
            NaryTreeOperations naryTreeOperations = new NaryTreeOperations();

            //Act
            var results = naryTreeOperations.LevelOrder(node);

            // Assert - Need to be modified stil not complete
            Assert.AreEqual(6, results.Count);
        }
    }
}
